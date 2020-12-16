using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleMBehaviour : StateMachineBehaviour
{
    EnemyControllerBB controller;

    public AudioClip clip;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller = animator.GetComponent<EnemyControllerBB>();

        if (animator.GetComponentInChildren<SpriteRenderer>().isVisible)
            SoundManager.instance.PlayEffect(clip);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    //controller.waypointComponent.SetFollowTarget(FindObjectOfType<PlayerController>().transform.position);

    //    //controller.pursuitComponent.Follow();
    //}
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller.SetCurrentState(EnemyState.patroling);
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
