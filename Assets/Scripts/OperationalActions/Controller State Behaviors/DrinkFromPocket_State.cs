#if WORKAHOLICDOMAIN_GENERATED
using System;
using UnityEngine;
using Workaholic;

public class DrinkFromPocket_State : StateMachineBehaviour
{
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var controller = animator.gameObject.GetComponentInChildren<Otto>().Controller;
        var action = (ConsumeAction)controller.CurrentOperationalAction;
        action.AnimationComplete = true;
    }
}
#endif
