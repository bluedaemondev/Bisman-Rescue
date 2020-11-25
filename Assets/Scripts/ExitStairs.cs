using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExitStairs : MonoBehaviour
{
    //public static List<EnemyController> enemiesOnFloor= new List<EnemyController>();
    public static List<EnemyControllerBB> enemiesOnFloor = new List<EnemyControllerBB>();

    public AudioClip clipRebote;

    
    private void Awake()
    {
        //enemiesOnFloor = new List<EnemyController>();
        enemiesOnFloor = new List<EnemyControllerBB>();
        //GameManagerActions.current.defeatEvent.AddListener(ResetConditions);
        //GameManagerActions.current.winEvent.AddListener(ResetConditions);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != GameInfo.PLAYER_LAYER)
            return;

        if (!enemiesOnFloor.Any())
        {
            //condicion de subir de nivel = matar a todos los enemigos
            GameManagerActions.current.winEvent.Invoke();

        }
        else
        {
            SoundManager.instance.PlayEffect(clipRebote);
            CamerasManager.instance.ShakeCameraNormal(3, 0.6f);
            print(enemiesOnFloor.Count + " enemies left, kill\'em all!");
        }
    }
    //public void ResetConditions()
    //{
    //    enemiesOnFloor = new List<EnemyController>();
    //}
}
