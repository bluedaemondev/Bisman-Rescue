using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CursorScript : MonoBehaviour
{
    [Header("Lista de sprites para menu y gameplay")]
    public Sprite cursorSpriteAim;
    public Sprite cursorSpriteMenu;

    [Header("Animator params")]
    public string clickAnimParam = "isShooting";
    public string throwAnimParam = "isThrowing";

    public Animator animator;
    public Transform playerCoords;


    public Vector2 cameraBounds;

    CinemachineVirtualCamera cameraBrain;




    void Awake()
    {
        if (this.animator == null)
        {
            this.animator = GetComponent<Animator>();
        }

        Cursor.visible = false;
    }

    private void Start()
    {
        this.cameraBrain = GameObject.FindObjectOfType<CinemachineVirtualCamera>();

        if (playerCoords == null)
        {
            playerCoords = GameObject.FindGameObjectWithTag("Player").transform;
            //cameraBounds = playerCoords.GetComponentInChildren<CameraBounds>().bounds;
        }
    }

    //private void Update()
    //{
    //    //Click
    //    if (Input.GetMouseButton(0))
    //    {
    //        this.animator.SetBool(clickAnimParam, true);
    //    }
    //    //Throw
    //    else if (Input.GetMouseButton(1))
    //    {
    //        this.animator.SetBool(throwAnimParam, true);
    //    }


    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        this.animator.SetBool(clickAnimParam, false);
    //    }
    //    //Throw
    //    else if (Input.GetMouseButtonUp(1))
    //    {
    //        this.animator.SetBool(throwAnimParam, false);
    //    }
    //}

    void LateUpdate()
    {
        Debug.DrawRay(playerCoords.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), Color.red);


        //if ()
        MoveCursor();
        
        if (Input.GetButton("Fire3"))
            CameraFollowCursor();
    }

    void CameraFollowCursor()
    {
        cameraBrain.Follow = this.transform;
    }

    void MoveCursor()
    {
        var c_point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        c_point.z = 0;
        this.transform.position = c_point;

        transform.position = c_point;

    }

}
