using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {
    //Initialises an instance of the audiomanager so long as it doesn't already exist
    private static AudioManager instance = null;

    //Returns the instance instance, used to destroy the object in the PauseAudio script.
    public static AudioManager Instance
    {
        get { return instance; }
    }

    //Runs on start
    private void Start()
    {
        //Enables/Disables the music depending on the sound setting
        if (PlayerPrefs.GetInt("SoundSetting") == 1)
        {
            GetComponent<AudioSource>().enabled = false;
        }
        else
        {
            GetComponent<AudioSource>().enabled = true;
        }
    }
    
    //When the object is "awake" (is loaded in current scene)
    void Awake()
    {
        //Destroys any existing instances if they already exist.
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        //Creates an instance of this game object if it doesn't already exist.
        else
        {
            instance = this;
        }

        //Inserts the gameobject as a DontDestroyOnLoad object
        DontDestroyOnLoad(gameObject);
    }
}
