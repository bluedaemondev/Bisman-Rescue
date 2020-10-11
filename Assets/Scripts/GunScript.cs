using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Arma que se puede levantar del piso
/// </summary>
public class GunScript : MonoBehaviour
{
    public KeyCode pickupKey = KeyCode.E;

    public int currAmmo = 9;
    public int maxAmmo = 9;
    public float gunCooldown = 0.25f;

    public GameObject gunPrefab; // arma equipable
    public Sprite spr;
    
    public AudioClip sfxGun;
    public AudioClip sfxNoClip;


    // Start is called before the first frame update
    void Start()
    {
        gunPrefab = this.gameObject;
        spr = this.GetComponent<SpriteRenderer>().sprite;

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(pickupKey) && collision.gameObject.layer == GameInfo.PLAYER_LAYER)
        {
            var cpyTest = Instantiate(this);
            collision.GetComponent<ShootFromPoint>().SetGun(cpyTest);

            Destroy(this.gameObject);
        }
    }

}
