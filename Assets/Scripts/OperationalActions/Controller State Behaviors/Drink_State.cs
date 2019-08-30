using System;
using UnityEngine;
using Workaholic;

public class Drink_State : StateMachineBehaviour
{
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
#if PLANNER_DOMAIN_GENERATED
        var otto = animator.gameObject.GetComponentInChildren<Otto>();
        otto.CompleteAction();
#endif
    }
}
