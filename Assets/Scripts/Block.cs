using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    //Variable declaration
    public Vector2 speedMinMax;
    public float speed;
    BlockSpawner blockSpawner;
    float screenWidthLocal;

    //On game start
    void Start()
    {
        //Find the blockspanwer object, put methods/variables into blockSpawner variable
        blockSpawner = FindObjectOfType<BlockSpawner>();
        //Calculate camera size
        screenWidthLocal = Camera.main.orthographicSize;
        //Set speed to be between two values on a Lerp scale function
        speed = Mathf.Lerp(speedMinMax.y, speedMinMax.x, Difficulty.GetDifficultyPercent());
    }

    //On each update
    void Update () {
        BlockMovement();
	}

    public void BlockMovement ()
    {
        //Move down by the speed times by time between frames. Move in local space
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.Self);
        
        //If the block is below the bottom of the camera, and it's own half width, destroy the block and add 1 to Count
        if (transform.position.y <= -screenWidthLocal - blockSpawner.blockSize)
        {
            Destroy(gameObject);
            blockSpawner.count++;
            print("Destroyed");
        }
    }
}
