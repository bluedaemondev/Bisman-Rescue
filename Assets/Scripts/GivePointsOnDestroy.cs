using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivePointsOnDestroy : MonoBehaviour
{
    public int pointsGivenOnDeath = 100;

    private void OnDestroy()
    {
         PointsManager.current.AddKillToTotal(pointsGivenOnDeath);
    }
}
