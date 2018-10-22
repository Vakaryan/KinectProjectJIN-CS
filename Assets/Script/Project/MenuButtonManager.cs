using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonManager : MonoBehaviour
{

    public enum MenuStates { Main, Tuto };
    public MenuStates currentState;
    public GameObject mainMenuPanel;
    public GameObject tutoMenuPanel;



    void Awake()
    {
        currentState = MenuStates.Main;
    }


    void Update()
    {
        switch (currentState)
        {
            case MenuStates.Main:
                mainMenuPanel.SetActive(true);
                tutoMenuPanel.SetActive(false);
                break;
            case MenuStates.Tuto:
                tutoMenuPanel.SetActive(true);
                mainMenuPanel.SetActive(false);
                break;
        }
    }





    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartLevel()
    {
        SceneManager.LoadScene(1);
    }


    public void ToMainMenu()
    {
        currentState = MenuStates.Main;
    }

    public void ToTutoMenu()
    {
        currentState = MenuStates.Tuto;
    }

    public void ToTitleScreen()
    {
        SceneManager.LoadScene(0);
        currentState = MenuStates.Main;
    }
}
