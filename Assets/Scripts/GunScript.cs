using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public int currAmmo;
    public int maxAmmo;
    public float gunCooldown = 0.25f;

    public GameObject gunPrefab; // self.gameobject

    // Start is called before the first frame update
    void Start()
    {
        gunPrefab = this.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
