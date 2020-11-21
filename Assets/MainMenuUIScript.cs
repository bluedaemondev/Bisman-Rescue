using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIScript : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject creditsPanel;
    public GameObject howToPlayPanel;


    private void Awake()
    {
        ShowMainMenu();
    }
    public void ShowMainMenu()
    {
        mainPanel.SetActive(true);

        creditsPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
    }
    public void PlayNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ShowCredits()
    {
        creditsPanel.SetActive(true);
        
        mainPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
    }
    public void ShowHowToPlay()
    {
        howToPlayPanel.SetActive(true);
        
        mainPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
