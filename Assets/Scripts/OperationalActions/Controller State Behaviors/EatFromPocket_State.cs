#if PLANNER_ACTIONS_GENERATED
using System;
using UnityEngine;
using Workaholic;

public class EatFromPocket_State : StateMachineBehaviour
{
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var otto = animator.gameObject.GetComponentInChildren<Otto>();
        var action = (ConsumeAction)otto.CurrentOperationalAction;
        action.AnimationComplete = true;
    }
}
#endif
