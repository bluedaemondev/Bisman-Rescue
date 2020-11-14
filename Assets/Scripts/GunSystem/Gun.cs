﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunType
{
    Melee,
    Handgun22,
}

public class Gun
{
    public string name { get; set; }
    public float cooldownMax { get; set; }
    public float cooldownCurrent { get; set; }
    public int ammoCurrent { get; set; }
    public int ammoMax { get; set; }

    public GunType type { get; set; }
    public Sprite gunSprite { get; set; }
    public AudioClip shootSfx { get; set; }

    public Gun()
    {
        // melee gun stats
        cooldownMax = 0.125f;
        cooldownCurrent = 0;
        ammoMax = 0;
        ammoCurrent = 0;

        name = "melee";
        type = GunType.Melee;

        gunSprite = null;
        shootSfx = null;
    }

    public Gun(GunType type, float cdMax, int ammoMax, string name, Sprite sprite, AudioClip shootSfx)
    {
        cooldownMax = cdMax;
        cooldownCurrent = 0;
        this.ammoMax = ammoMax;
        ammoCurrent = 0;
        this.name = name;
        gunSprite = sprite;
        this.shootSfx = shootSfx;

        this.type = type;
    }
}
