using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiamiPursuit : MonoBehaviour
{
    // se marca el objetivo para disparar
    public GameObject target;

    public float distanceRayPursuit = 0.1f; // en unidades
    public float timeDelayToStartPursuit = 0.5f;
    public float speed = 10;

    public float angleObstacleEvasion = 25; // 25 y -25

    public bool chasing;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    bool CastRouteRay()
    {
        bool res = false;

        //Vector3 rotatedVector = Quaternion.AngleAxis(angle, Vector3.forward) * (Vector3.up * distanceRayPursuit - transform.position);
        //Debug.DrawRay(transform.position, rotatedVector);
        //print(rotatedVector);

        //Physics2D.Raycast(transform.position, )

        


        return res;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
