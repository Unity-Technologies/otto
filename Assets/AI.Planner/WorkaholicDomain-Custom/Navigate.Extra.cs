#if WORKAHOLICACTIONS_GENERATED
using System;
using Unity.AI.Planner;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace WorkaholicDomain.WorkaholicActions
{
    public partial class Navigate
    {
        const float kWalkingSpeed = 0.47f; // m/s

        partial void ApplyCustomActionEffectsToState(Entity stateEntity, Entity originalStateEntity, NativeArray<int> arguments)
        {
            // Agent location has already been updated, so use the original state for getting location data
            var domainObjectBuffer = EntityManager.GetBuffer<DomainObjectReference>(originalStateEntity);

            var agentEntity = domainObjectBuffer[arguments[0]].DomainObjectEntity;
            var destinationEntity = domainObjectBuffer[arguments[1]].DomainObjectEntity;

            var agentLocation = EntityManager.GetComponentData<Location>(agentEntity);
            var destinationLocation = EntityManager.GetComponentData<Location>(destinationEntity);

            // Now update the new state's time
            var distance = Vector3.Distance(agentLocation.Position, destinationLocation.Position);
            var deltaTime = Mathf.FloorToInt(distance / kWalkingSpeed + 1f);

            SetTrait((ref Time time) => time.Value += deltaTime, stateEntity);
        }

        partial void SetCustomReward(ref float reward, Entity startStateEntity, Entity endStateEntity, NativeArray<int> arguments)
        {
            // Agent location has already been updated, so use the original state for getting location data
            var domainObjectBuffer = EntityManager.GetBuffer<DomainObjectReference>(startStateEntity);

            var agentEntity = domainObjectBuffer[arguments[0]].DomainObjectEntity;
            var destinationEntity = domainObjectBuffer[arguments[1]].DomainObjectEntity;

            var agentLocation = EntityManager.GetComponentData<Location>(agentEntity);
            var destinationLocation = EntityManager.GetComponentData<Location>(destinationEntity);

            var distance = Vector3.Distance(agentLocation.Position, destinationLocation.Position);
            reward *= distance;
        }
    }
}
#endif
