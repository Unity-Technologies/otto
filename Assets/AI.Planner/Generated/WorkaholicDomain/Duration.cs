using System;
using Unity.AI.Planner;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using Unity.Entities;

namespace WorkaholicDomain
{
    [Serializable]
    public partial struct Duration : ITrait<Duration>, IEquatable<Duration>
    {
        public System.Int64 Time;

        public bool Equals(Duration other)
        {
            return Time == other.Time;
        }

        public override int GetHashCode()
        {
            return 397
                ^ Time.GetHashCode();
        }

        public object Clone() { return MemberwiseClone(); }

        public void SetField(string fieldName, object value)
        {
            switch (fieldName)
            {
                case nameof(Time):
                    Time = (System.Int64)value;
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
            objectHash.TraitMask = objectHash.TraitMask | (uint)TraitMask.Duration;
            entityManager.SetComponentData(domainObjectEntity, objectHash);
        }
    }
}
