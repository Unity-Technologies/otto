using System;
using UnityEngine;

public class IncCycleCount : StateMachineBehaviour
{

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("CycleCount", animator.GetInteger("CycleCount") + 1);
    }
}
