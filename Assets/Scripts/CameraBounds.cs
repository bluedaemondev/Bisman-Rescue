using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public BoxCollider2D bounds;
    public Transform self;


    // Start is called before the first frame update
    void Start()
    {
        bounds = this.GetComponent<BoxCollider2D>();

    }

    public bool CheckIfPointInBounds(Vector3 point)
    {
        bool res = bounds.bounds.Contains(point);
        return res;
    }
}
