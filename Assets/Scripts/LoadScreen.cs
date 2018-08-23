using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour {

    //NOTE TO SELF: Script is redundant, only kept around for future reference. Do not assign the scipt to a game object.


    public GameObject startScreen;
    public GameObject player;
    public GameObject gameOverManager;
    public GameObject blockSpawner;

    bool waitingToStartGame = true;


    void Start () {
        if (startScreen != null)
        {
            startScreen.SetActive(true);
        }
        else
        {
            waitingToStartGame = false;
            Debug.LogError("Start screen has not been set in the inspector, please assign the start screen UI and try again.");
        }
        if (player != null)
        {
            player.SetActive(false);
        }
        else
        {
            Debug.LogError("Player has not been set in the inspector, please assign the start screen UI and try again.");
        }
        if (gameOverManager != null)
        {
            gameOverManager.SetActive(false);
        }
        else
        {
            Debug.LogError("Game over manager has not been set in the inspector, please assign the start screen UI and try again.");
        }
        if (blockSpawner != null)
        {
            blockSpawner.SetActive(false);
        }
        else
        {
            Debug.LogError("blockspawner has not been set in the inspector, please assign the start screen UI and try again.");
        }
    }
	
	
	void Update () {
        if (waitingToStartGame && (Input.GetKeyDown(KeyCode.Space)))
        {
            waitingToStartGame = false;
            if (startScreen != null)
            {
                startScreen.SetActive(false);
            }
            if (player != null)
            {
                player.SetActive(true);
            }
            if (gameOverManager != null)
            {
                gameOverManager.SetActive(true);
            }
            if (blockSpawner != null)
            {
                blockSpawner.SetActive(true);
            }
        }
	}
}
