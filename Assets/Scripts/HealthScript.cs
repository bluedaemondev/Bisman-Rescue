using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthScript : MonoBehaviour
{
    public UnityEngine.UI.Image imgLife;
    public float currentLifeAlpha = 0;

    public float minVelocityToGetHit = 14f;

    public Color colorLife;

    [Header("Medidor de estados")]
    public bool canGetKnocked = true;
    public int currentLife = 1;
    public int maxLife = 1;
    public float cameraShakeFactor = 5f;


    [Header("Opcional para jugador")]
    public GameObject deadScreenGO;

    public UnityEvent OnDeathEvent;

    //magnitud hasta 18 tira el mouse

    // Start is called before the first frame update
    void Start()
    {
        imgLife.color = colorLife;
    }
    public void ResetLife()
    {
        //currentLifeAlpha = 0;
        //imgLife.color = new Color(imgLife.color.r, imgLife.color.g, imgLife.color.b, currentLifeAlpha / 100);
        this.currentLife = maxLife;

    }
    public bool GetDamage(int damage)
    {
        bool died = false;

        CamerasManager.ShakeCameraNormal(cameraShakeFactor, .1f);
        this.currentLife -= damage;

        if (currentLife <= 0)
        {
            ////dead
            ////imgLife.color = new Color(imgLife.color.r, imgLife.color.g, imgLife.color.b, 1);
            //if (deadScreenGO != null)
            //{
            //    deadScreenGO.SetActive(true);
            //}
            died = true;
        }

        return died;

    }

    //void SetKnockedState()
    //{
    //    this.GetComponent<WaypointPatrol>().enabled = false;
    //    //this.GetComponent<FetchAndAttack>().isChasing = false;   // chekear esto 27-10
    //    //this.GetComponent<FetchAndAttack>().colTrigger.enabled = false;
    //    this.GetComponent<FetchAndAttack>().enabled = false;

    //    AlteredState alterState;
    //    // miro si lo tiene, sino agrego.
    //    alterState = this.TryGetComponent<AlteredState>(out alterState) ?
    //                        alterState : this.gameObject.AddComponent<AlteredState>();

    //    alterState.spriteAlter = this.sprites.Find(spr => spr.name.Contains("knocked"));
    //    alterState.startSprite = this.sprites.Find(spr => spr != alterState.spriteAlter);

    //    // checkeo de integridad para que funcione el onEnable
    //    // estan medio acopladas las clases, pero lo dejo como solucion rapida.
    //    alterState.enabled = true;
    //}
}
