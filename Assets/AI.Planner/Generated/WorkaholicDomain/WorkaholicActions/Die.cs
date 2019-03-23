using System;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using Unity.Collections;
using Unity.Entities;

namespace WorkaholicDomain.WorkaholicActions
{
    public class Die : IStateTermination
    {
        public string Name
        {
            get => s_Name;
            set => s_Name = value;
        }

        public NativeArray<ComponentType> ComponentTypes => m_ComponentTypes;

        protected static string s_Name = "Die";
        NativeArray<ComponentType> m_ComponentTypes;

        public Die()
        {
            m_ComponentTypes = new NativeArray<ComponentType>(new []
            {
                ComponentType.ReadOnly<Need>(),
            }, Allocator.Persistent);
        }

        public void Dispose()
        {
            if (m_ComponentTypes.IsCreated)
            {
                m_ComponentTypes.Dispose();
                m_ComponentTypes = default;
            }
        }

        public bool ShouldTerminate(EntityManager entityManager, Entity domainObjectEntity)
        {
            return entityManager.GetComponentData<Need>(domainObjectEntity).Urgency >= 100;
        }
    }
}
