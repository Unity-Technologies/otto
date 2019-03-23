using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomAnimate : StateMachineBehaviour
{

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat("RandomNumber", Random.value);
    }
}
