using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DogControllerBB : MonoBehaviour
{
    public string isPatrolingParam = "isPatroling";
    public string isIdleParam = "isIdle";
    public string isBarkingParam = "isBarking";

    public WaypointPatrol waypointComponent;
    public RandomStayInPlace idleComponent;
    public BarkAndBring barkComponent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetCurrentState(EnemyState state)
    {
        this.currentState = state;
        switch (state) { }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
