using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour {

    //variable declaration
    public GameObject[] fallingBlockPrefab;
    public Vector2 InstantaionTimeMinMax;
    public Vector2 screenHalfSizeWorldUnits;
    public int count;
    Vector3 randomSize;
    public float blockSize;
    float nextSpawnTime;
    public float secondsBetweenSpawns;

    //GameOver class instantce
    public GameOver gameOver;

	void Start () {
        //Calculate half width of the camera
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }
	
    //on each update
	void Update () {
        BlockSpawn();
	}

    //method that controls block spawning
    void BlockSpawn ()
    {
        //if statement controls which block is spawned; no count ones are spawned when game is over.
        //Spawns new block when time is more than the nextSpawn time and when the game is not over.
        if (Time.time > nextSpawnTime && gameOver.ReturnGameOverState() == false)
        {
            //decides the seconds between spawns value based on the difficulty percentage between two values.
            secondsBetweenSpawns = Mathf.Lerp(InstantaionTimeMinMax.y, InstantaionTimeMinMax.x, Difficulty.GetDifficultyPercent());
            //Creates the next spawn time by adding the current time and secondsBetweenSpawns together.
            nextSpawnTime = Time.time + secondsBetweenSpawns;

            //Creates a reandom size between a random range.
            randomSize = Vector3.one * (Random.Range(0.1f, 0.5f) + 0.4f);
            //Find the block
            blockSize = transform.localScale.x;
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + blockSize);
            Vector3 randomRotation = Vector3.forward * Random.Range(-10f, 10f);
            GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab[0], spawnPosition, Quaternion.Euler(randomRotation));
            newBlock.transform.localScale = randomSize;
        }

        //Spawns new block when time is more than the nextSpawn time and when the game is over.
        else if (Time.time > nextSpawnTime && gameOver.ReturnGameOverState() == true)
        {
            //decides the seconds between spawns value based on the difficulty percentage between two values.
            secondsBetweenSpawns = Mathf.Lerp(InstantaionTimeMinMax.y, InstantaionTimeMinMax.x, Difficulty.GetDifficultyPercent());
            //Creates the next spawn time by adding the current time and secondsBetweenSpawns together.
            nextSpawnTime = Time.time + secondsBetweenSpawns;

            randomSize = Vector3.one * (Random.Range(0.1f, 0.5f) + 0.4f);
            blockSize = transform.localScale.x;
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + blockSize);
            Vector3 randomRotation = Vector3.forward * Random.Range(-10f, 10f);
            GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab[1], spawnPosition, Quaternion.Euler(randomRotation));
            newBlock.transform.localScale = randomSize;
        }
    }
}
