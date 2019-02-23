using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    //Variable declaration
    public GameObject gameOverScreen;
    public Text secondsSurvivedUI;
    public Text blocksDodgedText;
    public GameObject newHighScoreText;
    public GameObject leftButton;
    public GameObject rightButton;
    private bool gameOver;
    int currentScore;
    int highScore;
    BlockSpawner blockSpawner;
    
	//Runs on start
	void Start () {
        //Subscribes OnPlayerDeath to OnGameOver
        FindObjectOfType<Player>().OnPlayerDeath += OnGameOver;
        //Gets the current highscore value
        highScore = PlayerPrefs.GetInt("HighScore");
        blockSpawner = FindObjectOfType<BlockSpawner>();
	}
	
    //Runs on each update
	void Update () {
        //left in for desktop redundancy
        //If gamevoer is true
		if (gameOver)
        {
            //and spacebar is pressed
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Reload/Replay the level
                SceneManager.LoadScene(1);
            }
        }
	}

    //When OnPlayerDeath is triggered, this method runs.
    void OnGameOver ()
    {
        //Sets the gameover screen state to true (shows it)
        gameOverScreen.SetActive(true);
        //Sets the seconds survived UI to the score the player got.
        secondsSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        //Puts the current score into a variable for later use
        currentScore = Mathf.RoundToInt(Time.timeSinceLevelLoad);
        //Sets the gameover variable to true
        gameOver = true;
        //Sets the blocks dodged amount on game over screen to the number that the player dodged
        blocksDodgedText.text = blockSpawner.count.ToString();
        //Disables the movement buttons
        leftButton.SetActive(false);
        rightButton.SetActive(false);
        //Adds the values gathered during the play session to the playerprefs
        PlayerPrefs.SetInt("TotalTimeSurvived", PlayerPrefs.GetInt("TotalTimeSurvived") + Mathf.RoundToInt(Time.timeSinceLevelLoad));
        PlayerPrefs.SetInt("TotalPlayerDeaths", PlayerPrefs.GetInt("TotalPlayerDeaths") + 1);
        PlayerPrefs.SetInt("TotalBlocksDodged", PlayerPrefs.GetInt("TotalBlocksDodged") + blockSpawner.count);
        //If the current score is more than the highscore, sets the new value.
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            //Shows the "New high score!" text if a new score is acheived.
            newHighScoreText.SetActive(true);
            Debug.Log(currentScore + "is new saved highscore");
        }
    }

    //Returns the current gameover state, for use in other scripts
    public bool ReturnGameOverState()
    {
        return gameOver;
    }
}
