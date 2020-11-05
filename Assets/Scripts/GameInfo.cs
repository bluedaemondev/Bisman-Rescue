﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo :MonoBehaviour
{
    public static GameInfo instance { get; private set; }
    
    public static int ENEMY_LAYER = 8;
    public static int ENEMY_BULLET_LAYER = 9;
    
    public static int PLAYER_LAYER = 10;
    public static int OBSTACLE_LAYER = 11;
    public static int SCENE_JUMPER_LAYER = 12;
    
    public static int BULLET_LAYER = 13;

    public Transform particlesContainer;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
