using System;
using Unity.AI.Planner;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using Unity.Entities;

namespace WorkaholicDomain
{
    [Serializable]
    public partial struct Workstation : ITrait<Workstation>, IEquatable<Workstation>
    {

        public bool Equals(Workstation other)
        {
            return true;
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode();
        }

        public object Clone() { return MemberwiseClone(); }

        public void SetField(string fieldName, object value)
        {
        }

        public void SetComponentData(EntityManager entityManager, Entity domainObjectEntity)
        {
            SetTraitMask(entityManager, domainObjectEntity);
            entityManager.SetComponentData(domainObjectEntity, this);
        }

        public void SetTraitMask(EntityManager entityManager, Entity domainObjectEntity)
        {
            var objectHash = entityManager.GetComponentData<HashCode>(domainObjectEntity);
            objectHash.TraitMask = objectHash.TraitMask | (uint)TraitMask.Workstation;
            entityManager.SetComponentData(domainObjectEntity, objectHash);
        }
    }
}
