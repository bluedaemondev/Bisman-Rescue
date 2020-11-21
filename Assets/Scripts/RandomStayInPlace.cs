using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class RandomStayInPlace : MonoBehaviour
{
    public int chanceVal = 10; // 10%, a chequear
    //public float timeStayInPlace = 5f;

    //[Header("Previsional animation params. (not working)")]
    //public Animator anim;
    

    /// <summary>
    /// Utilizar en algun momento que sea interesante, como al llegar
    /// a un waypoint para que descanse y luego continue.
    /// </summary>
    /// <returns>Devuelve si se quedo o no</returns>
    public bool StaysInPlace()
    {
        var rChance = Random.Range(0, 100);
        // genero un random que puede dejar al enemigo en el lugar por un rato, para
        // que no esten tan predecibles siempre

        bool res = rChance < chanceVal;

        if (res)
        {
            // quiero que deje de atacar si esta distraido?
            //this.GetComponent<FetchAndAttack>().enabled = false;
            //this.GetComponent<WaypointPatrol>().enabled = false;
            Debug.Log("staying");
            this.GetComponent<EnemyControllerBB>().SetCurrentState(EnemyState.idle);
            
            //StartCoroutine(RestartBehaviours());
        }


        return res;

    }

    //IEnumerator RestartBehaviours() // devolver patrullaje
    //{
    //    //Debug.Log("restarting " + this.name + " in t=" + this.timeStayInPlace);


    //    yield return new WaitForSeconds(timeStayInPlace);
    //    //this.GetComponent<WaypointPatrol>().enabled = true;

    //    //this.GetComponent<FetchAndAttack>().enabled = true;
    //    //this.GetComponent<FetchAndAttack>().colTrigger.enabled = true;

    //    Debug.Log("CR " + this.name + " DONE!, ENABLING PATROL");

    //}

}
