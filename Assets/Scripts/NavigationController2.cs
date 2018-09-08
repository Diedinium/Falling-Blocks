using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NavigationController2 : MonoBehaviour
{

    public GameObject exitPopup;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitPopup.SetActive(true);
        }
    }

    public void MenuClickFromGameOver()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartTap()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitYes()
    {
        Application.Quit();
    }

    public void ExitNo()
    {
        exitPopup.SetActive(false);
    }
}

