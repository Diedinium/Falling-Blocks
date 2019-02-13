using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    //variable declaration
    public float speed = 8.5f;
    float screenHalfWidthInWorldUnits;
    float halfPlayerWidth;
    public event System.Action OnPlayerDeath;

    //Stores the value of the currently selected colour, which ranges from 1-5 depending on the button clicked.
    private int selectedColour;

    //Array storing the different available materials.
    public Material[] material;

    //Gets player gameobject for use locally
    public GameObject player;

    //runs on game start
	void Start () {
        //Caclculates half player width
        halfPlayerWidth = transform.localScale.x / 2f;
        //Find half screen width
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
        //Find currently selected colour
        selectedColour = PlayerPrefs.GetInt("SelectedColour");

        //Set the player colour
        SelectColourController();
	}
	
	
	void Update () {
        //Run on each update
        PlayerMovement();
	}


    void PlayerMovement()
    {
        //Get movement axis value
        var inputX = CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime * speed;
        //Calculate new position based on current postion plus value of inputX
        var newXPos = transform.position.x + inputX;
        //Transform player to new position
        transform.position = new Vector2(newXPos, transform.position.y);

        //If the player crosses one side of the map or the other, player is tranformed to other side of map.
        if (transform.position.x < -screenHalfWidthInWorldUnits - halfPlayerWidth)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits - halfPlayerWidth, transform.position.y);
        }
        if (transform.position.x > screenHalfWidthInWorldUnits + halfPlayerWidth)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits + halfPlayerWidth, transform.position.y);
        }
    }

    //If player collides with a block, runs "OnPlayerDeath" action and destroys game object.
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Block")
        {
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }

    //Sets colour based on value of currently selected colour.
    void SelectColourController()
    {
        if (selectedColour == 1)
        {
            player.GetComponent<MeshRenderer>().material = material[0];
        }
        else if (selectedColour == 2)
        {
            player.GetComponent<MeshRenderer>().material = material[1];
        }
        else if (selectedColour == 3)
        {
            player.GetComponent<MeshRenderer>().material = material[2];
        }
        else if (selectedColour == 4)
        {
            player.GetComponent<MeshRenderer>().material = material[3];
        }
        else if (selectedColour == 5)
        {
            player.GetComponent<MeshRenderer>().material = material[4];
        }
        else
        {
            player.GetComponent<MeshRenderer>().material = material[0];
        }
    }
}
