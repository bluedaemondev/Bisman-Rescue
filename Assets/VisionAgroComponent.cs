using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionAgroComponent : MonoBehaviour
{
    List<DogControllerBB> controller;

    private void Awake()
    {
        if (controller == null)
        {
            controller = new List<DogControllerBB>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == GameInfo.PLAYER_LAYER)
        {
            foreach (var enemy in controller)
            {
                enemy.SetCurrentState(DogState.barking);

            }
        }
        else if (collision.gameObject.layer == GameInfo.ENEMY_LAYER)
        {

            DogControllerBB c;

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
                enemy.SetCurrentState(DogState.patroling);

            }
        }
    }
}
