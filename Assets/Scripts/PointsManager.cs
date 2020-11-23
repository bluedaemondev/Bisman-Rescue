using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public static PointsManager current { get; private set; }

    public int total = 0;
    public float comboMultiplier = 1; 
    public float timeToResetComboMultiplier = 4.5f; // cuanto tiempo pasa hasta que puede hacer otro golpe y sumar al combo
    public float currentTimeInCombo = 0; // timer actual

    // Start is called before the first frame update
    void Awake()
    {
        if (current == null)
            current = this;
    }

    private void Update()
    {
        currentTimeInCombo += Time.deltaTime;

        if(currentTimeInCombo >= timeToResetComboMultiplier)
        {
            //ResetComboMultiplier();
            print("reset combo");
            currentTimeInCombo = 0;
        }
    }

    public void AddKillToTotal(int pts)
    {
        PointsManager.current.total += System.Convert.ToInt32(pts * PointsManager.current.comboMultiplier);
        SumToComboMultiplier();

        HudController.current.UpdatePointsUI(PointsManager.current.total);
        Debug.Log("total actual = " + PointsManager.current.total);
    }

    public float SumToComboMultiplier()
    {
        return PointsManager.current.comboMultiplier++;
    }

    public void ResetComboMultiplier()
    {
        PointsManager.current.comboMultiplier = 1;
    }
}
