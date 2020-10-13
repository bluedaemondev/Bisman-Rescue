using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManagerActions : MonoBehaviour
{
    public static GameManagerActions current;

    public KeyCode Restart = KeyCode.R;
    public KeyCode Exit = KeyCode.Escape;

    public UnityEvent defeatEvent;
    public UnityEvent winEvent;

    private void Awake()
    {
        GameManagerActions.current = this;

        if (defeatEvent == null)
            defeatEvent = new UnityEvent();
        if (winEvent== null)
            winEvent = new UnityEvent();

    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(Restart))
        {
            ReloadScene();
        }

#if UNITY_STANDALONE || UNITY_EDITOR
        if (Input.GetKeyDown(Exit))
        {
            ExitGame();
        }
#endif

    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
