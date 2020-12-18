using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodesOnProximity : MonoBehaviour
{

    Transform target;
    public Animator anim;

    public float distanceToTrigger = 2f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && Vector2.Distance(transform.position, target.position) <= distanceToTrigger)
        {
            anim.SetBool("inRange", true);
            //anim.SetTrigger("exploded");
        }
        else
        {
            anim.SetBool("inRange", false);
        }
    }

    public void SetAnimTriggerExploded()
    {
        anim.SetTrigger("exploded");
    }


    public void ExplodeProx()
    {
        CamerasManager.instance.ShakeCameraNormal(8, 0.2f);

        var touches = Physics2D.CircleCastAll(transform.position, distanceToTrigger, Vector2.zero);

        foreach (var item in touches)
        {
            Debug.Log("item in explosion " + item.collider.name);
            if (item.collider.CompareTag(GameInfo.instance.explodableTag))
            {
                ExplodesOnHit tryGExploder;
                item.collider.TryGetComponent(out tryGExploder);

                if (tryGExploder == null)
                    Destroy(item.collider.gameObject);
                else
                {
                    tryGExploder.animObject.SetTrigger("exploded"); // para encadenar explosiones
                }
            }
            else if (item.collider.gameObject.layer == GameInfo.PLAYER_LAYER)
            {
                item.collider.GetComponent<PlayerControllerBB>().SetCurrentState(PlayerState.damaged);
            }
            else if (item.collider.gameObject.layer == GameInfo.ENEMY_LAYER)
            {
                if (GetComponent<EnemyControllerBB>() != null)
                    item.collider.GetComponent<EnemyControllerBB>().SetCurrentState(EnemyState.dead);
            }
        }

        //anim.SetTrigger("exploded");
        // parametro en el animador

    }
}
