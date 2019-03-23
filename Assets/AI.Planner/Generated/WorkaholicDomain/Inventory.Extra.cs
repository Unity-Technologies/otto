using System;
using Unity.AI.Planner;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using Unity.Entities;

namespace WorkaholicDomain
{
    [Serializable]
    public partial struct Inventory : ITrait<Inventory>, IEquatable<Inventory>
    {
        public ConsumableType m_ConsumableType;
        public System.Int64 m_Amount;
        public NeedType m_SatisfiesNeed;
        public System.Int64 m_NeedReduction;

        public bool Equals(Inventory other)
        {
            return m_ConsumableType == other.m_ConsumableType
                && m_Amount == other.m_Amount
                && m_SatisfiesNeed == other.m_SatisfiesNeed
                && m_NeedReduction == other.m_NeedReduction;
        }

        public override int GetHashCode()
        {
            return 397
                ^ m_ConsumableType.GetHashCode()
                ^ m_Amount.GetHashCode()
                ^ m_SatisfiesNeed.GetHashCode()
                ^ m_NeedReduction.GetHashCode();
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
            objectHash.TraitMask = objectHash.TraitMask | (uint)TraitMask.Inventory;
            entityManager.SetComponentData(domainObjectEntity, objectHash);
        }
    }
}
