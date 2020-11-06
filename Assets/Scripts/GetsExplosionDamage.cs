using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthScript))]
public class GetsExplosionDamage : MonoBehaviour
{
    /// <summary>
    /// TErminarrr!!!
    /// 
    /// 
    /// </summary>

    public HealthScript hScript;
    public int explosionDamageTaken = 2;

    private void Awake()
    {
        if (hScript == null)
            hScript = this.GetComponent<HealthScript>();

    }

    public void GetDamage()
    {
        hScript.GetDamage(explosionDamageTaken);
    }
}
