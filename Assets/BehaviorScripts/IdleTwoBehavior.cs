
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTwoBehavior : StateMachineBehaviour
{


    private float timer;
    public float minTime;
    public float maxTime;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Debug.Log("Entered Idle State");
        timer = Random.Range(minTime, maxTime);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            int nextState = Random.Range(0, 3);

            if (nextState == 0)
            {
                animator.SetTrigger("IdleToJump");
            }
            else if (nextState == 1) 
            {
                animator.SetTrigger("IdleToSin");
            }
            else
            {
                animator.SetTrigger("IdleToCharge");
            }
            //    Debug.Log("Timer expired. Transitioning to IdleTwo state.");
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Debug.Log("Exit Idle");
        animator.ResetTrigger("IdleTwo");
        animator.ResetTrigger("JumpToIdle");
        animator.ResetTrigger("SinToIdle");
    }


}
