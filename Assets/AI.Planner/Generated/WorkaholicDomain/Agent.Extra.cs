using System;
using Unity.AI.Planner;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using Unity.Entities;

namespace WorkaholicDomain
{
    [Serializable]
    public partial struct Agent : ITrait<Agent>, IEquatable<Agent>
    {

        public bool Equals(Agent other)
        {
            return true;
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode();
        }

        public object Clone() { return MemberwiseClone(); }
        public void SetComponentData(EntityManager entityManager, Entity domainObjectEntity)
        {
            SetTraitMask(entityManager, domainObjectEntity);
            entityManager.SetComponentData(domainObjectEntity, this);
        }

        public void SetTraitMask(EntityManager entityManager, Entity domainObjectEntity)
        {
            var objectHash = entityManager.GetComponentData<HashCode>(domainObjectEntity);
            objectHash.TraitMask = objectHash.TraitMask | (uint)TraitMask.Agent;
            entityManager.SetComponentData(domainObjectEntity, objectHash);
        }
    }
}
