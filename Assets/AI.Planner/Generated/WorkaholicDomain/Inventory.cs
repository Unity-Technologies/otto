using System;
using Unity.AI.Planner;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using Unity.Entities;

namespace WorkaholicDomain
{
    [Serializable]
    public partial struct Inventory : ITrait<Inventory>, IEquatable<Inventory>
    {
        public ConsumableType ConsumableType;
        public System.Int64 Amount;
        public NeedType SatisfiesNeed;
        public System.Int64 NeedReduction;

        public bool Equals(Inventory other)
        {
            return ConsumableType == other.ConsumableType
                && Amount == other.Amount
                && SatisfiesNeed == other.SatisfiesNeed
                && NeedReduction == other.NeedReduction;
        }

        public override int GetHashCode()
        {
            return 397
                ^ ConsumableType.GetHashCode()
                ^ Amount.GetHashCode()
                ^ SatisfiesNeed.GetHashCode()
                ^ NeedReduction.GetHashCode();
        }

        public object Clone() { return MemberwiseClone(); }

        public void SetField(string fieldName, object value)
        {
            switch (fieldName)
            {
                case nameof(ConsumableType):
                    ConsumableType = (ConsumableType)Enum.ToObject(typeof(ConsumableType), value);
                    break;
                case nameof(Amount):
                    Amount = (System.Int64)value;
                    break;
                case nameof(SatisfiesNeed):
                    SatisfiesNeed = (NeedType)Enum.ToObject(typeof(NeedType), value);
                    break;
                case nameof(NeedReduction):
                    NeedReduction = (System.Int64)value;
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
            objectHash.TraitMask = objectHash.TraitMask | (uint)TraitMask.Inventory;
            entityManager.SetComponentData(domainObjectEntity, objectHash);
        }
    }
}
