using System;
using Unity.AI.Planner;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using Unity.Entities;

namespace WorkaholicDomain
{
    [Serializable]
    public partial struct Duration : ITrait<Duration>, IEquatable<Duration>
    {
        public System.Int64 m_Time;

        public bool Equals(Duration other)
        {
            return m_Time == other.m_Time;
        }

        public override int GetHashCode()
        {
            return 397
                ^ m_Time.GetHashCode();
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
            objectHash.TraitMask = objectHash.TraitMask | (uint)TraitMask.Duration;
            entityManager.SetComponentData(domainObjectEntity, objectHash);
        }
    }
}
