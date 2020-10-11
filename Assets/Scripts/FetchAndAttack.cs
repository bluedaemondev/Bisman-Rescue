using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetchAndAttack : MonoBehaviour
{
    public Transform currentTarget;
    public float speedMov = 5;

    public float delayToChase = 0.1f;
    public bool isChasing;


    public CircleCollider2D colTrigger;

    private void Start()
    {
        this.colTrigger = GetComponent<CircleCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == GameInfo.PLAYER_LAYER)
        {
            this.currentTarget = collision.transform;
            isChasing = true;
            //StartCoroutine(DelayChase());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var wallCheck = new RaycastHit2D();

        if (currentTarget != null)
            wallCheck = Physics2D.Raycast(transform.position, currentTarget.position, colTrigger.radius);

        // no me interesa que se mueva si no choco con el player
        if (collision.gameObject.layer != GameInfo.PLAYER_LAYER ||
                wallCheck.collider.gameObject.layer == GameInfo.OBSTACLE_LAYER)
            return;
        // si hay algo en el medio tampoco se mueve

        if (isChasing && Vector2.Distance(transform.position, currentTarget.position) <= 5f)
        {
            // moverse hacia el objetivo
            var movVector = Vector2.MoveTowards(transform.position, currentTarget.position, speedMov * Time.deltaTime);
            transform.position = movVector;
        }
        
    }

    // tbd

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    StartCoroutine(DelayChase());
    //}

    //private void ResetChase()
    //{
    //    this.isChasing = !isChasing;
    //    currentTarget = null;
    //    // invierto para reutilizar tambien en el delay de salida del agro
    //}

}
