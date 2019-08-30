#if PLANNER_ACTIONS_GENERATED
using System;
using AI.Planner.Domains;
using AI.Planner.Domains.Enums;
using Unity.AI.Planner.Agent;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using Workaholic;
using UnityEngine;
using Time = UnityEngine.Time;

public class WorkAction : OttoAction
{
    static readonly int k_Work = Animator.StringToHash("Work");
    float m_Duration;
    const float k_ExitTime = 0.667f;
    static readonly int s_ContinueWork = Animator.StringToHash("ContinueWork");

    public override void BeginExecution(StateData state, ActionKey action, Otto actor)
    {
        base.BeginExecution(state, action, actor);

        m_StartTime = Time.time;

        m_Duration = state.GetTraitOnObjectAtIndex<Duration>(action[2]).Time;

        m_Animator.SetTrigger(k_Work);
        m_Animator.SetBool(s_ContinueWork, true);
    }

    public override void ContinueExecution(StateData state, ActionKey action, Otto actor)
    {
        base.ContinueExecution(state, action, actor);

        if (Time.time - m_StartTime >= m_Duration - k_ExitTime)
            m_Animator.SetBool(s_ContinueWork, false);
    }

    public override OperationalActionStatus Status(StateData state, ActionKey action, Otto actor)
    {
        return Time.time - m_StartTime >= m_Duration ?
            OperationalActionStatus.Completed :
            OperationalActionStatus.InProgress;
    }
}
#endif
