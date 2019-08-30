#if PLANNER_DOMAIN_GENERATED
using System;
using AI.Planner.Domains;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using UnityEngine;

namespace AI.Planner.Actions.WorkaholicAgent
{
    public struct CustomNavigateEffects : ICustomActionEffect<StateData>, ICustomReward<StateData>
    {
        const int k_agentIndex = 0;
        const int k_toIndex = 1;
        const int k_timeIndex = 2;

        const float kWalkingSpeed = 0.47f; // m/s

        public void ApplyCustomActionEffectsToState(StateData originalState, ActionKey action, StateData newState)
        {
            // Agent location has already been updated, so use the original state for getting location data
            var domainObjectBuffer = originalState.DomainObjects;
            var agentObject = domainObjectBuffer[action[k_agentIndex]];
            var destinationObject = domainObjectBuffer[action[k_toIndex]];

            var locationBuffer = originalState.LocationBuffer;
            var agentLocation = locationBuffer[agentObject.LocationIndex];
            var destinationLocation = locationBuffer[destinationObject.LocationIndex];

            // Now update the new state's time
            var time = originalState.TimeBuffer[action[k_timeIndex]];
            var distance = Vector3.Distance(agentLocation.Position, destinationLocation.Position);
            var deltaTime = Mathf.FloorToInt(distance / kWalkingSpeed + 1f);
            time.Value += deltaTime;
            newState.TimeBuffer[action[k_timeIndex]] = time;

            new UpdateNeeds().ApplyCustomActionEffectsToState(originalState, action, newState);
        }

        public void SetCustomReward(StateData originalState, ActionKey action, StateData newState, ref float reward)
        {
            // Agent location has already been updated, so use the original state for getting location data
            var domainObjectBuffer = originalState.DomainObjects;
            var agentObject = domainObjectBuffer[action[k_agentIndex]];
            var destinationObject = domainObjectBuffer[action[k_toIndex]];

            var locationBuffer = originalState.LocationBuffer;
            var agentLocation = locationBuffer[agentObject.LocationIndex];
            var destinationLocation = locationBuffer[destinationObject.LocationIndex];

            var distance = Vector3.Distance(agentLocation.Position, destinationLocation.Position);
            reward *= distance;
        }
    }
}
#endif
