using System;
using System.Collections.Generic;
using Unity.AI.Planner;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using Unity.Entities;

namespace WorkaholicDomain
{
    [Flags]
    public enum TraitMask : uint  // Can change enum backing depending on number of traits.
    {
        None = 0,
        Workstation = 1,
        Bed = 2,
        Dispenser = 4,
        Inventory = 8,
        Need = 16,
        Time = 32,
        Agent = 64,
        Duration = 128,
        Location = 2147483648,
    }

    public static class TraitMaskUtility
    {
        public static uint GetTraitMask(params Type[] traitFilter)
        {
            var traitMask = TraitMask.None;
            foreach (var trait in traitFilter)
            {
                switch (trait.Name)
                {
                    case nameof(Workstation):
                        traitMask |= TraitMask.Workstation;
                        break;

                    case nameof(Bed):
                        traitMask |= TraitMask.Bed;
                        break;

                    case nameof(Dispenser):
                        traitMask |= TraitMask.Dispenser;
                        break;

                    case nameof(Inventory):
                        traitMask |= TraitMask.Inventory;
                        break;

                    case nameof(Need):
                        traitMask |= TraitMask.Need;
                        break;

                    case nameof(Time):
                        traitMask |= TraitMask.Time;
                        break;

                    case nameof(Agent):
                        traitMask |= TraitMask.Agent;
                        break;

                    case nameof(Duration):
                        traitMask |= TraitMask.Duration;
                        break;

                    case nameof(Location):
                        traitMask |= TraitMask.Location;
                        break;

                }
            }

            return (uint)traitMask;
        }
    }

    public class WorkaholicDomainUpdateSystem : PolicyGraphUpdateSystem
    {
        List<Entity> m_EntityListLHS = new List<Entity>();
        List<Entity> m_EntityListRHS = new List<Entity>();

        ComponentType WorkstationTrait;
        ComponentType BedTrait;
        ComponentType DispenserTrait;
        ComponentType InventoryTrait;
        ComponentType NeedTrait;
        ComponentType TimeTrait;
        ComponentType AgentTrait;
        ComponentType DurationTrait;
        ComponentType LocationTrait;

        bool zeroSizedWorkstation;
        bool zeroSizedBed;
        bool zeroSizedDispenser;
        bool zeroSizedInventory;
        bool zeroSizedNeed;
        bool zeroSizedTime;
        bool zeroSizedAgent;
        bool zeroSizedDuration;
        bool zeroSizedLocation;

        protected override void OnCreateManager()
        {
            base.OnCreateManager();

            WorkstationTrait = ComponentType.ReadWrite<Workstation>();
            BedTrait = ComponentType.ReadWrite<Bed>();
            DispenserTrait = ComponentType.ReadWrite<Dispenser>();
            InventoryTrait = ComponentType.ReadWrite<Inventory>();
            NeedTrait = ComponentType.ReadWrite<Need>();
            TimeTrait = ComponentType.ReadWrite<Time>();
            AgentTrait = ComponentType.ReadWrite<Agent>();
            DurationTrait = ComponentType.ReadWrite<Duration>();
            LocationTrait = ComponentType.ReadWrite<Location>();

            zeroSizedWorkstation = WorkstationTrait.IsZeroSized;
            zeroSizedBed = BedTrait.IsZeroSized;
            zeroSizedDispenser = DispenserTrait.IsZeroSized;
            zeroSizedInventory = InventoryTrait.IsZeroSized;
            zeroSizedNeed = NeedTrait.IsZeroSized;
            zeroSizedTime = TimeTrait.IsZeroSized;
            zeroSizedAgent = AgentTrait.IsZeroSized;
            zeroSizedDuration = DurationTrait.IsZeroSized;
            zeroSizedLocation = LocationTrait.IsZeroSized;
        }

        internal override HashCode HashState(Entity stateEntity)
        {
            var domainObjectBuffer = EntityManager.GetBuffer<DomainObjectReference>(stateEntity);
            var domainObjectHashCodes = GetComponentDataFromEntity<HashCode>();
            
            // h = 3860031 + (h+y)*2779 + (h*y*2)   // from How to Hash a Set by Richard O’Keefe
            var stateHashValue = 0;

            for (var i = 0; i < domainObjectBuffer.Length; i++)
            {
                var objHash = domainObjectHashCodes[domainObjectBuffer[i].DomainObjectEntity].Value;
                stateHashValue = 3860031 + (stateHashValue + objHash) * 2779 + (stateHashValue * objHash * 2);
            }

            var stateHashCode = domainObjectHashCodes[stateEntity];
            var traitMask = (TraitMask) stateHashCode.TraitMask;

            if ((traitMask & TraitMask.Workstation) != 0)
            {
                var traitHash = EntityManager.GetComponentData<Workstation>(stateEntity).GetHashCode();
                stateHashValue = 3860031 + (stateHashValue + traitHash) * 2779 + (stateHashValue * traitHash * 2);
            }
            if ((traitMask & TraitMask.Bed) != 0)
            {
                var traitHash = EntityManager.GetComponentData<Bed>(stateEntity).GetHashCode();
                stateHashValue = 3860031 + (stateHashValue + traitHash) * 2779 + (stateHashValue * traitHash * 2);
            }
            if ((traitMask & TraitMask.Dispenser) != 0)
            {
                var traitHash = EntityManager.GetComponentData<Dispenser>(stateEntity).GetHashCode();
                stateHashValue = 3860031 + (stateHashValue + traitHash) * 2779 + (stateHashValue * traitHash * 2);
            }
            if ((traitMask & TraitMask.Inventory) != 0)
            {
                var traitHash = EntityManager.GetComponentData<Inventory>(stateEntity).GetHashCode();
                stateHashValue = 3860031 + (stateHashValue + traitHash) * 2779 + (stateHashValue * traitHash * 2);
            }
            if ((traitMask & TraitMask.Need) != 0)
            {
                var traitHash = EntityManager.GetComponentData<Need>(stateEntity).GetHashCode();
                stateHashValue = 3860031 + (stateHashValue + traitHash) * 2779 + (stateHashValue * traitHash * 2);
            }
            if ((traitMask & TraitMask.Time) != 0)
            {
                var traitHash = EntityManager.GetComponentData<Time>(stateEntity).GetHashCode();
                stateHashValue = 3860031 + (stateHashValue + traitHash) * 2779 + (stateHashValue * traitHash * 2);
            }
            if ((traitMask & TraitMask.Agent) != 0)
            {
                var traitHash = EntityManager.GetComponentData<Agent>(stateEntity).GetHashCode();
                stateHashValue = 3860031 + (stateHashValue + traitHash) * 2779 + (stateHashValue * traitHash * 2);
            }
            if ((traitMask & TraitMask.Duration) != 0)
            {
                var traitHash = EntityManager.GetComponentData<Duration>(stateEntity).GetHashCode();
                stateHashValue = 3860031 + (stateHashValue + traitHash) * 2779 + (stateHashValue * traitHash * 2);
            }
            if ((traitMask & TraitMask.Location) != 0)
            {
                var traitHash = EntityManager.GetComponentData<Location>(stateEntity).GetHashCode();
                stateHashValue = 3860031 + (stateHashValue + traitHash) * 2779 + (stateHashValue * traitHash * 2);
            }

            stateHashCode.Value = stateHashValue;
            return stateHashCode;
        }

        protected override bool StateEquals(Entity lhsStateEntity, Entity rhsStateEntity)
        {
            m_EntityListLHS.Clear();
            m_EntityListRHS.Clear();

            // Easy check is to make sure each state has the same number of domain objects
            var lhsObjectBuffer = EntityManager.GetBuffer<DomainObjectReference>(lhsStateEntity);
            var rhsObjectBuffer = EntityManager.GetBuffer<DomainObjectReference>(rhsStateEntity);
            if (lhsObjectBuffer.Length != rhsObjectBuffer.Length)
            {
                return false;
            }

            for (var i = 0; i < lhsObjectBuffer.Length; i++)
            {
                m_EntityListLHS.Add(lhsObjectBuffer[i].DomainObjectEntity);
                m_EntityListRHS.Add(rhsObjectBuffer[i].DomainObjectEntity);
            }

            // Next, check that each object has at least one match (by hash/checksum/trait mask)
            var entityHashCodes = GetComponentDataFromEntity<HashCode>();
            var lhsHashCode = entityHashCodes[lhsStateEntity];
            var rhsHashCode = entityHashCodes[rhsStateEntity];
            if (lhsHashCode != rhsHashCode)
            {
                return false;
            }

            for (var index = 0; index < m_EntityListLHS.Count; index++)
            {
                var entityLHS = m_EntityListLHS[index];

                // Check for any objects with matching hash code.
                var hashLHS = entityHashCodes[entityLHS];
                var foundMatch = false;
                for (var rhsIndex = 0; rhsIndex < m_EntityListRHS.Count; rhsIndex++)
                {
                    var entityRHS = m_EntityListRHS[rhsIndex];
                    if (hashLHS == entityHashCodes[entityRHS])
                    {
                        foundMatch = true;
                        break;
                    }
                }

                // No matching object found.
                if (!foundMatch)
                {
                    return false;
                }
            }

            var Workstations = GetComponentDataFromEntity<Workstation>(true);
            var Beds = GetComponentDataFromEntity<Bed>(true);
            var Dispensers = GetComponentDataFromEntity<Dispenser>(true);
            var Inventorys = GetComponentDataFromEntity<Inventory>(true);
            var Needs = GetComponentDataFromEntity<Need>(true);
            var Times = GetComponentDataFromEntity<Time>(true);
            var Agents = GetComponentDataFromEntity<Agent>(true);
            var Durations = GetComponentDataFromEntity<Duration>(true);
            var Locations = GetComponentDataFromEntity<Location>(true);

            while (m_EntityListLHS.Count > 0)
            {
                var entityLHS = m_EntityListLHS[0];

                // Check for any objects with matching hash code.
                var hashLHS = entityHashCodes[entityLHS];
                var firstMatchIndex = -1;
                for (var rhsIndex = 0; rhsIndex < m_EntityListRHS.Count; rhsIndex++)
                {
                    var entityRHS = m_EntityListRHS[rhsIndex];
                    if (hashLHS == entityHashCodes[entityRHS])
                    {
                        firstMatchIndex = rhsIndex;
                        break;
                    }
                }
                if (firstMatchIndex == -1)
                {
                    return false;
                }

                var traitMask = (TraitMask)hashLHS.TraitMask;

                var hasWorkstation = (traitMask & TraitMask.Workstation) != 0;
                var hasBed = (traitMask & TraitMask.Bed) != 0;
                var hasDispenser = (traitMask & TraitMask.Dispenser) != 0;
                var hasInventory = (traitMask & TraitMask.Inventory) != 0;
                var hasNeed = (traitMask & TraitMask.Need) != 0;
                var hasTime = (traitMask & TraitMask.Time) != 0;
                var hasAgent = (traitMask & TraitMask.Agent) != 0;
                var hasDuration = (traitMask & TraitMask.Duration) != 0;
                var hasLocation = (traitMask & TraitMask.Location) != 0;

                var foundMatch = false;
                for (var rhsIndex = firstMatchIndex; rhsIndex < m_EntityListRHS.Count; rhsIndex++)
                {
                    var entityRHS = m_EntityListRHS[rhsIndex];
                    if (hashLHS != entityHashCodes[entityRHS])
                    {
                        continue;
                    }

                    if (hasWorkstation && !zeroSizedWorkstation && !Workstations[entityLHS].Equals(Workstations[entityRHS]))
                    {
                        continue;
                    }
                    if (hasBed && !zeroSizedBed && !Beds[entityLHS].Equals(Beds[entityRHS]))
                    {
                        continue;
                    }
                    if (hasDispenser && !zeroSizedDispenser && !Dispensers[entityLHS].Equals(Dispensers[entityRHS]))
                    {
                        continue;
                    }
                    if (hasInventory && !zeroSizedInventory && !Inventorys[entityLHS].Equals(Inventorys[entityRHS]))
                    {
                        continue;
                    }
                    if (hasNeed && !zeroSizedNeed && !Needs[entityLHS].Equals(Needs[entityRHS]))
                    {
                        continue;
                    }
                    if (hasTime && !zeroSizedTime && !Times[entityLHS].Equals(Times[entityRHS]))
                    {
                        continue;
                    }
                    if (hasAgent && !zeroSizedAgent && !Agents[entityLHS].Equals(Agents[entityRHS]))
                    {
                        continue;
                    }
                    if (hasDuration && !zeroSizedDuration && !Durations[entityLHS].Equals(Durations[entityRHS]))
                    {
                        continue;
                    }
                    if (hasLocation && !zeroSizedLocation && !Locations[entityLHS].Equals(Locations[entityRHS]))
                    {
                        continue;
                    }

                    m_EntityListLHS.RemoveAt(0);
                    m_EntityListRHS.RemoveAt(rhsIndex);
                    foundMatch = true;
                    break;
                }

                if (!foundMatch)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
