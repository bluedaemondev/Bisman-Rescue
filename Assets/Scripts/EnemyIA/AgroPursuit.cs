using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgroPursuit : MonoBehaviour
{
    //public float speedMultip = 1.6f;
    public List<EnemyControllerBB> controller;

    private void Awake()
    {
        if (controller == null)
        {
            controller = new List<EnemyControllerBB>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == GameInfo.PLAYER_LAYER)
        {
            foreach (var enemy in controller)
            {
                enemy.SetCurrentState(EnemyState.pursuiting);

            }
        }
        else if (collision.gameObject.layer == GameInfo.ENEMY_LAYER)
        {
            EnemyControllerBB c;

            //autocarga de agros 
            collision.gameObject.TryGetComponent(out c);
            if (c)
            {
                controller.Add(c);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == GameInfo.PLAYER_LAYER)
        {
            foreach (var enemy in controller)
            {
                enemy.SetCurrentState(EnemyState.patroling);

            }
            //controller.SetCurrentState(EnemyState.patroling);
        }
    }
}
