using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;


public class HudController : MonoBehaviour
{
    // singleton para poder acceder desde los otros scripts
    public static HudController current;

    public Text roundsText;
    public Text pointsText;
    public Text missionText;

    public GameObject defeatPanelPrefab;

    private void Awake()
    {
        if (current == null)
            HudController.current = this;
    }
    private void Start()
    {
        GameManagerActions.current.defeatEvent.AddListener(InstantiateDefeatPanel);
    }

    public void InstantiateDefeatPanel()
    {
        var pnl = Instantiate(defeatPanelPrefab, transform.position, Quaternion.identity, this.transform);
    }

    public void UpdateRoundsUI(int curVal, int maxVal)
    {
        if (maxVal != 0)
            this.roundsText.text = curVal + "/" + maxVal + " rnds.";
        else
            this.roundsText.text = "melee";

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
