using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionAgroComponent : MonoBehaviour
{
    public DogControllerBB controller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == GameInfo.PLAYER_LAYER)
        {
            controller.SetCurrentState(DogState.barking);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == GameInfo.PLAYER_LAYER)
        {
            controller.SetCurrentState(DogState.patroling);
        }
    }
}
