using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTarget : MonoBehaviour
{
    //public GunScript equipedGun;
    SpriteRenderer gunHolder;
    public float gunCooldown = 0.25f;
    public float currentCooldown;
    public GameObject gunpoint;
    public GunScript gunScript;
    public float distanceShootEnabled = 9f;
    public AudioSource sfxPlayer;


    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        this.sfxPlayer = this.GetComponentInChildren<AudioSource>();
        this.gunScript = this.GetComponentInChildren<GunScript>();
        this.gunHolder = this.gunScript.GetComponent<SpriteRenderer>();

        GameManagerActions.current.defeatEvent.AddListener(this.DisableComponent);
    }

    private void DisableComponent()
    {
        this.enabled = false;
    }

    private IEnumerator DelayShoot(Vector3 target)
    {
        yield return new WaitForSeconds(gunCooldown); 
        // meto un delay igual para que no sea en un instante y haya chance de dodgear

        ShootBullet(target);

    }

    private void Update()
    {
        var playerPos = GameObject.FindObjectOfType<PlayerController>().transform.position;

        if (this.currentCooldown <= 0)

        {
            var hitObstacle = Physics2D.Raycast(transform.position, playerPos, distanceShootEnabled, GameInfo.OBSTACLE_LAYER);
            var hitPlayerPoint = Physics2D.Raycast(transform.position, playerPos, distanceShootEnabled, GameInfo.PLAYER_LAYER);
            var d_to_player = Vector2.Distance(playerPos, this.transform.position);
            //distancia habilitada + no hay obstaculos en el medio

            //print(d_to_player);

            if (d_to_player <= distanceShootEnabled &&
                !hitObstacle)
            {
                //print(this.name + " shooting!");
                StartCoroutine(this.DelayShoot(playerPos));
                
            }

            //print(d_to_player <= distanceShootEnabled && !hitObstacle);
            // apunto el gunpoint

            if (!hitObstacle && hitPlayerPoint)
            {
                Vector3 aimDirection = (hitPlayerPoint.transform.position - transform.position).normalized;
                float angleRot = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

                gunpoint.transform.eulerAngles = new Vector3(0, 0, angleRot);

            }
        }

        currentCooldown -= Time.deltaTime;

    }

    void ShootBullet(Vector3 targetPos)
    {
        if (gunScript && gunScript.currAmmo - 1 >= 0) // no dispara si no tiene balas
        {
            var bullet_go = Instantiate(bulletPrefab, gunpoint.transform.position, Quaternion.identity);
            var bullet = bullet_go.GetComponent<Bullet>();

            var directionVector = (targetPos - gunpoint.transform.position).normalized;

            bullet.forceToAppend = directionVector;
            bullet.parentToIgnoreCol = this.GetComponent<Collider2D>(); // paso la hitbox para ignorar

            print("bullet heading " + directionVector);
            this.currentCooldown = gunCooldown; //reset cooldown
            this.gunScript.currAmmo--;
            this.sfxPlayer.PlayOneShot(gunScript.sfxGun);

        }
        else
        {

            print("out of bullets " + this.name);
            //cambio de rutina al no tener balas
            this.gameObject.GetComponent<FetchAndAttack>().enabled = true;

            AlteredState a_state;
            TryGetComponent<AlteredState>(out a_state);

            //if (a_state)
            //{
            //    a_state.lastFetchAndAttackActive = true;
            //}
            
            gunHolder.sprite = null;
            
            this.sfxPlayer.PlayOneShot(gunScript.sfxNoClip);

            Destroy(this.gunScript.gameObject); //test

            this.enabled = false;
        }

    }
}
