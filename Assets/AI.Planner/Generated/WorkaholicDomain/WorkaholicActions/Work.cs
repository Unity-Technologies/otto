using System.Collections.Generic;
using Unity.AI.Planner;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using Unity.Collections;
using Unity.Entities;

namespace WorkaholicDomain.WorkaholicActions
{
    public partial class Work : BaseAction<Work.Permutation>
    {
        public NativeArray<ComponentType> agentTypes { get; private set; }
        public NativeArray<ComponentType> workstationTypes { get; private set; }
        public NativeArray<ComponentType> durationTypes { get; private set; }
        public NativeArray<ComponentType> timeTypes { get; private set; }

        List<(Entity, int)> m_agentEntities = new List<(Entity, int)>();
        List<(Entity, int)> m_workstationEntities = new List<(Entity, int)>();
        List<(Entity, int)> m_durationEntities = new List<(Entity, int)>();
        List<(Entity, int)> m_timeEntities = new List<(Entity, int)>();

        public struct Permutation
        {
            public int agentIndex;
            public int workstationIndex;
            public int durationIndex;
            public int timeIndex;
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
                            return workstationIndex;

                        case 2:
                            return durationIndex;

                        case 3:
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

            workstationTypes = new NativeArray<ComponentType>(new []
            {
                ComponentType.ReadOnly<Workstation>(),
                ComponentType.ReadOnly<Location>(),
            }, Allocator.Persistent);

            durationTypes = new NativeArray<ComponentType>(new []
            {
                ComponentType.ReadOnly<Duration>(),
            }, Allocator.Persistent);

            timeTypes = new NativeArray<ComponentType>(new []
            {
                ComponentType.ReadOnly<Time>(),
            }, Allocator.Persistent);


            m_FilterTuples = new[]
            {
                (agentTypes, m_agentEntities),
                (workstationTypes, m_workstationEntities),
                (durationTypes, m_durationEntities),
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
            if (workstationTypes.IsCreated)
            {
                workstationTypes.Dispose();
                workstationTypes = default;
            }
            if (durationTypes.IsCreated)
            {
                durationTypes.Dispose();
                durationTypes = default;
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
            var Durations = GetComponentDataFromEntity<Duration>(true);
            var Times = GetComponentDataFromEntity<Time>(true);

            FilterObjects(stateEntity);
            foreach (var (agentEntity, agentIndex) in m_agentEntities)
            {
                foreach (var (workstationEntity, workstationIndex) in m_workstationEntities)
                {
                    foreach (var (durationEntity, durationIndex) in m_durationEntities)
                    {
                        foreach (var (timeEntity, timeIndex) in m_timeEntities)
                        {
                            if (!(Locations[agentEntity].Position == Locations[workstationEntity].Position))
                                continue;
                            m_ArgumentPermutations.Add(new Permutation()
                            {
                                agentIndex = agentIndex,
                                workstationIndex = workstationIndex,
                                durationIndex = durationIndex,
                                timeIndex = timeIndex,
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
            var Durations = GetComponentDataFromEntity<Duration>();
            var Times = GetComponentDataFromEntity<Time>();
            var objectHashes = GetComponentDataFromEntity<HashCode>();

            var agentEntity = GetEntity(domainObjectBuffer, permutation.agentIndex, stateCopyEntity);
            var workstationEntity = GetEntity(domainObjectBuffer, permutation.workstationIndex, stateCopyEntity);
            var durationEntity = GetEntity(domainObjectBuffer, permutation.durationIndex, stateCopyEntity);
            var timeEntity = GetEntity(domainObjectBuffer, permutation.timeIndex, stateCopyEntity);
            
            {
                var @time = Times[timeEntity];
                var hash = objectHashes[timeEntity];
                hash.Value -= @time.GetHashCode();
                @time.Value += Durations[durationEntity].Time;
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
            var reward = 1f;
            SetCustomReward(ref reward, startStateEntity, endStateEntity, arguments);

            return reward;
        }

        partial void SetCustomReward(ref float reward, Entity startStateEntity, Entity endStateEntity, NativeArray<int> arguments); // Implement this method in another file to modify the reward
    }
}
