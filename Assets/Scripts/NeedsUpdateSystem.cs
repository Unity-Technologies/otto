#if WORKAHOLICDOMAIN_GENERATED
using Unity.AI.Planner.DomainLanguage.TraitBased;
using Unity.Entities;

namespace WorkaholicDomain
{
    [UpdateBefore(typeof(WorkaholicDomainUpdateSystem))]
    class NeedsUpdateSystem : BaseDynamicsSystem
    {
        float m_AccumulatedTime;
        ComponentType m_NeedType = typeof(Need);

        protected override void OnStateUpdate(Entity parentStateEntity, Entity createdStateEntity)
        {
            var timeLookup = GetComponentDataFromEntity<Time>();

            var previousTime = timeLookup[parentStateEntity];
            var newStateTime = timeLookup[createdStateEntity];
            var deltaTime = newStateTime.Value - previousTime.Value;

            var objectBuffer = EntityManager.GetBuffer<DomainObjectReference>(createdStateEntity);
            for (var obj = 0; obj < objectBuffer.Length; obj++)
            {
                var domainObjectEntity = objectBuffer[obj].DomainObjectEntity;
                if (EntityManager.HasComponent(domainObjectEntity, m_NeedType))
                {
                    SetTrait((ref Need need) =>
                    {
                        var change = need.ChangePerSecond * deltaTime;
                        need.Urgency += change;
                    }, domainObjectEntity);
                }
            }
        }
    }
}
#endif
