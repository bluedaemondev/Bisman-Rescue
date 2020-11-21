using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgroPursuit : MonoBehaviour
{
    //public float speedMultip = 1.6f;
    public EnemyControllerBB controller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == GameInfo.PLAYER_LAYER)
        {
            controller.SetCurrentState(EnemyState.pursuiting);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == GameInfo.PLAYER_LAYER)
        {
            controller.SetCurrentState(EnemyState.patroling);
        }
    }
}
