using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum DogState
{
    idle,
    patroling,
    barking,
    dead
}
public class DogControllerBB : MonoBehaviour
{
    public DogState currentState;

    public Animator animator;

    public string isPatrolingParam = "isPatroling";
    public string isIdleParam = "isIdle";
    public string isBarkingParam = "isBarking";
    public string isDeadParam = "isDeadTrigg";

    public bool isPatroling = false;
    public bool isBarking = false;
    public bool isIdle = false;
    public bool isDead = false;


    public WaypointPatrol waypointComponent;
    public RandomStayInPlace idleComponent;
    public BarkAndBring barkComponent;


    // Start is called before the first frame update
    void Start()
    {
        isPatroling = true;
        this.animator = this.GetComponent<Animator>();
        this.SetCurrentState(DogState.patroling);

        //ExitStairs.enemiesOnFloor.Add(this);
    }

    public void SetCurrentState(DogState state)
    {
        this.currentState = state;
        switch (state) {
            case DogState.barking:
                isBarking = true;
                isPatroling = false;
                isIdle = false;
                break;
            case DogState.idle:
                isBarking = false;
                isPatroling = false;
                isIdle = true;
                break;
            case DogState.patroling:
                isBarking = false;
                isPatroling = true;
                isIdle = false;
                break;
            case DogState.dead:
                isDead = true;
                animator.SetTrigger(isDeadParam);
                break;
        }

        animator.SetBool(isPatrolingParam, isPatroling);
        animator.SetBool(isIdleParam, isIdle);
        animator.SetBool(isBarkingParam, isBarking);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
