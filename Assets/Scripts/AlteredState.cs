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

    //desactivo el movimiento/busqueda
    private void OnEnable()
    {
        this.GetComponent<WaypointPatrol>().enabled = false;

        this.GetComponent<FetchAndAttack>().enabled = false;
        this.GetComponent<FetchAndAttack>().isChasing = false;
        this.GetComponent<FetchAndAttack>().colTrigger.enabled = false;
    }
    private void Start()
    {
        this.state = new State
        {
            name = "knocked",
            descOpt = "stays in ground for " + currentTimer + " seconds."
        };
        this.sprRend = this.GetComponentInChildren<SpriteRenderer>();

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
        this.GetComponent<FetchAndAttack>().enabled = true;
        this.GetComponent<FetchAndAttack>().colTrigger.enabled = true;

        this.GetComponent<WaypointPatrol>().enabled = true;
        this.currentTimer = TIME_GET_UP;
        this.sprRend.sprite = startSprite;
        this.enabled = false; // Cuando se levanta el enemigo, se desactiva el estado y reseteo

    }
}
