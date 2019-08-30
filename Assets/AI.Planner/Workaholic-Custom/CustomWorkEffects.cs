#if PLANNER_DOMAIN_GENERATED
using System;
using AI.Planner.Domains;
using Unity.AI.Planner.DomainLanguage.TraitBased;

namespace AI.Planner.Actions.WorkaholicAgent
{
    public struct CustomWorkEffects : ICustomActionEffect<StateData>, ICustomReward<StateData>
    {
        public void ApplyCustomActionEffectsToState(StateData originalState, ActionKey action, StateData newState)
        {
            new UpdateNeeds().ApplyCustomActionEffectsToState(originalState, action, newState);
        }

        public void SetCustomReward(StateData originalState, ActionKey action, StateData newState, ref float reward)
        {
            var domainObjectBuffer = originalState.DomainObjects;
            var durationObject = domainObjectBuffer[action[2]];
            var duration = originalState.DurationBuffer[durationObject.DurationIndex].Time;

            reward *= duration;
        }
    }
}
#endif
