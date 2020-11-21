using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentGunStats : MonoBehaviour
{
    [Header("Arma persistente para el jugador")]
    public bool hasFireGun = false;
    public float cooldownMax = 0.125f;
    public float cooldownCurrent = 0;
    public int ammoCurrent;
    public int ammoMax;

    public Sprite gunSprite;
    public AudioClip noClipSfx;


    public Gun currentGunStats { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        // para ataque melee, construyo por default
        if (!hasFireGun)
            SetToMelee();
    }
    public void SetToMelee()
    {
        var meleeAttack = new Gun();

        this.SetGunStats(meleeAttack, false);
        currentGunStats = meleeAttack;

        this.hasFireGun = false;
        HudController.current.UpdateRoundsUI(0, 0);

    }
    public void SetGunStats(Gun gun, bool updateUi)
    {
        this.cooldownMax = gun.cooldownMax;
        this.cooldownCurrent = cooldownMax;
        this.gunSprite = gun.gunSprite;

        if (updateUi)
            HudController.current.UpdateRoundsUI(gun.ammoCurrent, gun.ammoMax);

    }

    public int ShootClip(bool updateUi)
    {
        if (this.ammoCurrent - 1 >= 0 && hasFireGun)
        {
            this.ammoCurrent--;
            
            if (updateUi)
                HudController.current.UpdateRoundsUI(ammoCurrent, ammoMax);
        }
        else
        {
            this.ammoCurrent = 0;
            
            if (updateUi)
                HudController.current.UpdateRoundsUI(0, 0); // no bullet
        }


        return this.ammoCurrent;
    }
}
