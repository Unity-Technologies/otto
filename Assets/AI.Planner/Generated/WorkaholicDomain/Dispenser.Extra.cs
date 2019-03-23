using System;
using Unity.AI.Planner;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using Unity.Entities;

namespace WorkaholicDomain
{
    [Serializable]
    public partial struct Dispenser : ITrait<Dispenser>, IEquatable<Dispenser>
    {
        public ConsumableType m_ConsumableType;

        public bool Equals(Dispenser other)
        {
            return m_ConsumableType == other.m_ConsumableType;
        }

        public override int GetHashCode()
        {
            return 397
                ^ m_ConsumableType.GetHashCode();
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
            objectHash.TraitMask = objectHash.TraitMask | (uint)TraitMask.Dispenser;
            entityManager.SetComponentData(domainObjectEntity, objectHash);
        }
    }
}
