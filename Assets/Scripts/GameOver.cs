using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public GameObject gameOverScreen;
    public Text secondsSurvivedUI;
    public GameObject newHighScoreText;
    public bool gameOver;
    int currentScore;
    int highScore;
    BlockSpawner blockSpawner;
    
	
	void Start () {
        FindObjectOfType<Player>().OnPlayerDeath += OnGameOver;
        highScore = PlayerPrefs.GetInt("HighScore");
        blockSpawner = FindObjectOfType<BlockSpawner>();
	}
	
	void Update () {
		if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(1);
            }
        }
	}

    void OnGameOver ()
    {
        gameOverScreen.SetActive(true);
        secondsSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        currentScore = Mathf.RoundToInt(Time.timeSinceLevelLoad);
        gameOver = true;
        PlayerPrefs.SetInt("TotalTimeSurvived", PlayerPrefs.GetInt("TotalTimeSurvived") + Mathf.RoundToInt(Time.timeSinceLevelLoad));
        PlayerPrefs.SetInt("TotalPlayerDeaths", PlayerPrefs.GetInt("TotalPlayerDeaths") + 1);
        PlayerPrefs.SetInt("TotalBlocksDodged", PlayerPrefs.GetInt("TotalBlocksDodged") + blockSpawner.count);
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            
            newHighScoreText.SetActive(true);
            Debug.Log(currentScore + "is new saved highscore");
        }
    }
}
