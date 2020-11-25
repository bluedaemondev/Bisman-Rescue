using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExitStairs : MonoBehaviour
{
    //public static List<EnemyController> enemiesOnFloor= new List<EnemyController>();
    public static List<EnemyControllerBB> enemiesOnFloor = new List<EnemyControllerBB>();
    public static List<DogControllerBB> dogsOnFloor = new List<DogControllerBB>();


    public AudioClip clipRebote;


    private void Awake()
    {
        //enemiesOnFloor = new List<EnemyController>();
        enemiesOnFloor = new List<EnemyControllerBB>();
        dogsOnFloor = new List<DogControllerBB>();
        //GameManagerActions.current.defeatEvent.AddListener(ResetConditions);
        //GameManagerActions.current.winEvent.AddListener(ResetConditions);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != GameInfo.PLAYER_LAYER)
            return;

        if (!enemiesOnFloor.Any() && !dogsOnFloor.Any())
        {
            //condicion de subir de nivel = matar a todos los enemigos
            GameManagerActions.current.winEvent.Invoke();

        }
        else
        {
            SoundManager.instance.PlayEffect(clipRebote);
            CamerasManager.instance.ShakeCameraNormal(3, 0.6f);
            print((enemiesOnFloor.Count + dogsOnFloor.Count).ToString() +
                    " enemies left, kill\'em all!");
        }
    }
    //public void ResetConditions()
    //{
    //    enemiesOnFloor = new List<EnemyController>();
    //}
}
