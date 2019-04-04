using System.Collections.Generic;
using Unity.AI.Planner;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using Unity.Collections;
using Unity.Entities;

namespace WorkaholicDomain.WorkaholicActions
{
    public partial class Sleep : BaseAction<Sleep.Permutation>
    {
        public NativeArray<ComponentType> agentTypes { get; private set; }
        public NativeArray<ComponentType> bedTypes { get; private set; }
        public NativeArray<ComponentType> timeTypes { get; private set; }
        public NativeArray<ComponentType> fatigueTypes { get; private set; }

        List<(Entity, int)> m_agentEntities = new List<(Entity, int)>();
        List<(Entity, int)> m_bedEntities = new List<(Entity, int)>();
        List<(Entity, int)> m_timeEntities = new List<(Entity, int)>();
        List<(Entity, int)> m_fatigueEntities = new List<(Entity, int)>();

        public struct Permutation
        {
            public int agentIndex;
            public int bedIndex;
            public int timeIndex;
            public int fatigueIndex;
            public int Length => 4;

            public int this[int i]
            {
                get
                {
                    switch(i)
                    {
                        case 0:
                            return agentIndex;

                        case 1:
                            return bedIndex;

                        case 2:
                            return timeIndex;

                        case 3:
                            return fatigueIndex;

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

            bedTypes = new NativeArray<ComponentType>(new []
            {
                ComponentType.ReadOnly<Location>(),
                ComponentType.ReadOnly<Bed>(),
            }, Allocator.Persistent);

            timeTypes = new NativeArray<ComponentType>(new []
            {
                ComponentType.ReadOnly<Time>(),
            }, Allocator.Persistent);

            fatigueTypes = new NativeArray<ComponentType>(new []
            {
                ComponentType.ReadOnly<Need>(),
            }, Allocator.Persistent);


            m_FilterTuples = new[]
            {
                (agentTypes, m_agentEntities),
                (bedTypes, m_bedEntities),
                (timeTypes, m_timeEntities),
                (fatigueTypes, m_fatigueEntities),
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
            if (bedTypes.IsCreated)
            {
                bedTypes.Dispose();
                bedTypes = default;
            }
            if (timeTypes.IsCreated)
            {
                timeTypes.Dispose();
                timeTypes = default;
            }
            if (fatigueTypes.IsCreated)
            {
                fatigueTypes.Dispose();
                fatigueTypes = default;
            }
        }

        protected override void GenerateArgumentPermutations(Entity stateEntity)
        {
            var DomainObjects = GetComponentDataFromEntity<DomainObjectTrait>(true);
            var Locations = GetComponentDataFromEntity<Location>(true);
            var Times = GetComponentDataFromEntity<Time>(true);
            var Needs = GetComponentDataFromEntity<Need>(true);

            FilterObjects(stateEntity);
            foreach (var (agentEntity, agentIndex) in m_agentEntities)
            {
                foreach (var (bedEntity, bedIndex) in m_bedEntities)
                {
                    foreach (var (timeEntity, timeIndex) in m_timeEntities)
                    {
                        foreach (var (fatigueEntity, fatigueIndex) in m_fatigueEntities)
                        {
                            if (!(Locations[agentEntity].Position == Locations[bedEntity].Position))
                                continue;
                            if (!(Needs[fatigueEntity].NeedType == NeedType.Fatigue))
                                continue;
                            m_ArgumentPermutations.Add(new Permutation()
                            {
                                agentIndex = agentIndex,
                                bedIndex = bedIndex,
                                timeIndex = timeIndex,
                                fatigueIndex = fatigueIndex,
                            });
                        }
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
            var Needs = GetComponentDataFromEntity<Need>();
            var objectHashes = GetComponentDataFromEntity<HashCode>();

            var agentEntity = GetEntity(domainObjectBuffer, permutation.agentIndex, stateCopyEntity);
            var bedEntity = GetEntity(domainObjectBuffer, permutation.bedIndex, stateCopyEntity);
            var timeEntity = GetEntity(domainObjectBuffer, permutation.timeIndex, stateCopyEntity);
            var fatigueEntity = GetEntity(domainObjectBuffer, permutation.fatigueIndex, stateCopyEntity);
            
            {
                var @fatigue = Needs[fatigueEntity];
                var hash = objectHashes[fatigueEntity];
                hash.Value -= @fatigue.GetHashCode();
                @fatigue.Urgency = 0;
                Needs[fatigueEntity] = @fatigue;
                hash.Value += @fatigue.GetHashCode();
                objectHashes[fatigueEntity] = hash;
            }
            
            {
                var @time = Times[timeEntity];
                var hash = objectHashes[timeEntity];
                hash.Value -= @time.GetHashCode();
                @time.Value += 7;
                Times[timeEntity] = @time;
                hash.Value += @time.GetHashCode();
                objectHashes[timeEntity] = hash;
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
            var reward = -3f;
            SetCustomReward(ref reward, startStateEntity, endStateEntity, arguments);

            return reward;
        }

        partial void SetCustomReward(ref float reward, Entity startStateEntity, Entity endStateEntity, NativeArray<int> arguments); // Implement this method in another file to modify the reward
    }
}
