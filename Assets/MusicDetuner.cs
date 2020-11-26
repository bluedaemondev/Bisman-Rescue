using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicDetuner : MonoBehaviour
{
    private AudioSource cl;

    public float x = 4f;

    public float curr = 0f;
    // Start is called before the first frame update
    void Start()
    {
        cl = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(curr >= x)
        {
            curr = 0;
            cl.pitch = Random.Range(-1f, 3f);
            if (cl.pitch == 0)
                cl.pitch += 0.3f;
            //cl.pitch = Mathf.Clamp(cl.pitch, 1, 3);
        }
        else
        {
            curr += Time.deltaTime;
        }
        
    }
}
