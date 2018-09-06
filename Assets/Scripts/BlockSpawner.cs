using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour {

    public GameObject[] fallingBlockPrefab;
    public Vector2 InstantaionTimeMinMax;
    public Vector2 screenHalfSizeWorldUnits;
    public int count;
    Vector3 randomSize;
    public float blockSize;
    float nextSpawnTime;
    public float secondsBetweenSpawns;

    GameOver gameOver;

	void Start () {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        gameOver = FindObjectOfType<GameOver>();

        if (PlayerPrefs.GetInt("SoundSetting") == 1)
        {
            GetComponent<AudioSource>().enabled = false;
        }
        else
        {
            GetComponent<AudioSource>().enabled = true;
        }
    }
	
	void Update () {
        BlockSpawn();
	}

    void BlockSpawn ()
    {
        if (Time.time > nextSpawnTime && gameOver.gameOver == false)
        {
            secondsBetweenSpawns = Mathf.Lerp(InstantaionTimeMinMax.y, InstantaionTimeMinMax.x, Difficulty.GetDifficultyPercent());
            nextSpawnTime = Time.time + secondsBetweenSpawns;

            randomSize = Vector3.one * (Random.Range(0.1f, 0.5f) + 0.4f);
            blockSize = transform.localScale.x;
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + blockSize);
            Vector3 randomRotation = Vector3.forward * Random.Range(-10f, 10f);
            GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab[0], spawnPosition, Quaternion.Euler(randomRotation));
            newBlock.transform.localScale = randomSize;
        }
        else if (Time.time > nextSpawnTime && gameOver.gameOver == true)
        {
            secondsBetweenSpawns = Mathf.Lerp(InstantaionTimeMinMax.y, InstantaionTimeMinMax.x, Difficulty.GetDifficultyPercent());
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
