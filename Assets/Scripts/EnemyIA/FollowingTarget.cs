using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingTarget : MonoBehaviour
{
    public float speedMultipier = 1.5f;

    Vector2 lastSeenPos;
    Rigidbody2D rbSelf;

    public void SetFollowTarget(Vector2 pos)
    {
        this.lastSeenPos = pos;
    }
    private void Start()
    {
        this.rbSelf = this.GetComponent<Rigidbody2D>();
    }
    public void Follow()
    {
        if (lastSeenPos != null && Vector2.Distance(transform.position,lastSeenPos) >= 1)
        {
            var movVector = Vector2.MoveTowards(transform.position, lastSeenPos, speedMultipier * Time.deltaTime);
            //transform.position = movVector;

            rbSelf.MovePosition(movVector);
        }
    }
}
