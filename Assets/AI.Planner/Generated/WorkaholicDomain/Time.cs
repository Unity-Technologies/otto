using System;
using Unity.AI.Planner;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using Unity.Entities;

namespace WorkaholicDomain
{
    [Serializable]
    public partial struct Time : ITrait<Time>, IEquatable<Time>
    {
        public System.Int64 Value;

        public bool Equals(Time other)
        {
            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return 397
                ^ Value.GetHashCode();
        }

        public object Clone() { return MemberwiseClone(); }

        public void SetField(string fieldName, object value)
        {
            switch (fieldName)
            {
                case nameof(Value):
                    Value = (System.Int64)value;
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
            objectHash.TraitMask = objectHash.TraitMask | (uint)TraitMask.Time;
            entityManager.SetComponentData(domainObjectEntity, objectHash);
        }
    }
}
