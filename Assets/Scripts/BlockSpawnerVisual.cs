using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnerVisual : MonoBehaviour {
    //This class is used for spawning visual only blocks at a set speed, used in the main menu.

    //variable declaration
    public GameObject fallingBlockPrefab;
    public Vector2 InstantaionTimeMinMax;
    public Vector2 screenHalfSizeWorldUnits;
    public int count;
    Vector3 randomSize;
    public float blockSize;
    float nextSpawnTime;
    public float secondsBetweenSpawns;

    //Runs on start
    void Start()
    {
        //Find the half width of the screen
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    //Runs on each update
    void Update()
    {
        BlockSpawn();
    }

    //Spawns no count block variants
    void BlockSpawn()
    {
        //Spawns new block when time is more than the nextSpawn time.
        if (Time.time > nextSpawnTime)
        {
            //decides the seconds between spawns value based on the difficulty percentage between two values.
            secondsBetweenSpawns = Mathf.Lerp(InstantaionTimeMinMax.y, InstantaionTimeMinMax.x, Difficulty.GetDifficultyPercent());
            //Creates the next spawn time by adding the current time and secondsBetweenSpawns together.
            nextSpawnTime = Time.time + secondsBetweenSpawns;

            //Creates a random size between a random range.
            randomSize = Vector3.one * (Random.Range(0.1f, 0.5f) + 0.4f);
            //Find the block size on the x axis
            blockSize = transform.localScale.x;
            //Create spawn postion
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + blockSize);
            //Create random rotation
            Vector3 randomRotation = Vector3.forward * Random.Range(-10f, 10f);
            //Instantiate cube with random rotation and spawn position
            GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(randomRotation));
            //Scale blocspawner to random size upon each instatiation
            newBlock.transform.localScale = randomSize;
  
        }
    }
}
