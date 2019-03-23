#if WORKAHOLICDOMAIN_GENERATED
using System;
using Unity.AI.Planner;
using Unity.Entities;
using UnityEngine;
using Workaholic;
using WorkaholicDomain;

public class SleepAction : OttoAction
{
    public override void BeginExecution(Entity stateEntity, ActionContext action, Otto actor)
    {
        base.BeginExecution(stateEntity, action, actor);

        m_Animator = actor.GetComponentInParent<Animator>();
        m_Animator.SetTrigger(Animator.StringToHash("Sleep"));

        // Reset fatigue.
        foreach (var domainObjectEntity in actor.GetObjectEntities(stateEntity, typeof(Need)))
        {
            var need = actor.GetObjectTrait<Need>(domainObjectEntity);
            if (need.NeedType == NeedType.Fatigue)
            {
                need.Urgency = 0;
                actor.SetObjectTrait(domainObjectEntity, need);
                break;
            }
        }
    }
}
#endif
