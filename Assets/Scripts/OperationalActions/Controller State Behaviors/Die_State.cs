using System;
using UnityEngine;

public class Die_State : StateMachineBehaviour
{
    MotionController m_motionController;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var gameObject = animator.gameObject;
        m_motionController = gameObject.GetComponent<MotionController>();
        m_motionController.TargetOrientation = gameObject.transform.forward;
        animator.SetBool("Walk", false);
    }
}
