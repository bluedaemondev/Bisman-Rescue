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
            CameraFollow(playerCoords.transform);
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
        //
        Debug.DrawRay(playerCoords.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), Color.red);

        MoveCursor();

        if (Input.GetButton("Fire3"))
            CameraFollow(this.transform); // camara sigue el mouse

        if (Input.GetButtonUp("Fire3")) // reseteo la camara para seguir al jugador
            CameraFollow(playerCoords.transform);

    }

    void CameraFollow(Transform target)
    {
        cameraBrain.Follow = target;
        cameraBrain.transform.position = target.position - new Vector3(0,0,10);
    }

    void MoveCursor()
    {
        var c_point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        c_point.z = 0;
        this.transform.position = c_point;

        transform.position = c_point;

    }

}
