using System;
using System.Collections;
using System.Collections.Generic;
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

    private float f, d, x, y, h, b, a, weaponAngle, turnAngle;

    public GameObject bulletPrefab;
    [Header("TBD")]
    public Animator gunAnimator;

    public GunScript equipedGun;


    private void Start()
    {
        this.TryGetComponent<GunScript>(out equipedGun);
        if (equipedGun != null)
            this.currentCooldown = this.gunCooldown = this.equipedGun.gunCooldown; // si tiene un arma equipada, activo el cd de ese ataque
        else
            this.currentCooldown = this.gunCooldown = 0f; // no tiene arma, golpea melee sin cd

    }

    public void SetGun(GunScript newGun)
    {
        this.gunScript = newGun;

    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;

        TurnGunpoint(mousePos);

        //Click
        if (Input.GetMouseButton(0) && currentCooldown > gunCooldown)
        {
            ShootBullet(mousePos);

            //this.gunAnimator.SetBool(clickAnimParam, true);
        }
        //Throw
        else if (Input.GetMouseButton(1) && gunScript)
        {
            ThrowWeapon(mousePos);
            //this.gunAnimator.SetBool(throwAnimParam, true);
        }
        else
        {
            MeleeAttack(mousePos);
        }
        this.currentCooldown += Time.deltaTime;



    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.layer == bulletPrefab.layer)
    //}
    private void TurnGunpoint(Vector3 mousePos)
    {
        Vector3 aimDirection = (mousePos - transform.position).normalized;
        float angleRot = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        gunpoint.transform.eulerAngles = new Vector3(0, 0, angleRot);
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
        var bullet = Instantiate(bulletPrefab, gunpoint.transform.position, Quaternion.identity);
        var directionVector = (mousePos - gunpoint.transform.position).normalized;

        bullet.GetComponent<Bullet>().forceToAppend = directionVector;

        this.currentCooldown = 0; // Reseteo el cd

    }

    void ThrowWeapon(Vector3 mousePos)
    {
        GameObject gunThrown = this.gunScript.gameObject;

        if (gunThrown)
        {
            var bullet = Instantiate(gunScript.gunPrefab, gunpoint.transform.position, Quaternion.identity);
            var directionVector = (mousePos - gunpoint.transform.position).normalized;

            var throwLikeABullet = gunThrown.AddComponent<Bullet>();
            throwLikeABullet.forceToAppend = directionVector;
            
            Destroy(this.GetComponent<GunScript>()); // le rompo el arma, ya que la tiro

        }
    }

    void MeleeAttack(Vector3 mousePos)
    {
        float angleAttack = Mathf.Rad2Deg * Mathf.Atan2(this.transform.position.x - mousePos.x, mousePos.y);
        Vector2 directionVector = transform.position - mousePos;

        var attackTarget = Physics2D.BoxCast(transform.position, this.sizeMeleeAttack, angleAttack, directionVector);

        if (attackTarget.collider) // si tengo alguna colision me fijo si es un enemigo y le mando el mensaje de nokeado
        {
            EnemyController compTarget;

            attackTarget.collider.TryGetComponent<EnemyController>(out compTarget);
            if (compTarget)
            {
                compTarget.Damage(DamageType.Knock);
            }
        }
    }
}
