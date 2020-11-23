using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walking,
    idle,
    pursuiting,
    melee_attacking,
    shooting,
    damaged,
    dead
}

[RequireComponent(typeof(AxialMovementKB))]
public class PlayerControllerBB : MonoBehaviour
{
    private Animator animator;

    public PlayerState currentState = PlayerState.idle;

    public string isIdleParam = "isIdle";
    public string isWalkingParam = "isWalking";


    public string isMeleeAttackingParam = "isMeleeAttacking";
    public string isShootingParam = "isShooting";

    public string hasGunParam = "hasGun";

    public string isDamagedParam = "damageTrigg";
    public string isDeadParam = "deadTrigg";

    public bool isWalking = false;
    public bool isIdle = false;
    public bool isMeleeAttacking = false;
    public bool isShooting = false;
    public bool hasGun = false;

    public bool isDead = false;
    public bool isDamaged = false;

    public HealthScript healthComponent;
    public AxialMovementKB movementComponent;
    //public FollowingTarget pursuitComponent;
    public MeleeAttack meleeAttackComponent;
    //public RandomStayInPlace idleComponent;

    public GameObject GuiPlayer;

    public void DisableDead()
    {
        healthComponent.enabled = false;
        movementComponent.enabled = false;
        meleeAttackComponent.enabled = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        if (GuiPlayer != null)
            GuiPlayer.SetActive(true);

        isIdle = true;
        animator = this.GetComponent<Animator>();
        healthComponent = this.GetComponent<HealthScript>();

        animator.ResetTrigger(isDeadParam);
    }

    public void SetCurrentState(PlayerState state)
    {
        this.currentState = state;
        switch (state)
        {
            case PlayerState.walking:
                isWalking = true;
                isIdle = false;
                isMeleeAttacking = false;
                isShooting = false;

                break;

            case PlayerState.idle:
                isIdle = true;
                isWalking = false;
                isMeleeAttacking = false;
                isShooting = false;
                break;
            
            case PlayerState.melee_attacking:
                isIdle = false;
                isWalking = false;

                isMeleeAttacking = true;
                isShooting = false;

                animator.Play("melee_attack");

                break;

            case PlayerState.shooting:
                isIdle = false;
                isMeleeAttacking = false;
                isShooting = true;


                break;

            case PlayerState.damaged:
                //animator.SetTrigger(isDamagedParam);
                //healthComponent.GetDamage(1);
                //break;

            case PlayerState.dead:
                isDead = true;
                animator.SetTrigger(isDeadParam);
                break;
        }
        //if (!isDead) { 
        animator.SetBool(isWalkingParam, isWalking);
        
        animator.SetBool(isShootingParam, isShooting);
        animator.SetBool(isMeleeAttackingParam, isMeleeAttacking);
        //print(isMeleeAttacking);

        animator.SetBool(isIdleParam, isIdle);
        //}

    }
}
