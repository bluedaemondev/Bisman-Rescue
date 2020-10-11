using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExitStairs : MonoBehaviour
{
    public static List<EnemyController> enemiesOnFloor= new List<EnemyController>();

    private void Start()
    {

        //GameManagerActions.current.defeatEvent.AddListener(ResetConditions);
        //GameManagerActions.current.winEvent.AddListener(ResetConditions);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!enemiesOnFloor.Any())
        {
            //condicion de subir de nivel = matar a todos los enemigos
            GameManagerActions.current.winEvent.Invoke();
        }
        else
        {
            print(enemiesOnFloor.Count + " enemies left, kill\'em all!");
        }
    }
    //public void ResetConditions()
    //{
    //    enemiesOnFloor = new List<EnemyController>();
    //}
}
