﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;

public enum EnumPuerta
{
    Azul,
    Verde,
    Naranja
}
public class HudController : MonoBehaviour
{
    // singleton para poder acceder desde los otros scripts
    public static HudController current { get; private set; }

    public Text roundsText;
    public Text pointsText;
    public Text missionText;

    public GameObject defeatPanelPrefab;

    [Header("Tarjetas para desbloquear areas")]
    public GameObject cardAzul;
    public GameObject cardVerde;
    public GameObject cardNaranja;


    private void Awake()
    {
        if (current == null)
            current = this;
        
        cardAzul.SetActive(false);
        cardVerde.SetActive(false);
        cardNaranja.SetActive(false);


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

    public void AddCardToUI(EnumPuerta val)
    {
        switch (val) {
            case EnumPuerta.Azul:
                cardAzul.SetActive(true);
                break;
            case EnumPuerta.Verde:
                cardVerde.SetActive(true);
                break;
            case EnumPuerta.Naranja:
                cardNaranja.SetActive(true);
                break;
        }

    }

}
