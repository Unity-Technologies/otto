using System;
using Unity.AI.Planner;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using Unity.Entities;

namespace WorkaholicDomain
{
    [Serializable]
    public partial struct Need : ITrait<Need>, IEquatable<Need>
    {
        public NeedType NeedType;
        public System.Int64 Urgency;
        public System.Int64 ChangePerSecond;

        public bool Equals(Need other)
        {
            return NeedType == other.NeedType
                && Urgency == other.Urgency
                && ChangePerSecond == other.ChangePerSecond;
        }

        public override int GetHashCode()
        {
            return 397
                ^ NeedType.GetHashCode()
                ^ Urgency.GetHashCode()
                ^ ChangePerSecond.GetHashCode();
        }

        public object Clone() { return MemberwiseClone(); }

        public void SetField(string fieldName, object value)
        {
            switch (fieldName)
            {
                case nameof(NeedType):
                    NeedType = (NeedType)Enum.ToObject(typeof(NeedType), value);
                    break;
                case nameof(Urgency):
                    Urgency = (System.Int64)value;
                    break;
                case nameof(ChangePerSecond):
                    ChangePerSecond = (System.Int64)value;
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
            objectHash.TraitMask = objectHash.TraitMask | (uint)TraitMask.Need;
            entityManager.SetComponentData(domainObjectEntity, objectHash);
        }
    }
}
