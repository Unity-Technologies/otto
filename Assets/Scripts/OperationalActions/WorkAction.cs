#if WORKAHOLICDOMAIN_GENERATED
using System;
using Unity.AI.Planner;
using Unity.AI.Planner.Agent;
using Unity.Entities;
using UnityEngine;
using Workaholic;
using WorkaholicDomain;
using Time = UnityEngine.Time;

public class WorkAction : OttoAction
{
    static readonly int k_Work = Animator.StringToHash("Work");
    float m_Duration;
    const float k_ExitTime = 0.667f;
    static readonly int s_ContinueWork = Animator.StringToHash("ContinueWork");

    public override void BeginExecution(Entity stateEntity, ActionContext action, Otto actor)
    {
        base.BeginExecution(stateEntity, action, actor);

        m_StartTime = Time.time;

        var ecsAction = action;
        m_Duration = ecsAction.GetTrait<Duration>(2).Time;

        m_Animator.SetTrigger(k_Work);
        m_Animator.SetBool(s_ContinueWork, true);
    }

    public override void ContinueExecution(Entity stateEntity, ActionContext action, Otto actor)
    {
        base.ContinueExecution(stateEntity, action, actor);

        if (Time.time - m_StartTime >= m_Duration - k_ExitTime)
            m_Animator.SetBool(s_ContinueWork, false);
    }

    public override OperationalActionStatus Status(Entity stateEntity, ActionContext action, Otto actor)
    {
        return Time.time - m_StartTime >= m_Duration ?
            OperationalActionStatus.Completed :
            OperationalActionStatus.InProgress;
    }
}
#endif
