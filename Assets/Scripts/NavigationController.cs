using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NavigationController : MonoBehaviour {

    //Screens that will be enabled/disabled.
    public GameObject startScreen;
    public GameObject helpScreen;
    public GameObject statisticsScreen;
    public GameObject settingsScreen;
    public GameObject deletePopup;
    public GameObject carouselScreen;

    //button array, so that button images can be updated.
    public Button[] button;

    //image array, stores the two possible states of the colour select buttons.
    public Sprite[] spriteImage;

    //array to store thw two sound buttons as gameobjects
    public GameObject[] soundControl;

    StartController startController;

    void Start()
    {
        startController = FindObjectOfType<StartController>();
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("SoundSetting") == 1)
        {
            soundControl[0].SetActive(false);
            soundControl[1].SetActive(true);
        }
        else
        {
            soundControl[0].SetActive(true);
            soundControl[1].SetActive(false);
        }
    }

    //button functions in colour select
    public void ColourSelectRed()
    {
        //button gets changed to tickbox
        button[0].GetComponent<Image>().sprite = spriteImage[0];

        //makes sure all other buttons are set to the default state
        button[1].GetComponent<Image>().sprite = spriteImage[1];
        button[2].GetComponent<Image>().sprite = spriteImage[1];
        button[3].GetComponent<Image>().sprite = spriteImage[1];
        button[4].GetComponent<Image>().sprite = spriteImage[1];

        //changes the playerprefs value for when GameScene references it
        PlayerPrefs.SetInt("SelectedColour", 1);
    }

    public void ColourSelectBlue()
    {
        //button gets changed to tickbox
        button[1].GetComponent<Image>().sprite = spriteImage[0];

        //makes sure all other buttons are set to the default state
        button[0].GetComponent<Image>().sprite = spriteImage[1];
        button[2].GetComponent<Image>().sprite = spriteImage[1];
        button[3].GetComponent<Image>().sprite = spriteImage[1];
        button[4].GetComponent<Image>().sprite = spriteImage[1];

        //changes the playerprefs value for when GameScene references it
        PlayerPrefs.SetInt("SelectedColour", 2);
    }

    public void ColourSelectGreen()
    {
        //button gets changed to tickbox
        button[2].GetComponent<Image>().sprite = spriteImage[0];

        //makes sure all other buttons are set to the default state
        button[0].GetComponent<Image>().sprite = spriteImage[1];
        button[1].GetComponent<Image>().sprite = spriteImage[1];
        button[3].GetComponent<Image>().sprite = spriteImage[1];
        button[4].GetComponent<Image>().sprite = spriteImage[1];

        //changes the playerprefs value for when GameScene references it
        PlayerPrefs.SetInt("SelectedColour", 3);
    }

    public void ColourSelectPurple()
    {
        //button gets changed to tickbox
        button[3].GetComponent<Image>().sprite = spriteImage[0];

        //makes sure all other buttons are set to the default state
        button[0].GetComponent<Image>().sprite = spriteImage[1];
        button[1].GetComponent<Image>().sprite = spriteImage[1];
        button[2].GetComponent<Image>().sprite = spriteImage[1];
        button[4].GetComponent<Image>().sprite = spriteImage[1];

        //changes the playerprefs value for when GameScene references it
        PlayerPrefs.SetInt("SelectedColour", 4);
    }

    public void ColourSelectGold()
    {
        //button gets changed to tickbox
        button[4].GetComponent<Image>().sprite = spriteImage[0];

        //makes sure all other buttons are set to the default state
        button[0].GetComponent<Image>().sprite = spriteImage[1];
        button[1].GetComponent<Image>().sprite = spriteImage[1];
        button[2].GetComponent<Image>().sprite = spriteImage[1];
        button[3].GetComponent<Image>().sprite = spriteImage[1];

        //changes the playerprefs value for when GameScene references it
        PlayerPrefs.SetInt("SelectedColour", 5);
    }

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
        PlayerPrefs.SetInt("SelectedColour", 1);
        SceneManager.LoadScene(0);

    }

    //Nav for carousel
    public void CarouselClick()
    {
        startScreen.SetActive(false);
        carouselScreen.SetActive(true);
    }

    public void MenuClickFromCarousel()
    {
        startScreen.SetActive(true);
        carouselScreen.SetActive(false);
    }

    //Mobile support related nav
    public void StartTap()
    {
        SceneManager.LoadScene(1);
    }

    public void SoundDisable()
    {
        soundControl[0].SetActive(false);
        soundControl[1].SetActive(true);
        PlayerPrefs.SetInt("SoundSetting", 1);
    }

    public void SoundEnable()
    {
        soundControl[0].SetActive(true);
        soundControl[1].SetActive(false);
        PlayerPrefs.SetInt("SoundSetting", 0);
    }

    public void ExitYes()
    {
        Application.Quit();
    }

    public void ExitNo()
    {
        startController.exitPopup.SetActive(false);
    }
}
