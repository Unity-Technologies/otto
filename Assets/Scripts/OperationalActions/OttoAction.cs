#if WORKAHOLICDOMAIN_GENERATED
using System;
using System.Collections.Generic;
using Unity.AI.Planner;
using Unity.AI.Planner.Agent;
using Unity.Entities;
using UnityEngine;
using Workaholic;
using WorkaholicDomain;
using Time = UnityEngine.Time;

public abstract class OttoAction : IOperationalAction<Otto>
{
    public bool AnimationComplete { get; set; }

    protected int           m_AccumulatedTime;
    protected Animator      m_Animator;
    protected float         m_MinUnitTime = 1f;

    static readonly Dictionary<NeedType, int> m_DeathAnimationFlags = new Dictionary<NeedType, int>
    {
        { NeedType.Hunger,  Animator.StringToHash("Death_NoFood") },
        { NeedType.Thirst,  Animator.StringToHash("Death_NoDrink") },
        { NeedType.Fatigue, Animator.StringToHash("Death_NoRest") }
    };

    protected float m_StartTime;

    public virtual void BeginExecution(Entity stateEntity, ActionContext action, Otto actor)
    {
        m_StartTime = Time.time;
        m_AccumulatedTime = 0;
        m_Animator = actor.GetComponentInParent<Animator>();
        AnimationComplete = false;
    }

    public virtual void ContinueExecution(Entity stateEntity, ActionContext action, Otto actor)
    {
        UpdateNeeds(stateEntity, actor);
    }

    public virtual void EndExecution(Entity stateEntity, ActionContext action, Otto actor)
    {
        UpdateNeeds(stateEntity, actor);
    }

    public virtual OperationalActionStatus Status(Entity stateEntity, ActionContext action, Otto actor)
    {
        return AnimationComplete && Time.time - m_StartTime > m_MinUnitTime ?
            OperationalActionStatus.Completed : OperationalActionStatus.InProgress;
    }

    void UpdateNeeds(Entity stateEntity, Otto actor)
    {
        if (Mathf.Floor(Time.time - m_StartTime) > m_AccumulatedTime)
        {
            m_AccumulatedTime++;

            var time = actor.GetObjectTrait<WorkaholicDomain.Time>(stateEntity);
            time.Value += 1;
            actor.SetObjectTrait(stateEntity, time);


            // Resources
            foreach (var domainObjectEntity in actor.GetObjectEntities(stateEntity, typeof(Need)))
            {
                var need = actor.GetObjectTrait<Need>(domainObjectEntity);
                need.Urgency += need.ChangePerSecond;
                actor.SetObjectTrait(domainObjectEntity, need);

                // Check for death.
                if (need.Urgency > 100)
                {
                    actor.Dead = true;
                    m_Animator.SetBool(m_DeathAnimationFlags[need.NeedType], true);
                }
            }
        }
    }
}
#endif
