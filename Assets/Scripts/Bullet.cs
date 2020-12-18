using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rbSelf;
    public float speedShot;
    public bool diesInCollision;
    public int damage = 1;

    [Header("Vector direccion")]
    public Vector2 forceToAppend;

    [Header("Prefabs usados")]
    public GameObject particlesOnCrash;

    [Header("Para reutilizar el script sobre las armas arrojables")]
    public DamageType damageType;

    public Collider2D parentToIgnoreCol;

    // Start is called before the first frame update
    void Start()
    {
        //if (this.gameObject.layer == GameInfo.BULLET_LAYER)
        //    Physics2D.IgnoreCollision(GameObject.FindObjectOfType<PlayerController>().GetComponent<Collider2D>(),
        //        this.GetComponent<Collider2D>());
        //else //enemy

        Physics2D.IgnoreCollision(parentToIgnoreCol, this.GetComponent<Collider2D>());


        this.rbSelf = GetComponent<Rigidbody2D>();
        // fuerza normalizada * velocidad
        this.rbSelf.AddForce(forceToAppend * speedShot, ForceMode2D.Impulse);

        GameManagerActions.current.defeatEvent.AddListener(this.DisableComponent);

    }

    void DisableComponent()
    {
        this.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        #region refactor 20-11-05
        //print("hola");

        //if (collision.gameObject.layer == GameInfo.ENEMY_LAYER) //ENEMY
        //{
        //    collision.gameObject.GetComponent<EnemyController>().TakeDamage(this.damageType);
        //}
        //else if(collision.gameObject.layer == GameInfo.PLAYER_LAYER)
        //{
        //    collision.gameObject.GetComponent<PlayerController>().TakeDamage();
        //}
        #endregion

        if (rbSelf.velocity.magnitude > 0)
        {
            rbSelf.velocity = Vector2.zero;

        }

        if (collision.gameObject.layer == GameInfo.ENEMY_LAYER)
        {
            collision.gameObject.GetComponent<HealthScript>().GetDamage(damage);
        }
        if (collision.gameObject.layer == GameInfo.PLAYER_LAYER)
        {
            collision.gameObject.GetComponent<HealthScript>().GetDamage(damage);
        }

        //if(diesInCollision)
        Destroy(this.gameObject);
    }
}
