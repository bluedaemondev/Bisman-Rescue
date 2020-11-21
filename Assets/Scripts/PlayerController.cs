using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HealthScript), typeof(Rigidbody2D), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeedMultip = 6.5f;
    public bool activeMovement = true;

    [Header("Componentes de objeto")]
    public SpriteRenderer sprRend;
    public Animator animator;
    public GameObject guiPlayer;

    [Header("Prefabs usados")]
    public GameObject p_ParticlesShoot;

    [Header("Animator params")]
    public string walkingAnimatorParam = "isWalking";


    private Rigidbody2D rbPlayer;
    private HealthScript hScript;


    void Awake()
    {
        this.animator = GetComponent<Animator>();
        this.sprRend = GetComponentInChildren<SpriteRenderer>();
        this.rbPlayer = GetComponent<Rigidbody2D>();
        this.hScript = GetComponent<HealthScript>();

    }
    private void Start()
    {
        guiPlayer.SetActive(true);
        GameManagerActions.current.defeatEvent.AddListener(DisableComponent);
    }
    public void DisableComponent()
    {
        this.enabled = false;
    }

    public void TakeDamage()
    {
        //Debug.Log("Damaging... Died.");
        //CamerasManager.ShakeCameraNormal(cameraShakeOnDmg, 0.2f);

        bool died = hScript.GetDamage(hScript.maxLife);

        if (died && GameManagerActions.current.defeatEvent != null)
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
            var newPos = new Vector2(transform.position.x + inputVals.x * Time.deltaTime * moveSpeedMultip, transform.position.y + inputVals.y * Time.deltaTime * moveSpeedMultip);
            rbPlayer.MovePosition(newPos);

            //transform.position += new Vector3(inputVals.x * Time.deltaTime * moveSpeedMultip, inputVals.y * Time.deltaTime * moveSpeedMultip);
            
            //flip sprite
            var localScale = this.sprRend.transform.localScale; // flip
            localScale.x = Mathf.Abs(localScale.x) * Mathf.Sign(inputVals.x);
            this.sprRend.transform.localScale = localScale;
        }

    }
}
