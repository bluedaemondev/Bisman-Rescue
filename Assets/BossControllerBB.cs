using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(HealthScript))]
public class BossControllerBB : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gunpoint;
    public float bulletSpeed = 11f;
    public float speedMovement = 5f;

    public float minDistShoot = 1.4f;

    private Rigidbody2D rb;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //else
        //{
        if (!anim.GetBool("playerOnSight"))
        {
            anim.SetBool("isShooting", false);

            anim.SetBool("isWalking", true);
        }
        //}
    }

    public void ShootBullet()
    {
        var bull = Instantiate(bullet, gunpoint.transform.position, Quaternion.identity);

        if (transform.localScale.x < 0)
        {
            bull.GetComponent<Bullet>().forceToAppend = new Vector2(bulletSpeed, 0);
        }
        else
        {
            bull.GetComponent<Bullet>().forceToAppend = new Vector2(-bulletSpeed, 0);
        }

        bull.GetComponent<Bullet>().parentToIgnoreCol = this.GetComponent<Collider2D>();
    }

    public void Move()
    {
        var movepos = transform.position - GameObject.FindGameObjectWithTag("Player").transform.position;
        movepos *= Time.deltaTime * speedMovement;

        print(movepos);
        rb.MovePosition(movepos);
    }

    public void SeePlayer()
    {
        anim.SetBool("playerOnSight", true);

    }
}
