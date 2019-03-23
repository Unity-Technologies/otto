using System;
using Unity.AI.Planner;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using Unity.Entities;

namespace WorkaholicDomain
{
    [Serializable]
    public partial struct Time : ITrait<Time>, IEquatable<Time>
    {
        public System.Int64 m_Value;

        public bool Equals(Time other)
        {
            return m_Value == other.m_Value;
        }

        public override int GetHashCode()
        {
            return 397
                ^ m_Value.GetHashCode();
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
            objectHash.TraitMask = objectHash.TraitMask | (uint)TraitMask.Time;
            entityManager.SetComponentData(domainObjectEntity, objectHash);
        }
    }
}
