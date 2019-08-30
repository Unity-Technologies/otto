#if PLANNER_ACTIONS_GENERATED
using System;
using AI.Planner.Domains;
using AI.Planner.Domains.Enums;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using Unity.Collections;
using Unity.Entities;
using Workaholic;
using UnityEngine;

public class SleepAction : OttoAction
{
    public override void BeginExecution(StateData state, ActionKey action, Otto actor)
    {
        base.BeginExecution(state, action, actor);

        m_Animator = actor.GetComponentInParent<Animator>();
        m_Animator.SetTrigger(Animator.StringToHash("Sleep"));

        // Reset fatigue
        var domainObjects = new NativeList<(DomainObject, int)>(4, Allocator.TempJob);
        foreach (var (_, domainObjectIndex) in state.GetDomainObjects(domainObjects, new ComponentType[] {typeof(Need)}))
        {
            var need = state.GetTraitOnObjectAtIndex<Need>(domainObjectIndex);
            if (need.NeedType == NeedType.Fatigue)
            {
                need.Urgency = 0;
                state.SetTraitOnObjectAtIndex(need, domainObjectIndex);
                break;
            }
        }
        domainObjects.Dispose();
    }
}
#endif
