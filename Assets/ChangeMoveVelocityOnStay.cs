using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMoveVelocityOnStay : MonoBehaviour
{
    public float speedMultiplier = 0.5f;

    public float baseSpeed;

    AxialMovementKB movPlayer;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == GameInfo.PLAYER_LAYER)
        {
            baseSpeed = collision.GetComponent<AxialMovementKB>().moveSpeedMultip;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == GameInfo.PLAYER_LAYER)
        {
            collision.GetComponent<AxialMovementKB>().moveSpeedMultip = speedMultiplier;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == GameInfo.PLAYER_LAYER)
        {
            collision.GetComponent<AxialMovementKB>().moveSpeedMultip = baseSpeed;
        }
    }
}
