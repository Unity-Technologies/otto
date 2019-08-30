using System;
using UnityEngine;

public class FlipOtto : StateMachineBehaviour
{
    bool hasFlipped;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hasFlipped = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!hasFlipped)
        {
            animator.gameObject.transform.forward *= -1;
            hasFlipped = true;
        }
    }

}
