using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadMBehaviour : StateMachineBehaviour
{
    public GameObject prefabDead;
    public GameObject prefabGUIDead;
    public bool isPlayer;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var corpse = Instantiate(prefabDead, animator.transform.position, Quaternion.identity, GameInfo.instance.corpsesContainer);
        if (isPlayer)
        {
            corpse.tag = "Player";
            Instantiate(prefabGUIDead, GameInfo.instance.guiContainer);

        }
        else
            ExitStairs.enemiesOnFloor.Remove(animator.GetComponent<EnemyControllerBB>());
        
        Destroy(animator.gameObject);
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
