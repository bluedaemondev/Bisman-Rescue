using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerSightBoss : MonoBehaviour
{
    public BossControllerBB controller;


    private void OnTriggerStay2D(Collider2D collision)
    {
        controller.SeePlayer();
    }
}
