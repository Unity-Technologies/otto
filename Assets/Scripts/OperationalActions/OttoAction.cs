#if PLANNER_ACTIONS_GENERATED
using System;
using System.Collections.Generic;
using AI.Planner.Domains;
using AI.Planner.Domains.Enums;
using Unity.AI.Planner.Agent;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using Unity.Collections;
using Workaholic;
using UnityEngine;
using Time = UnityEngine.Time;

public abstract class OttoAction : IOperationalAction<Otto, StateData, ActionKey>
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

    public virtual void BeginExecution(StateData state, ActionKey action, Otto actor)
    {
        m_StartTime = Time.time;
        m_AccumulatedTime = 0;
        m_Animator = actor.GetComponentInParent<Animator>();
        AnimationComplete = false;
    }

    public virtual void ContinueExecution(StateData state, ActionKey action, Otto actor)
    {
        UpdateNeeds(state, actor);
    }

    public virtual void EndExecution(StateData state, ActionKey action, Otto actor)
    {
        UpdateNeeds(state, actor);
    }

    public virtual OperationalActionStatus Status(StateData state, ActionKey action, Otto actor)
    {
        return AnimationComplete && Time.time - m_StartTime > m_MinUnitTime ?
            OperationalActionStatus.Completed : OperationalActionStatus.InProgress;
    }

    void UpdateNeeds(StateData state, Otto actor)
    {
        if (Mathf.Floor(Time.time - m_StartTime) > m_AccumulatedTime)
        {
            m_AccumulatedTime++;

            var domainObjects = new NativeList<(DomainObject, int)>(4, Allocator.TempJob);
            foreach (var (_, domainObjectIndex) in state.GetDomainObjects(domainObjects, typeof(AI.Planner.Domains.Time)))
            {
                var time = state.GetTraitOnObjectAtIndex<AI.Planner.Domains.Time>(domainObjectIndex);
                time.Value += 1;
                state.SetTraitOnObjectAtIndex(time, domainObjectIndex);
            }

            // Resources
            domainObjects.Clear();
            foreach (var (_, domainObjectIndex) in state.GetDomainObjects(domainObjects, typeof(Need)))
            {
                var need = state.GetTraitOnObjectAtIndex<Need>(domainObjectIndex);
                need.Urgency += need.ChangePerSecond;
                state.SetTraitOnObjectAtIndex(need, domainObjectIndex);

                // Check for death.
                if (need.Urgency > 100)
                {
                    actor.Dead = true;
                    m_Animator.SetBool(m_DeathAnimationFlags[need.NeedType], true);
                }
            }
            domainObjects.Dispose();
        }
    }
}
#endif
