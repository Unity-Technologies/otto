using System;
using Unity.AI.Planner;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using Unity.Entities;

namespace WorkaholicDomain
{
    [Serializable]
    public partial struct Need : ITrait<Need>, IEquatable<Need>
    {
        public NeedType m_NeedType;
        public System.Int64 m_Urgency;
        public System.Int64 m_ChangePerSecond;

        public bool Equals(Need other)
        {
            return m_NeedType == other.m_NeedType
                && m_Urgency == other.m_Urgency
                && m_ChangePerSecond == other.m_ChangePerSecond;
        }

        public override int GetHashCode()
        {
            return 397
                ^ m_NeedType.GetHashCode()
                ^ m_Urgency.GetHashCode()
                ^ m_ChangePerSecond.GetHashCode();
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
            objectHash.TraitMask = objectHash.TraitMask | (uint)TraitMask.Need;
            entityManager.SetComponentData(domainObjectEntity, objectHash);
        }
    }
}
