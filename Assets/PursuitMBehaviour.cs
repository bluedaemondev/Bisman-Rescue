using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitMBehaviour : StateMachineBehaviour
{
    FollowingTarget controller;

    Transform transfPlayer;

    Vector2 lastpos;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //transfPlayer = FindObjectOfType<PlayerControllerBB>().transform;
        transfPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        lastpos = transfPlayer.position;
        controller = animator.GetComponent<FollowingTarget>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (transfPlayer != null)
        {
            lastpos = transfPlayer.position;
            controller.SetFollowTarget(transfPlayer.position);
        }
        else
        {
            controller.SetFollowTarget(lastpos);
        }
        
        controller.Follow();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
