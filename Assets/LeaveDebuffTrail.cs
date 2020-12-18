using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveDebuffTrail : MonoBehaviour
{
    public int poolSize = 5;
    GameObject[] pool;
    public TrailRenderer trail; // trail del vomito
    public GameObject TrailFollower;
    public GameObject ColliderPrefab;

    public float accuTTrails = 0f;

    public Animator anim;

    void Start()
    {
        anim = this.GetComponent<Animator>();
        //trail = GetComponent<TrailRenderer>();
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(ColliderPrefab);
        }
    }
    void Update()
    {
        if (!trail.isVisible)
        {
            for (int i = 0; i < pool.Length; i++)
            {
                pool[i].gameObject.SetActive(false);

            }
        }
        else
        {
            StartCoroutine(WaitAndPos());
            accuTTrails += 1;
            //TrailCollission();
        }

    }

    IEnumerator WaitAndPos()
    {
        yield return new WaitForSeconds(Time.deltaTime * accuTTrails);
        TrailCollission();
    }

    void TrailCollission()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].gameObject.activeSelf == false)
            {
                pool[i].gameObject.SetActive(true);
                pool[i].gameObject.transform.position = TrailFollower.gameObject.transform.position;
                return;
            }
        }
        accuTTrails = 0;
    }
}
