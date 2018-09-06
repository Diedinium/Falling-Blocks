using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    public float speed = 8.5f;
    float screenHalfWidthInWorldUnits;
    float halfPlayerWidth;
    public event System.Action OnPlayerDeath;

    //Stores the value of the currently selected colour, which ranges from 1-5 depending on the button clicked.
    private int selectedColour;

    //Array storing the different available materials.
    public Material[] material;

    public GameObject player;


	void Start () {
        halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
        selectedColour = PlayerPrefs.GetInt("SelectedColour");

        SelectColourController();
	}
	
	
	void Update () {
        PlayerMovement();
	}


    void PlayerMovement()
    {
        float inputX = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if (transform.position.x < -screenHalfWidthInWorldUnits - halfPlayerWidth)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits - halfPlayerWidth, transform.position.y);
        }
        if (transform.position.x > screenHalfWidthInWorldUnits + halfPlayerWidth)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits + halfPlayerWidth, transform.position.y);
        }
    }

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
