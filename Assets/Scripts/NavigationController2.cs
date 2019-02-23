using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NavigationController2 : MonoBehaviour
{
    //Variable declaration
    public GameObject exitPopup;

    //Runs on each update
    void Update()
    {
        //If the escape key is pressed (back button on android) then loads the exit popup
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitPopup.SetActive(true);
        }
    }

    //Loads the main menu if the menu button is pressed.
    public void MenuClickFromGameOver()
    {
        SceneManager.LoadScene(0);
    }

    //Restarts the game upon the button being pressed
    public void RestartTap()
    {
        SceneManager.LoadScene(1);
    }

    //Exits the game upon a yes click
    public void ExitYes()
    {
        Application.Quit();
    }

    //closes the popup if no is clicked.
    public void ExitNo()
    {
        exitPopup.SetActive(false);
    }
}

