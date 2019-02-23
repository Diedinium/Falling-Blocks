using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAudio : MonoBehaviour {

	// Use this for initialization
    //Destroys the audiomanager instance if it is loaded into a DontDestroyOnLoad object in the start menu
	void Start () {
        //If the audiomanager "Instance" is not null (i.e it exists) then destroys the object.
        if (AudioManager.Instance != null)
        {
            Destroy(AudioManager.Instance.gameObject);
        }
    }
}
