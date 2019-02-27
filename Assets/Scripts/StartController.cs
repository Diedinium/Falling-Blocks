using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour {

    //interger variables for storing the values pulled from the playerprefs.
    int highScore;
    int blocksDodged;
    int totalTimeSurvived;
    int totalPlayerDeaths;
    int selectedColour;

    //Public text variables, for storing text that needs to be updated by the playerprefs.
    public Text highScoreText;
    public Text highScoreText2;
    public Text totalPlayerDeathsText;
    public Text totalTimeSurvivedtext;
    public Text totalblocksdodgedtext;
    public Text averageScoreText;

    //public button variables, for holding the colour selection buttons that will need to be disabled/enabled.
    public Button button0;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    //More public text variables for storing the "Locked" text
    public GameObject[] Locked;

    //Stores an image for the currently selected colour button
    public Sprite spriteImage;

    //stores exit popup as gameobject
    public GameObject exitPopup;

    //The scene reloads whenever the player returns from the GameScene, meaning these are fine being in the start function
    //because it will not be possible for a player to incur changed stats while in the StartScene.
    void Start()
    {
        //Loads the stats and checks to see if buttons have been unlocked in "Colour select" each time the scene is loaded
        LoadStats();

        //Controls which of the carousel buttons can be interacted with
        ButtonInteractableController();

        //Changes the button state to a "ticked" variant when clicked
        CurrentlySelectedButton();

        //Sets the values of these UI text elements upon load
        highScoreText.text = highScore.ToString();
        highScoreText2.text = highScore.ToString();
        totalPlayerDeathsText.text = totalPlayerDeaths.ToString();
        totalTimeSurvivedtext.text = totalTimeSurvived.ToString();
        totalblocksdodgedtext.text = blocksDodged.ToString();
    }

    //Runs on each update
    void Update () {
        //Loads the GameScene when "Space" is pressed (Left in for redundancy)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }

        //Brings up exit page if Escape (Back button in Android) is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitPopup.SetActive(true);
        }

        //Changes the various text fields that show stats.
        if (PlayerPrefs.GetInt("TotalTimeSurvived") != 0 && PlayerPrefs.GetInt("TotalPlayerDeaths") != 0)
        {
            averageScoreText.text = (PlayerPrefs.GetInt("TotalTimeSurvived") / PlayerPrefs.GetInt("TotalPlayerDeaths")).ToString();
        }

        //Controls if the music is enabled or disabled
        if (PlayerPrefs.GetInt("SoundSetting") == 1)
        {
            GetComponent<AudioSource>().enabled = false;
        }
        else
        {
            GetComponent<AudioSource>().enabled = true;
        }
	}

    //Loads the stats that are stored in playerprefs into the game.
    private void LoadStats()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        totalPlayerDeaths = PlayerPrefs.GetInt("TotalPlayerDeaths");
        totalTimeSurvived = PlayerPrefs.GetInt("TotalTimeSurvived");
        blocksDodged = PlayerPrefs.GetInt("TotalBlocksDodged");
        selectedColour = PlayerPrefs.GetInt("SelectedColour");
    }

    //Controls which carousel buttons are interactable
    private void ButtonInteractableController()
    {
        //Controls if the "blue" colour option is available
        if (totalPlayerDeaths >= 100)
        {
            button1.interactable = true;
            Locked[0].SetActive(false);
        }
        else
        {
            button1.interactable = false;
            Locked[0].SetActive(true);
        }

        //Controls if the "Green" option is available
        if (blocksDodged >= 5000)
        {
            button2.interactable = true;
            Locked[1].SetActive(false);
        }
        else
        {
            button2.interactable = false;
            Locked[1].SetActive(true);
        }

        //Controls if the "Purple" option is available
        if (totalTimeSurvived >= 1800)
        {
            button3.interactable = true;
            Locked[2].SetActive(false);
        }
        else
        {
            button3.interactable = false;
            Locked[2].SetActive(true);
        }

        //controls if the "Gold" option is available
        if (totalTimeSurvived >= 3600 && highScore >= 80)
        {
            button4.interactable = true;
            Locked[3].SetActive(false);
        }
        else
        {
            button4.interactable = false;
            Locked[3].SetActive(true);
        }
    }

    //Sets the currently selected button to have a checkbox icon if it is clicked
    void CurrentlySelectedButton()
    {
        if (selectedColour == 1)
        {
            button0.GetComponent<Image>().sprite = spriteImage;
        }
        else if (selectedColour == 2)
        {
            button1.GetComponent<Image>().sprite = spriteImage;
        }
        else if (selectedColour == 3)
        {
            button2.GetComponent<Image>().sprite = spriteImage;
        }
        else if (selectedColour == 4)
        {
            button3.GetComponent<Image>().sprite = spriteImage;
        }
        else if (selectedColour == 5)
        {
            button4.GetComponent<Image>().sprite = spriteImage;
        }
        else
        {
            button0.GetComponent<Image>().sprite = spriteImage;
        }
    }

}
