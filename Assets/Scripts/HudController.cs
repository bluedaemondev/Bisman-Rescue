using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using Text = TMPro.TextMeshProUGUI;


public class HudController : MonoBehaviour
{
    // singleton para poder acceder desde los otros scripts
    public static HudController current;

    public Text roundsText;
    public Text pointsText;
    public Text missionText;

    private void Awake()
    {
        if (current == null)
            HudController.current = this;
    }
    
    public void UpdateRoundsUI(int newVal) {
        this.roundsText.text = newVal + " rnds.";
    }
    public void UpdatePointsUI(int newVal)
    {
        this.pointsText.text = newVal + " pts.";
    }
    public void SetMissionUI(string newMission)
    {
        this.missionText.text = newMission;
    }

}
