using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GetLicenseAnimBehaviour : StateMachineBehaviour
{
    public static Action OnAnimationStart;
    public static Action OnAnimationEnd;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnAnimationStart();
    }

    bool isActionTriggered = false;

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if( OnAnimationEnd == null) { Debug.Log("OnAnimationEnd BOD"); return; }

        if (isActionTriggered) return;
        
        if(stateInfo.normalizedTime >= stateInfo.length)
        {
            OnAnimationEnd();
            isActionTriggered = true;
        }

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //OnAnimationEnd();
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
