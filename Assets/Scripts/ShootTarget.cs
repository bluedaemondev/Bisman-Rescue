﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy IA attack behaviours script
/// </summary>
public class ShootTarget : MonoBehaviour
{
    //public GunScript equipedGun;
    public SpriteRenderer gunHolder;
    public float gunCooldown = 0.25f;
    public float currentCooldown;
    public GameObject gunpoint;
    public PersistentGunStats gunScript;
    public float distanceShootEnabled = 9f;
    public AudioSource sfxPlayer;

    private bool canShoot = true;


    public GameObject bulletPrefab;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerControllerBB>().transform;
        this.sfxPlayer = this.GetComponentInChildren<AudioSource>();
        //this.gunScript = this.GetComponentInChildren<PersistentGunStats>();
        this.gunScript = this.GetComponent<PersistentGunStats>();
        //this.gunHolder = this.gunScript.GetComponent<SpriteRenderer>();

        GameManagerActions.current.defeatEvent.AddListener(this.DisableComponent);
    }

    private void DisableComponent()
    {
        this.enabled = false;
    }

    private IEnumerator DelayShoot(Vector3 target)
    {
        canShoot = false;
        yield return new WaitForSeconds(this.gunScript.cooldownMax);
        // meto un delay igual para que no sea en un instante y haya chance de dodgear
        ShootBullet(target);
        canShoot = true;

    }

    private void Update()
    {
        var playerPos = player.position;

        if (this.currentCooldown <= 0 && canShoot)

        {
            var hitObstacle = Physics2D.Raycast(transform.position, playerPos, distanceShootEnabled, GameInfo.OBSTACLE_LAYER);
            var hitPlayerPoint = Physics2D.Raycast(transform.position, playerPos, distanceShootEnabled, GameInfo.PLAYER_LAYER);
            
            var d_to_player = Vector2.Distance(playerPos, this.transform.position);
            //distancia habilitada + no hay obstaculos en el medio

            var d_between_me_and_obstacle = Vector2.Distance(this.transform.position, hitObstacle.point); // correccion de tp

            //print(d_to_player);

            if (d_to_player <= distanceShootEnabled &&
                d_between_me_and_obstacle >= d_to_player)
            {
                print(this.name + " shooting!");
                StartCoroutine(this.DelayShoot(playerPos));

            }

            //print(d_to_player <= distanceShootEnabled && !hitObstacle);
            // apunto el gunpoint

            if (gunpoint != null) // correccion tp
            {
                Vector3 aimDirection = (playerPos - transform.position).normalized;
                float angleRot = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;


                gunpoint.transform.eulerAngles = new Vector3(0, 0, angleRot);
            }

        }

        currentCooldown -= Time.deltaTime;

    }

    void ShootBullet(Vector3 targetPos)
    {
        int currAmmo = gunScript.ShootClip(true);

        if (currAmmo >= 0 && gunScript.currentGunStats.shootSfx)
        {
            this.sfxPlayer.PlayOneShot(gunScript.currentGunStats.shootSfx);
            var bullet_go = Instantiate(bulletPrefab, gunpoint.transform.position, Quaternion.identity);
            var bullet = bullet_go.GetComponent<Bullet>();

            var directionVector = (targetPos - gunpoint.transform.position).normalized;

            bullet.forceToAppend = directionVector;
            bullet.parentToIgnoreCol = this.GetComponent<Collider2D>(); // paso la hitbox para ignorar

            print("bullet heading " + directionVector);
            this.currentCooldown = gunCooldown; //reset cooldown

            this.gunScript.ShootClip(false);
        }
        else if (gunScript.noClipSfx)
        {
            print("out of bullets " + this.name);
            //cambio de rutina al no tener balas
            this.gameObject.GetComponent<FetchAndAttack>().enabled = true;

            AlteredState a_state;
            TryGetComponent(out a_state);

            this.sfxPlayer.PlayOneShot(gunScript.noClipSfx);
            this.gunScript.SetToMelee();
            gunHolder.sprite = null;

            if (a_state)
            {
                a_state.enabled = true;
            }

            this.enabled = false;

        }

    }
}
