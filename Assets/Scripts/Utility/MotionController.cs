using System;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class MotionController : MonoBehaviour
{

    public Vector3 TargetOrientation { get; set; }

    public Vector3 TargetPosition
    {
        get  => m_NavMeshAgent.destination;
        set => m_NavMeshAgent.destination = value;
    }

    const float k_VacuumStrength = 0.01f;
    const float k_DestinationRadius = 0.3f;
    const float k_TurnStrengthStart = 0.2f;
    const float k_TimeFactor = 0.5f;
    const float k_TurnDelay = 2.0f;
    const float k_TurnStrengthMax = 2.0f;

    Animator m_Animator;
    NavMeshAgent m_NavMeshAgent;
    float m_TimeSinceTurnChange;
    bool m_Moving;

    void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
        m_NavMeshAgent.updatePosition = false; // Don’t update position automatically
    }

    void Update()
    {
        if (m_Moving)
        {
            // Pull character towards agent
            var position = transform.position;
            if ((m_NavMeshAgent.destination - position).magnitude < k_DestinationRadius)
                transform.position = k_VacuumStrength * m_NavMeshAgent.nextPosition + (1 - k_VacuumStrength) * position;

            // Rotate toward target, slowly at first
            m_TimeSinceTurnChange += Time.deltaTime;
            float angleCorrection = Vector3.SignedAngle(transform.forward, TargetOrientation, Vector3.up);
            float m_turnStrength =
                Mathf.Clamp(k_TurnStrengthStart + k_TimeFactor * (m_TimeSinceTurnChange - k_TurnDelay), 0,
                    k_TurnStrengthMax);

            transform.Rotate(Vector3.up, m_turnStrength * angleCorrection * Time.deltaTime);
        }
        else
        {
            transform.forward = Vector3.Lerp(transform.forward, TargetOrientation, 0.1f);
        }
    }

    void OnAnimatorMove()
    {
        // Update position based on animation movement using navigation surface height
        var position = m_Animator.rootPosition;
        position.y = m_NavMeshAgent.nextPosition.y;
        transform.position = position;
    }

    public void StartMoving()
    {
        enabled = true;
        m_Moving = true;
        m_TimeSinceTurnChange = 0.0f;
    }

    public void StopMoving(Vector3 orientation)
    {
        TargetOrientation = orientation;
        m_Moving = false;
    }
}

