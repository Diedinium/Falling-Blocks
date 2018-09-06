using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NavigationController2 : MonoBehaviour
{

    public void MenuClickFromGameOver()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartTap()
    {
        SceneManager.LoadScene(1);
    }
}

