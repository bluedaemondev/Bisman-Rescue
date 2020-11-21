using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxialMovementKB : MonoBehaviour
{
    public float moveSpeedMultip = 6.5f;

    public Rigidbody2D rbPlayer;
    public SpriteRenderer sprRend;

    public PlayerControllerBB controller;

    Vector2 inputVals;

    // Start is called before the first frame update
    void Start()
    {
        if (rbPlayer == null)
            this.rbPlayer = this.GetComponent<Rigidbody2D>();
        if (sprRend == null)
            this.sprRend = this.GetComponent<SpriteRenderer>();

        if (controller == null)
            this.controller = this.GetComponent<PlayerControllerBB>();
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        inputVals = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(inputVals.x != 0 || inputVals.y != 0)
        {
            controller.SetCurrentState(PlayerState.walking);

            var newPos = new Vector2(transform.position.x + inputVals.x * Time.deltaTime * moveSpeedMultip, transform.position.y + inputVals.y * Time.deltaTime * moveSpeedMultip);
            rbPlayer.MovePosition(newPos);

            //transform.position += new Vector3(inputVals.x * Time.deltaTime * moveSpeedMultip, inputVals.y * Time.deltaTime * moveSpeedMultip);

            //flip sprite
            var localScale = this.sprRend.transform.localScale; // flip
            localScale.x = Mathf.Abs(localScale.x) * Mathf.Sign(inputVals.x);
            this.sprRend.transform.localScale = localScale;

        }
        else
        {
            controller.SetCurrentState(PlayerState.idle);
            rbPlayer.velocity = Vector2.zero;
        }


    }
}
