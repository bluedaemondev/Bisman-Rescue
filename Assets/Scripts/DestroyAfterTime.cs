using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float time = 0.3f;

    void Start()
    {
        Destroy(this.gameObject, time);
    }

}
