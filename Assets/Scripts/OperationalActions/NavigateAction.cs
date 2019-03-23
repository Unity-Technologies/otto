#if WORKAHOLICDOMAIN_GENERATED
using System;
using Unity.AI.Planner;
using Unity.AI.Planner.Agent;
using Unity.AI.Planner.DomainLanguage.TraitBased;
using Unity.Entities;
using UnityEngine;
using UnityEngine.AI;
using Workaholic;

public class NavigateAction : OttoAction
{
    static readonly int k_Walk = Animator.StringToHash("Walk");
    static readonly int k_Forward = Animator.StringToHash("Forward");
    static readonly int k_Turn = Animator.StringToHash("Turn");

    MotionController m_MotionController;
    NavMeshAgent     m_NavMeshAgent;
    Transform        m_OttoTransform;
    Vector3          m_TargetPosition;
    bool             m_Arrived;
    float            m_TotalDistanceTravelled;
    float            m_TotalTime;
    float            m_PredictedDeltaTime;

    const float      k_TurnStrength = 1.0f;

    void SetAnimationParams(bool atDestination = false)
    {
        // Current position/orientation
        var currentDirection = m_OttoTransform.forward;
        var currentPosition = m_OttoTransform.position;

        // Turn
        var targetDirection = m_NavMeshAgent.nextPosition - currentPosition;
        var turnVal = Vector3.SignedAngle(currentDirection, targetDirection, Vector3.up) / 90.0f;
        m_Animator.SetFloat(k_Turn, turnVal * k_TurnStrength);

        // Forward
        var minForwardVelocity = atDestination ? 0.0f : 0.2f;
        var forwardVal = Mathf.Clamp((m_NavMeshAgent.nextPosition - currentPosition).magnitude, minForwardVelocity, 0.75f);
        m_Animator.SetFloat(k_Forward, forwardVal);
    }

    public override void BeginExecution(Entity stateEntity, ActionContext action, Otto actor)
    {
        base.BeginExecution(stateEntity, action, actor);

        // Trigger beginning of walk animation.
        m_Animator = actor.GetComponentInParent<Animator>();
        m_Animator.SetBool(k_Walk, true);

        m_TargetPosition = action.GetTrait<Location>(1).Position;
        m_OttoTransform = actor.transform;

        // Grab nav mesh
        m_NavMeshAgent = actor.GetComponentInParent<NavMeshAgent>();

        // Motion Controller
        m_MotionController = actor.GetComponentInParent<MotionController>();
        m_MotionController.TargetPosition = m_TargetPosition;
        m_MotionController.StartMoving();
        SetAnimationParams();
        m_Arrived = false;

        var startPosition = action.GetTrait<Location>(0).Position;
        var distance = Vector3.Distance(startPosition, m_TargetPosition);
        m_PredictedDeltaTime = Mathf.FloorToInt(distance / 0.47f + 1f);
    }

    public override void ContinueExecution(Entity stateEntity, ActionContext action, Otto actor)
    {
        base.ContinueExecution(stateEntity, action, actor);

        // Delay the execution of this animation until we've reached the Navigation state in the animator.
        if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Navigation"))
        {
            var position = m_OttoTransform.position;
            m_MotionController.TargetOrientation = m_NavMeshAgent.nextPosition - position;
            SetAnimationParams();

            // Check for arrival
            m_Arrived = Vector3.Distance(position , m_TargetPosition) <= 0.1;
        }
    }

    public override void EndExecution(Entity stateEntity, ActionContext action, Otto actor)
    {
        base.EndExecution(stateEntity, action, actor);

        // Set target orientation based on location orientation
        var ecsAction = action;
        var forward = ecsAction.GetTrait<Location>(1).Forward;
        m_MotionController.StopMoving(forward);

        // Effects
        // Update Otto position
        var agentDomainObjectTrait = ecsAction.GetTrait<DomainObjectTrait>(0);
        var destinationLocationTrait = ecsAction.GetTrait<Location>(1);

        var agentEntity = actor.GetDomainObjectEntityByID(stateEntity, agentDomainObjectTrait.ID);

        var loc = actor.GetObjectTrait<Location>(agentEntity);
        loc.Position = destinationLocationTrait.Position;
        actor.SetObjectTrait(agentEntity, loc);

        // Trigger ending of walk animation.
        m_Animator.SetBool(k_Walk, false);
        SetAnimationParams(true);
    }

    public override OperationalActionStatus Status(Entity stateEntity, ActionContext action, Otto actor)
    {
        return m_Arrived && Time.time - m_StartTime >= m_PredictedDeltaTime ?
            OperationalActionStatus.Completed : OperationalActionStatus.InProgress;
    }
}
#endif
