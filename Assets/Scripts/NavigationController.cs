using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationController : MonoBehaviour {

    public GameObject startScreen;
    public GameObject helpScreen;
    public GameObject statisticsScreen;
    public GameObject settingsScreen;
    public GameObject deletePopup;

    //Nav from start screen
    public void StatsClickFromStart()
    {
        startScreen.SetActive(false);
        statisticsScreen.SetActive(true);
    }

    public void HelpClickFromStart()
    {
        startScreen.SetActive(false);
        helpScreen.SetActive(true);
    }

    public void SettingsClickFromStart()
    {
        startScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }

    //Nav from stats screen
    public void MenuClickFromStats()
    {
        statisticsScreen.SetActive(false);
        startScreen.SetActive(true);
    }

    public void HelpClickFromStats()
    {
        statisticsScreen.SetActive(false);
        helpScreen.SetActive(true);
    }

    public void SettingsClickFromStats()
    {
        statisticsScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }

    //Nav from help screen
    public void MenuClickFromHelp()
    {
        helpScreen.SetActive(false);
        startScreen.SetActive(true);
    }

    public void StatsClickFromHelp()
    {
        helpScreen.SetActive(false);
        statisticsScreen.SetActive(true);
    }

    public void SettingsClickFromHelp()
    {
        helpScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }

    //Nav from settings screen
    public void MenuClickFromSettings()
    {
        settingsScreen.SetActive(false);
        startScreen.SetActive(true);
    }

    public void StatsClickFromSettings()
    {
        settingsScreen.SetActive(false);
        statisticsScreen.SetActive(true);
    }

    public void HelpClickFromSettings()
    {
        settingsScreen.SetActive(false);
        helpScreen.SetActive(true);
    }

    //Nav for deleting user data
    public void DeleteClick()
    {
        deletePopup.SetActive(true);
    }

    public void CancelClick()
    {
        deletePopup.SetActive(false);
    }

    public void YesClick()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.SetInt("TotalPlayerDeaths", 0);
        PlayerPrefs.SetInt("TotalTimeSurvived", 0);
        PlayerPrefs.SetInt("TotalBlocksDodged", 0);
        SceneManager.LoadScene(0);
        
    }

}
