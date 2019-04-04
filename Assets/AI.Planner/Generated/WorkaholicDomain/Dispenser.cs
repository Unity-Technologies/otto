using System;
using Unity.AI.Planner;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using Unity.Entities;

namespace WorkaholicDomain
{
    [Serializable]
    public partial struct Dispenser : ITrait<Dispenser>, IEquatable<Dispenser>
    {
        public ConsumableType ConsumableType;

        public bool Equals(Dispenser other)
        {
            return ConsumableType == other.ConsumableType;
        }

        public override int GetHashCode()
        {
            return 397
                ^ ConsumableType.GetHashCode();
        }

        public object Clone() { return MemberwiseClone(); }

        public void SetField(string fieldName, object value)
        {
            switch (fieldName)
            {
                case nameof(ConsumableType):
                    ConsumableType = (ConsumableType)Enum.ToObject(typeof(ConsumableType), value);
                    break;
            }
        }

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
