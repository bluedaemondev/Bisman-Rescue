using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralGameplay : MonoBehaviour
{
    // Start is called before the first fram
    public static GeneralGameplay instance { get; private set; }
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }


    }
    private void Start()
    {
        GameManagerActions.current.winEvent.AddListener(MoveWinScene);
    }
    public void MoveWinScene()
    {
        SceneManager.LoadScene("floor2");
    }

    public IEnumerator<bool> TimerProto(float timeMax)
    {
        var timer = 0f;
        while ((timer += Time.deltaTime) < timeMax)
        {
            yield return false;
        }
        yield return true;
    }
}
