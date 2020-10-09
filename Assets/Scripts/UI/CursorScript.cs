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
        if (playerCoords == null)
        {
            playerCoords = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void Update()
    {
        //Click
        if (Input.GetMouseButton(0))
        {
            this.animator.SetBool(clickAnimParam, true);
        }
        //Throw
        else if (Input.GetMouseButton(1))
        {
            this.animator.SetBool(throwAnimParam, true);
        }


        if (Input.GetMouseButtonUp(0))
        {
            this.animator.SetBool(clickAnimParam, false);
        }
        //Throw
        else if (Input.GetMouseButtonUp(1))
        {
            this.animator.SetBool(throwAnimParam, false);
        }
    }

    void LateUpdate()
    {
        if (Input.GetButton("Fire3"))
            FollowTarget(8);
        else if (Input.GetButtonUp("Fire3"))
            ResetView();
    }

    void ResetView()
    {
        this.transform.position = playerCoords.position;
    }

    void FollowTarget(float maxDist)
    {
        var c_point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        c_point.z = 0;

        var clamped_cam_v = new Vector2(
            Mathf.Clamp(c_point.x, 0, c_point.x + maxDist),
            Mathf.Clamp(c_point.y, 0, c_point.y + maxDist));
        
        this.transform.position = c_point;
    }

}
