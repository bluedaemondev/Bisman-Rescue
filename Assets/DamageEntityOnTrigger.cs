using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEntityOnTrigger : MonoBehaviour
{
    public bool isPlayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isPlayer && collision.gameObject.layer == GameInfo.PLAYER_LAYER)
        {
            if (collision.GetComponent<PlayerControllerBB>() != null)
                collision.GetComponent<PlayerControllerBB>().SetCurrentState(PlayerState.damaged);
        }
        else if(isPlayer && collision.gameObject.layer == GameInfo.ENEMY_LAYER)
        {
            if (collision.GetComponent<EnemyControllerBB>() != null)
                collision.GetComponent<HealthScript>().GetDamage(1);
            else if (collision.GetComponent<DogControllerBB>() != null)
                collision.GetComponent<HealthScript>().GetDamage(1);

        }
    }

}
