using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringOtherEnemiesOnTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == GameInfo.ENEMY_LAYER)
        {
            EnemyControllerBB en;
            collision.TryGetComponent(out en);

            if (en)
            {
                if (!en.isDead && !en.isKnocked)
                {
                    en.SetCurrentState(EnemyState.pursuiting);
                    en.pursuitComponent.SetFollowTarget(this.transform.position);
            }
            }

        }
    }
}
