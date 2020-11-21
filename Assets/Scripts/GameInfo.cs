using System.Collections;
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
    public Transform corpsesContainer;
    public Transform guiContainer;

    //public List<UnlockCard> cardsOnInventory;

    //public void AddCard(UnlockCard uc0)
    //{
    //    if (cardsOnInventory == null)
    //        cardsOnInventory = new List<UnlockCard>();

    //    if (!cardsOnInventory.Contains(uc0))
    //    {
    //        cardsOnInventory.Add(uc0);
    //    }
    //}

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
