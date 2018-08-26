using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour {

    int highScore;
    int blocksDodged;
    int totalTimeSurvived;
    int totalPlayerDeaths;
    public Text highScoreText;
    public Text highScoreText2;
    public Text totalPlayerDeathsText;
    public Text totalTimeSurvivedtext;
    public Text totalblocksdodgedtext;

    


    void Start()
    {
        LoadStats();

    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
        highScoreText.text = highScore.ToString();
        highScoreText2.text = highScore.ToString();
        totalPlayerDeathsText.text = totalPlayerDeaths.ToString();
        totalTimeSurvivedtext.text = totalTimeSurvived.ToString();
        totalblocksdodgedtext.text = blocksDodged.ToString();

	}

    void LoadStats()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        totalPlayerDeaths = PlayerPrefs.GetInt("TotalPlayerDeaths");
        totalTimeSurvived = PlayerPrefs.GetInt("TotalTimeSurvived");
        blocksDodged = PlayerPrefs.GetInt("TotalBlocksDodged");
    }

}
