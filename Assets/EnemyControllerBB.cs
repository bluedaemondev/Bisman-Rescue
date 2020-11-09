using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyStates
{
    patroling,
    idle,
    pursuiting,
    attacking,
    dead
}

public class EnemyControllerBB : MonoBehaviour
{
    private Animator animator;
    private WaypointPatrol wPatrolOld;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
