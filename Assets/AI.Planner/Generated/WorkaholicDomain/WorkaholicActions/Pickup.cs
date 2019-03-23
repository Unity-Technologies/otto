using System.Collections.Generic;
using Unity.AI.Planner;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using Unity.Collections;
using Unity.Entities;

namespace WorkaholicDomain.WorkaholicActions
{
    public partial class Pickup : BaseAction<Pickup.Permutation>
    {
        public NativeArray<ComponentType> agentTypes { get; private set; }
        public NativeArray<ComponentType> dispenserTypes { get; private set; }
        public NativeArray<ComponentType> inventoryTypes { get; private set; }
        public NativeArray<ComponentType> timeTypes { get; private set; }

        List<(Entity, int)> m_agentEntities = new List<(Entity, int)>();
        List<(Entity, int)> m_dispenserEntities = new List<(Entity, int)>();
        List<(Entity, int)> m_inventoryEntities = new List<(Entity, int)>();
        List<(Entity, int)> m_timeEntities = new List<(Entity, int)>();

        public struct Permutation
        {
            public int agentIndex;
            public int dispenserIndex;
            public int inventoryIndex;
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
                            return dispenserIndex;

                        case 2:
                            return inventoryIndex;

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

            dispenserTypes = new NativeArray<ComponentType>(new []
            {
                ComponentType.ReadOnly<Location>(),
                ComponentType.ReadOnly<Dispenser>(),
            }, Allocator.Persistent);

            inventoryTypes = new NativeArray<ComponentType>(new []
            {
                ComponentType.ReadOnly<Inventory>(),
            }, Allocator.Persistent);

            timeTypes = new NativeArray<ComponentType>(new []
            {
                ComponentType.ReadOnly<Time>(),
            }, Allocator.Persistent);


            m_FilterTuples = new[]
            {
                (agentTypes, m_agentEntities),
                (dispenserTypes, m_dispenserEntities),
                (inventoryTypes, m_inventoryEntities),
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
            if (dispenserTypes.IsCreated)
            {
                dispenserTypes.Dispose();
                dispenserTypes = default;
            }
            if (inventoryTypes.IsCreated)
            {
                inventoryTypes.Dispose();
                inventoryTypes = default;
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
            var Dispensers = GetComponentDataFromEntity<Dispenser>(true);
            var Inventorys = GetComponentDataFromEntity<Inventory>(true);
            var Times = GetComponentDataFromEntity<Time>(true);

            FilterObjects(stateEntity);
            foreach (var (agentEntity, agentIndex) in m_agentEntities)
            {
                foreach (var (dispenserEntity, dispenserIndex) in m_dispenserEntities)
                {
                    foreach (var (inventoryEntity, inventoryIndex) in m_inventoryEntities)
                    {
                        foreach (var (timeEntity, timeIndex) in m_timeEntities)
                        {
                            if (!(Locations[agentEntity].Position == Locations[dispenserEntity].Position))
                                continue;
                            if (!(Dispensers[dispenserEntity].ConsumableType == Inventorys[inventoryEntity].ConsumableType))
                                continue;
                            if (!(Inventorys[inventoryEntity].Amount < 3))
                                continue;
                            m_ArgumentPermutations.Add(new Permutation()
                            {
                                agentIndex = agentIndex,
                                dispenserIndex = dispenserIndex,
                                inventoryIndex = inventoryIndex,
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
            var Dispensers = GetComponentDataFromEntity<Dispenser>();
            var Inventorys = GetComponentDataFromEntity<Inventory>();
            var Times = GetComponentDataFromEntity<Time>();
            var objectHashes = GetComponentDataFromEntity<HashCode>();

            var agentEntity = GetEntity(domainObjectBuffer, permutation.agentIndex, stateCopyEntity);
            var dispenserEntity = GetEntity(domainObjectBuffer, permutation.dispenserIndex, stateCopyEntity);
            var inventoryEntity = GetEntity(domainObjectBuffer, permutation.inventoryIndex, stateCopyEntity);
            var timeEntity = GetEntity(domainObjectBuffer, permutation.timeIndex, stateCopyEntity);

            {
                var @inventory = Inventorys[inventoryEntity];
                var hash = objectHashes[inventoryEntity];
                hash.Value -= @inventory.GetHashCode();
                @inventory.Amount += 1;
                Inventorys[inventoryEntity] = @inventory;
                hash.Value += @inventory.GetHashCode();
                objectHashes[inventoryEntity] = hash;
            }

            {
                var @time = Times[timeEntity];
                var hash = objectHashes[timeEntity];
                hash.Value -= @time.GetHashCode();
                @time.Value += 1;
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
            var reward = -1f;
            SetCustomReward(ref reward, startStateEntity, endStateEntity, arguments);

            return reward;
        }

        partial void SetCustomReward(ref float reward, Entity startStateEntity, Entity endStateEntity, NativeArray<int> arguments); // Implement this method in another file to modify the reward
    }
}
