using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public bool isPlayer = false;

    EnemyControllerBB controller;
    PlayerControllerBB controllerP;

    public Collider2D attackRadius;

    public AudioClip clipAttack;

    private void Start()
    {
        if (!isPlayer)
            controller = this.GetComponent<EnemyControllerBB>();

        else
            controllerP = this.GetComponent<PlayerControllerBB>();
        
        GameManagerActions.current.defeatEvent.AddListener(DisableOnPlayerDeath);
    }
    private void Update()
    {
        if (isPlayer && Input.GetMouseButtonDown(0) && !controllerP.hasGun)
        {
            print("melee");
            controllerP.SetCurrentState(PlayerState.melee_attacking);
        }
    }
    public void DisableOnPlayerDeath()
    {
        this.GetComponent<Rigidbody2D>().simulated = false;
        this.enabled = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isPlayer &&
            collision.gameObject.layer == GameInfo.PLAYER_LAYER)
        {
            controller.SetCurrentState(EnemyState.melee_attacking);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isPlayer &&
            collision.gameObject.layer == GameInfo.PLAYER_LAYER)
        {
            controller.SetCurrentState(EnemyState.pursuiting);
        }
    }

    public void Attack()
    {
        attackRadius.enabled = true;
        SoundManager.instance.PlayEffect(clipAttack);

    }
    public void StopAttacking()
    {
        attackRadius.enabled = false;
    }
}
