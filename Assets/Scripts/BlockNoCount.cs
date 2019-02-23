using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockNoCount : MonoBehaviour {

    //variable declaration
    public Vector2 speedMinMax;
    public float speed;
    BlockSpawner blockSpawner;
    float screenWidthLocal;

    //Runs on start
    void Start()
    {
        //Find the block spanwer and puts it's methods/public variables into "blockSpawner"
        blockSpawner = FindObjectOfType<BlockSpawner>();
        //Finds screen width
        screenWidthLocal = Camera.main.orthographicSize;
        //Sets the speed based on the difficulty percentage
        speed = Mathf.Lerp(speedMinMax.y, speedMinMax.x, Difficulty.GetDifficultyPercent());
    }

    //Runs on each update
    void Update()
    {
        //Run the block movement function
        BlockMovement();
    }

    //Controls the block movement
    void BlockMovement()
    {
        //Moves the block downwards in relation to it's self space
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.Self);
        //Destroys the block if it goes below the screen width and half blocksize.
        if (transform.position.y <= -screenWidthLocal - blockSpawner.blockSize)
        {
            Destroy(gameObject);
        }
    }
}
