using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    patroling,
    idle,
    pursuiting,
    melee_attacking,
    shooting,
    knocked,
    dead
}

[RequireComponent(typeof(WaypointPatrol),typeof(FollowingTarget))] // typeof(MeleeAttack), typeof(RandomStayInPlace)
public class EnemyControllerBB : MonoBehaviour
{
    private Animator animator;

    public EnemyState currentState = EnemyState.patroling;

    public string isPatrolingParam = "isPatroling";
    public string isPursuingParam = "isPursuing";
    public string isIdleParam = "isIdle";


    public string isMeleeAttackingParam = "isMeleeAttacking";
    public string isShootingParam = "isShooting";

    public string hasGunParam = "hasGun";

    public string isKnockedParam = "isKnocked";
    public string isDeadParam = "isDeadTrigg";

    public bool isPatroling = false;
    public bool isPursuing = false;
    public bool isIdle = false;
    public bool isMeleeAttacking = false;
    public bool isShooting = false;

    public bool isKnocked = false;
    public bool isDead = false;

    public WaypointPatrol waypointComponent;
    public FollowingTarget pursuitComponent;
    public MeleeAttack meleeAttackComponent;
    public RandomStayInPlace idleComponent;


    // Start is called before the first frame update
    void Start()
    {
        isPatroling = true;
        animator = this.GetComponent<Animator>();
        ExitStairs.enemiesOnFloor.Add(this);
    }


    public void SetCurrentState(EnemyState state)
    {
        this.currentState = state;
        switch (state)
        {
            case EnemyState.patroling:
                isPatroling = true;
                isIdle = false;
                isPursuing = false;
                isMeleeAttacking = false;
                isShooting = false;

                waypointComponent.SetSpeedMultiplier(1);
                break;
            case EnemyState.idle:
                isIdle = true;
                isPatroling = false;
                isPursuing = false;
                isMeleeAttacking = false;
                isShooting = false;
                break;
            case EnemyState.pursuiting:
                isPatroling = false;
                isIdle = false;
                isPursuing = true;
                isMeleeAttacking = false;
                isShooting = false;

                //waypointComponent.SetSpeedMultiplier(pursuitComponent.speedMultipier);
                break;
            case EnemyState.knocked:
                isPatroling = false;
                isIdle = false;
                isPursuing = false;
                isMeleeAttacking = false;
                isShooting = false;
                isKnocked = true;
                animator.Play("knocked");
                //waypointComponent.SetSpeedMultiplier(pursuitComponent.speedMultipier);
                break;
            case EnemyState.melee_attacking:
                isPatroling = false;
                isIdle = false;
                isPursuing = false;
                isMeleeAttacking = true;
                isShooting = false;
                animator.Play("melee_attack");
                break;
            case EnemyState.shooting:
                isPatroling = false;
                isIdle = false;
                isPursuing = false;
                isMeleeAttacking = false;
                isShooting = true;
                break;
            case EnemyState.dead:
                isDead = true;
                animator.SetTrigger(isDeadParam);
                break;
        }

        animator.SetBool(isPatrolingParam, isPatroling);
        animator.SetBool(isPursuingParam, isPursuing);
        animator.SetBool(isShootingParam, isShooting);
        animator.SetBool(isMeleeAttackingParam, isMeleeAttacking);

        animator.SetBool(isKnockedParam, isKnocked);

        animator.SetBool(isIdleParam, isIdle);

    }
}
