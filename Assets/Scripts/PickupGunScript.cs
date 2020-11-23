using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Arma que se puede levantar del piso
/// </summary>
public class PickupGunScript : MonoBehaviour
{

    //public int currAmmo = 9;
    //public int maxAmmo = 9;
    //public float gunCooldown = 0.25f;

    public Sprite spr;
    
    
    //public GameObject gunPrefab; // arma equipable

    public KeyCode pickupKey = KeyCode.E;
    
    public AudioClip sfxGun;
    public AudioClip sfxNoClip;

    public Gun gunRefference;

    public void LoadGun(Gun gun)
    {
        this.gunRefference = gun;
    }

    // Start is called before the first frame update
    void Start()
    {
        //gunPrefab = this.gameObject;
        spr = this.GetComponent<SpriteRenderer>().sprite;

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(pickupKey) &&
            collision.gameObject.layer == GameInfo.PLAYER_LAYER)
        {
            //var cpyTest = Instantiate(this);

            // crear clase de arma, guardando las estadisticas
            // y tambien el sprite 

            //collision.GetComponent<ShootFromPoint>().SetGun(cpyTest);

            var gstat = collision.GetComponent<PersistentGunStats>();

            gstat.gunSprite = spr;

            gstat.SetGunStats(gunRefference, true);
            gstat.hasFireGun = true;

            Destroy(this.gameObject);
        }
    }

}
