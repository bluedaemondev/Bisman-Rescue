using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public float moveSpeedMultip = 6.5f;
    public bool activeMovement = true;

    [Header("Componentes de objeto")]
    public Rigidbody2D rbPlayer;
    public SpriteRenderer sprRend;
    public Animator animator;

    [Header("Prefabs usados")]
    public GameObject p_ParticlesShoot;

    [Header("Animator params")]
    public string walkingAnimatorParam = "isWalking";




    void Awake()
    {
        if (this.animator == null)
        {
            this.animator = GetComponent<Animator>();
        }
        if (this.sprRend == null)
        {
            this.sprRend = GetComponentInChildren<SpriteRenderer>();
        }
        if (this.rbPlayer == null)
        {
            this.rbPlayer = GetComponent<Rigidbody2D>();
        }

    }
    private void Start()
    {
        GameManagerActions.current.defeatEvent.AddListener(DisableComponent);
    }
    public void DisableComponent()
    {
        this.enabled = false;
    }

    public void TakeDamage()
    {
        Debug.Log("Damaging... Died.");

        CameraShaker.current.ScreenShake(0.3f, 10f);
        
        if (GameManagerActions.current.defeatEvent != null)
        {
            GameManagerActions.current.defeatEvent.Invoke();
        }
    }

    void Update()
    {
        var inputs = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Move(inputs);

        this.animator.SetBool(walkingAnimatorParam, inputs.x != 0 || inputs.y != 0);
    }

    void Move(Vector2 inputVals)
    {
        if (activeMovement)
        {
            //transform.position += new Vector3(inputVals.x * Time.deltaTime * moveSpeedMultip, inputVals.y * Time.deltaTime * moveSpeedMultip);
            var newPos = new Vector2(transform.position.x + inputVals.x * Time.deltaTime * moveSpeedMultip, transform.position.y + inputVals.y * Time.deltaTime * moveSpeedMultip);
            rbPlayer.MovePosition(newPos);

            //var localScale = this.transform.localScale; // flip
            //localScale.x = Mathf.Abs(localScale.x) * Mathf.Sign(inputVals.x);
            //this.transform.localScale = localScale;
        }

    }
}
