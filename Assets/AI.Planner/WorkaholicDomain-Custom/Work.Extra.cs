#if WORKAHOLICACTIONS_GENERATED
using System;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using Unity.Collections;
using Unity.Entities;

namespace WorkaholicDomain.WorkaholicActions
{
    public partial class Work
    {
        partial void SetCustomReward(ref float reward, Entity startStateEntity, Entity endStateEntity, NativeArray<int> arguments)
        {
            // Agent location has already been updated, so use the original state for getting location data
            var domainObjectBuffer = EntityManager.GetBuffer<DomainObjectReference>(startStateEntity);

            var durationEntity = domainObjectBuffer[arguments[2]].DomainObjectEntity;
            var duration = EntityManager.GetComponentData<Duration>(durationEntity).Time;

            reward *= duration;
        }
    }
}
#endif
