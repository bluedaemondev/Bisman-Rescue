using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodesOnHit : MonoBehaviour
{
    public GameObject prefabParticlesOnExplode;
    public Animator animObject;
    public float radiusExplosion = 2;

    // Start is called before the first frame update
    void Start()
    {
        if (animObject == null)
            animObject = this.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == GameInfo.BULLET_LAYER ||
            collision.gameObject.layer == GameInfo.ENEMY_BULLET_LAYER)
        {
            print("exploded!");

            var touches = Physics2D.CircleCastAll(transform.position, radiusExplosion,Vector2.zero);
            
            foreach(var item in touches)
            {
                Debug.Log("item in explosion "+item.collider.name);
                if (item.collider.CompareTag(GameInfo.instance.explodableTag))
                {
                    ExplodesOnHit tryGExploder;
                    item.collider.TryGetComponent(out tryGExploder);

                    if(tryGExploder == null)
                        Destroy(item.collider.gameObject);
                    else
                    {
                        tryGExploder.animObject.SetTrigger("exploded"); // para encadenar explosiones
                    }
                }
                else if(item.collider.gameObject.layer == GameInfo.PLAYER_LAYER)
                {
                    item.collider.GetComponent<PlayerControllerBB>().SetCurrentState(PlayerState.damaged);
                }
                else if (item.collider.gameObject.layer == GameInfo.ENEMY_LAYER)
                {
                    item.collider.GetComponent<EnemyControllerBB>().SetCurrentState(EnemyState.dead);
                }
            }

            animObject.SetTrigger("exploded");
            // parametro en el animador
        }
    }

    /// <summary>
    /// llamado como un evento en la animacion de explosion
    /// </summary>
    public void ExplodeParticles()
    {
        Instantiate(prefabParticlesOnExplode, transform.position,
                    Quaternion.identity, GameInfo.instance.particlesContainer);
    }

}
