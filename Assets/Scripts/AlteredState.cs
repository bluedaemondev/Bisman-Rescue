using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlteredState : MonoBehaviour
{
    public const float TIME_GET_UP = 3f;
    public float currentTimer = TIME_GET_UP;

    public State state;

    public SpriteRenderer sprRend;
    public Sprite startSprite;
    public Sprite spriteAlter;

    private CircleCollider2D radiusForKill; // trigger para permitir matar un enemigo noqueado
    public float radiusKill = 2.4f; // configurable del editor para el rango
    public KeyCode killKey = KeyCode.Space;
    
    GameObject corpsePrefab;


    //desactivo el movimiento/busqueda
    private void OnEnable()
    {
       
        ShootTarget opt_shooter;
        TryGetComponent<ShootTarget>(out opt_shooter);
        if (opt_shooter)
            opt_shooter.enabled = false;

        if (radiusForKill)
            radiusForKill.enabled = true;
    }
    private void Start()
    {
        this.state = new State
        {
            name = "knocked",
            descOpt = "stays in ground for " + currentTimer + " seconds."
        };
        this.sprRend = this.GetComponentInChildren<SpriteRenderer>();
        
        this.radiusForKill = this.gameObject.AddComponent<CircleCollider2D>();
        this.radiusForKill.isTrigger = true;
        this.radiusForKill.radius = this.radiusKill;

        this.corpsePrefab = GetComponent<EnemyController>().bloodCorpsePrefab;

        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(killKey) &&
            collision.gameObject.layer == GameInfo.PLAYER_LAYER)
        {
            GameObject corpse = Instantiate(corpsePrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if (currentTimer <= 0)
            GetUp();
        else
        {
            this.sprRend.sprite = spriteAlter;
        }

        currentTimer -= Time.deltaTime;
        // descuento hasta que se levante y reactivo el componente de busqueda y ataque
    }

    private void GetUp()
    {
        // agregue el && para fijarme si antes de que se entre en el estado alterado
        // tenia activado el componente. si dispara no viene activado por defecto, sino que se agrega por codigo y se
        // llama a enable ahi

        //nota: borre eso de arriba, creo que no sirvio para nada

        this.GetComponent<FetchAndAttack>().enabled = true ;
        this.GetComponent<FetchAndAttack>().colTrigger.enabled = true;

        this.GetComponent<WaypointPatrol>().enabled = true;
        this.currentTimer = TIME_GET_UP;
        this.sprRend.sprite = startSprite;

        this.radiusForKill.enabled = false; // saco la posibilidad de matarlo

        this.enabled = false; // Cuando se levanta el enemigo, se desactiva el estado y reseteo
    }
}
