using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShootFromPoint : MonoBehaviour
{
    [Header("Combate a distancia y melee")]
    public GameObject gunpoint;
    public GunScript gunScript;
    public Vector2 sizeMeleeAttack;


    //public int currAmmo;
    //public int maxAmmo;
    public float gunCooldown = 0.25f;

    public float currentCooldown;

    public GameObject bulletPrefab;
    [Header("TBD")]
    public Animator gunAnimator;

    public GunScript equipedGun;
    SpriteRenderer gunHolder;

    AudioSource sfxPlayer;
    public AudioClip clipMelee;


    private void Start()
    {
        //this.TryGetComponent<GunScript>(out equipedGun);

        this.sfxPlayer = GetComponentInChildren<AudioSource>();

        if (equipedGun != null)
            this.currentCooldown = this.gunCooldown = this.equipedGun.gunCooldown; // si tiene un arma equipada, activo el cd de ese ataque
        else
            this.currentCooldown = this.gunCooldown = 0.25f; // no tiene arma, golpea melee sin cd

        GameManagerActions.current.defeatEvent.AddListener(DisableComponent);
    }
    public void DisableComponent()
    {
        this.enabled = false;
    }

    public void SetGun(GunScript newGun)
    {
        if (gunScript)
            ThrowWeapon(transform.position, Vector2.one * 3f);
        // instancia el ultimo arma y la deja en el piso

        this.gunScript = newGun;
        SetCooldowns(newGun);

        HudController.current.UpdateRoundsUI(newGun.currAmmo, newGun.maxAmmo);

        gunHolder = gunpoint.GetComponentsInChildren<SpriteRenderer>().Single(gp => gp.CompareTag("gun"));
        gunHolder.sprite = newGun.spr;

    }

    void SetCooldowns(GunScript newGun)
    {
        this.currentCooldown = this.gunCooldown = newGun.gunCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;

        TurnGunpoint(mousePos);

        // hit
        if (Input.GetMouseButtonDown(0) && !gunScript)
        {
            MeleeAttack(mousePos);
        }

        // shoot
        //print(currentCooldown >= gunCooldown && gunScript != null);

        if (Input.GetMouseButton(0) && gunScript != null && currentCooldown >= gunCooldown)
        {
            ShootBullet(mousePos);
            //print("shot");

            //this.gunAnimator.SetBool(clickAnimParam, true);
        }

        // throw gun
        if (Input.GetMouseButton(1) && gunScript)
        {
            print("thrown weapon");
            ThrowWeapon(mousePos, Vector2.one);
            //this.gunAnimator.SetBool(throwAnimParam, true);
        }

        this.currentCooldown += Time.deltaTime;



    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.layer == bulletPrefab.layer)
    //}
    private Vector3 TurnGunpoint(Vector3 mousePos)
    {
        Vector3 aimDirection = (mousePos - transform.position).normalized;
        float angleRot = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        gunpoint.transform.eulerAngles = new Vector3(0, 0, angleRot);

        return gunpoint.transform.eulerAngles;
        //Debug.Log("Gunpoimt angle = " + angleRot);
    }

    //void TurnCorrection(Vector3 mousePos)
    //{
    //    //find distances and angles
    //    d = Vector2.Distance(new Vector2(gunpoint.transform.position.x, mousePos.y), new Vector2(turretTransform.position.x, turretTransform.position.y));
    //    x = Vector2.Distance(new Vector2(turretTransform.position.x, turretTransform.position.y), new Vector2(weaponTransform.position.x, weaponTransform.position.y));
    //    weaponAngle = weaponTransform.localEulerAngles.z;
    //    weaponAngle = weaponAngle * Mathf.Deg2Rad;
    //    y = Mathf.Abs(Mathf.Cos(weaponAngle) * x);
    //    b = Mathf.Rad2Deg * Mathf.Acos(y / d);
    //    a = Mathf.Rad2Deg * Mathf.Acos(y / x);
    //    //turn turret towards target
    //    turretTransform.up = targetTransform.position - turretTransform.position;
    //    //adjust for gun angle
    //    if (weaponTransform.localEulerAngles.z < 180)
    //        turretTransform.Rotate(Vector3.forward, 90 - b - a);
    //    else
    //        turretTransform.Rotate(Vector3.forward, 90 - b + a);
    //    //Please leave this comment in the code. This code was made by 
    //    //http://gamedev.stackexchange.com/users/93538/john-hamilton a.k.a. CrazyIvanTR. 
    //    //This code is provided as is, with no guarantees. It has worked in local tests on Unity 5.5.0f3.
    //}


    void ShootBullet(Vector3 mousePos)
    {
        if (gunScript && gunScript.currAmmo - 1 >= 0) // no dispara si no tiene balas
        {
            this.sfxPlayer.PlayOneShot(gunScript.sfxGun);
            HudController.current.UpdateRoundsUI(--gunScript.currAmmo, gunScript.maxAmmo);
        }
        else
        {
            this.sfxPlayer.PlayOneShot(gunScript.sfxNoClip);
            HudController.current.UpdateRoundsUI(0, 0); // no bullet
            return;
        }

        var bullet_go = Instantiate(bulletPrefab, gunpoint.transform.position, Quaternion.identity);
        var bullet = bullet_go.GetComponent<Bullet>();

        var directionVector = (mousePos - gunpoint.transform.position).normalized;

        bullet.forceToAppend = directionVector;
        bullet.parentToIgnoreCol = this.GetComponent<Collider2D>();


        this.currentCooldown = 0; // Reseteo el cd

    }

    void ThrowWeapon(Vector3 mousePos, Vector2 forceThrow)
    {
        GameObject gunThrown = gunScript.gameObject;

        if (gunThrown)
        {
            var bullet = Instantiate(gunScript.gunPrefab, gunpoint.transform.position, Quaternion.identity);
            var directionVector = (mousePos - gunpoint.transform.position).normalized;

            var throwLikeABullet = gunThrown.AddComponent<Bullet>();

            throwLikeABullet.forceToAppend = directionVector * forceThrow * 100; //test
            print(throwLikeABullet.forceToAppend);

            Destroy(this.gunScript.gameObject); // le rompo el arma, ya que la tiro
            gunHolder.sprite = null;
            HudController.current.UpdateRoundsUI(0, 0);
        }
    }

    void MeleeAttack(Vector3 mousePos)
    {

        float angleAttack = TurnGunpoint(mousePos).z;
        Vector2 directionVector = transform.position - mousePos;

        var attackTarget = Physics2D.BoxCast(transform.position, this.sizeMeleeAttack, angleAttack, directionVector);

        this.GetComponent<Animator>().Play("playerMelee");

        if (attackTarget.collider) // si tengo alguna colision me fijo si es un enemigo y le mando el mensaje de nokeado
        {
            //Debug.Log(attackTarget.collider);
            EnemyController compTarget;

            attackTarget.collider.TryGetComponent<EnemyController>(out compTarget);
            if (compTarget)
            {
                compTarget.Damage(DamageType.Knock);
            }
        }
        
        this.sfxPlayer.PlayOneShot(this.clipMelee);

    }
}
