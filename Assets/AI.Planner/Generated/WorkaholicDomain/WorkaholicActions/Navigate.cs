using System.Collections.Generic;
using Unity.AI.Planner;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using Unity.Collections;
using Unity.Entities;

namespace WorkaholicDomain.WorkaholicActions
{
    public partial class Navigate : BaseAction<Navigate.Permutation>
    {
        public NativeArray<ComponentType> agentTypes { get; private set; }
        public NativeArray<ComponentType> toTypes { get; private set; }
        public NativeArray<ComponentType> timeTypes { get; private set; }

        List<(Entity, int)> m_agentEntities = new List<(Entity, int)>();
        List<(Entity, int)> m_toEntities = new List<(Entity, int)>();
        List<(Entity, int)> m_timeEntities = new List<(Entity, int)>();

        public struct Permutation
        {
            public int agentIndex;
            public int toIndex;
            public int timeIndex;
            public int Length => 3;

            public int this[int i]
            {
                get
                {
                    switch(i)
                    {
                        case 0:
                            return agentIndex;

                        case 1:
                            return toIndex;

                        case 2:
                            return timeIndex;

                    }

                    return -1;
                }
            }
        }

        protected override void OnCreateManager()
        {
            base.OnCreateManager();

            agentTypes = new NativeArray<ComponentType>(new []
            {
                ComponentType.ReadOnly<Agent>(),
                ComponentType.ReadOnly<Location>(),
            }, Allocator.Persistent);

            toTypes = new NativeArray<ComponentType>(new []
            {
                ComponentType.ReadOnly<Location>(),
            }, Allocator.Persistent);

            timeTypes = new NativeArray<ComponentType>(new []
            {
                ComponentType.ReadOnly<Time>(),
            }, Allocator.Persistent);


            m_FilterTuples = new[]
            {
                (agentTypes, m_agentEntities),
                (toTypes, m_toEntities),
                (timeTypes, m_timeEntities),
            };
        }

        protected override void OnDestroyManager()
        {
            base.OnDestroyManager();

            if (agentTypes.IsCreated)
            {
                agentTypes.Dispose();
                agentTypes = default;
            }
            if (toTypes.IsCreated)
            {
                toTypes.Dispose();
                toTypes = default;
            }
            if (timeTypes.IsCreated)
            {
                timeTypes.Dispose();
                timeTypes = default;
            }
        }

        protected override void GenerateArgumentPermutations(Entity stateEntity)
        {
            var DomainObjects = GetComponentDataFromEntity<DomainObjectTrait>(true);
            var Locations = GetComponentDataFromEntity<Location>(true);
            var Times = GetComponentDataFromEntity<Time>(true);

            FilterObjects(stateEntity);
            foreach (var (agentEntity, agentIndex) in m_agentEntities)
            {
                foreach (var (toEntity, toIndex) in m_toEntities)
                {
                    foreach (var (timeEntity, timeIndex) in m_timeEntities)
                    {
                        if (!(Locations[agentEntity].Position != Locations[toEntity].Position))
                            continue;
                        m_ArgumentPermutations.Add(new Permutation()
                        {
                            agentIndex = agentIndex,
                            toIndex = toIndex,
                            timeIndex = timeIndex,
                        });
                    }
                }
            }
        }

        protected override void ApplyEffects(Permutation permutation, Entity parentPolicyGraphNodeEntity, Entity originalStateEntity, int horizon)
        {
            var actionNodeEntity = CreateActionNode(parentPolicyGraphNodeEntity);
            var stateCopyEntity = CopyState(originalStateEntity);

            var domainObjectBuffer = EntityManager.GetBuffer<DomainObjectReference>(stateCopyEntity);
            var DomainObjects = GetComponentDataFromEntity<DomainObjectTrait>();
            var Locations = GetComponentDataFromEntity<Location>();
            var Times = GetComponentDataFromEntity<Time>();
            var objectHashes = GetComponentDataFromEntity<HashCode>();

            var agentEntity = GetEntity(domainObjectBuffer, permutation.agentIndex, stateCopyEntity);
            var toEntity = GetEntity(domainObjectBuffer, permutation.toIndex, stateCopyEntity);
            var timeEntity = GetEntity(domainObjectBuffer, permutation.timeIndex, stateCopyEntity);

            {
                var @agent = Locations[agentEntity];
                var hash = objectHashes[agentEntity];
                hash.Value -= @agent.GetHashCode();
                @agent.Position = Locations[toEntity].Position;
                Locations[agentEntity] = @agent;
                hash.Value += @agent.GetHashCode();
                objectHashes[agentEntity] = hash;
            }

            var argumentLength = permutation.Length;
            var argumentBuffer = EntityManager.GetBuffer<ActionNodeArgument>(actionNodeEntity);
            var arguments = new NativeArray<int>(argumentLength, Allocator.Temp);
            for (var i = 0; i < argumentLength; i++)
            {
                var argumentIndex = permutation[i];
                argumentBuffer.Add(new ActionNodeArgument() { DomainObjectReferenceIndex = argumentIndex });
                arguments[i] = argumentIndex;
            }

            ApplyCustomActionEffectsToState(stateCopyEntity, originalStateEntity, arguments);

            SetActionData(stateCopyEntity, originalStateEntity, parentPolicyGraphNodeEntity, horizon + 1, actionNodeEntity,
                Reward(originalStateEntity, stateCopyEntity, arguments));

            arguments.Dispose();
        }

        partial void ApplyCustomActionEffectsToState(Entity stateEntity, Entity originalStateEntity, NativeArray<int> arguments); // Implement this method in another file to extend the action's effects

        float Reward(Entity startStateEntity, Entity endStateEntity, NativeArray<int> arguments)
        {
            var reward = -2f;
            SetCustomReward(ref reward, startStateEntity, endStateEntity, arguments);

            return reward;
        }

        partial void SetCustomReward(ref float reward, Entity startStateEntity, Entity endStateEntity, NativeArray<int> arguments); // Implement this method in another file to modify the reward
    }
}
