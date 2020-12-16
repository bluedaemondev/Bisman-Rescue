using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerText : MonoBehaviour
{
    public float tMax = 90f; //segundos
    public float tCurrent = 0f;

    public bool defeatOnEnd = true;

    public TMPro.TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tCurrent += Time.deltaTime;

        if(tCurrent >= tMax)
        {
            GameManagerActions.current.defeatEvent.Invoke();
            GameManagerActions.current.defeatEvent.RemoveAllListeners();
        }

        text.text =  (tMax - tCurrent).ToString("n2") + " s. left";
    }
}
