using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerActions : MonoBehaviour
{
    public KeyCode Restart = KeyCode.R;
    public KeyCode Exit = KeyCode.Escape;

    void LateUpdate()
    {
        if (Input.GetKeyDown(Restart))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

#if UNITY_STANDALONE || UNITY_EDITOR
        if (Input.GetKeyDown(Exit))
        {
            Application.Quit();
        }
#endif
    }
}
