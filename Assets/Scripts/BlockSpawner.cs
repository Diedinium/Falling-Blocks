using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour {

    public GameObject fallingBlockPrefab;
    float InstantaionTime = 0.5f;
    public Vector2 screenHalfSizeWorldUnits;
    public int count;
    Vector3 randomSize;
    public float blockSize;

	void Start () {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
	}
	
	void Update () {
        BlockSpawn();
	}

    void BlockSpawn ()
    {
        InstantaionTime -= Time.deltaTime;
        if (InstantaionTime <= 0)
        {
            randomSize = Vector3.one * (Random.Range(0.1f, 0.5f) + 0.4f);
            blockSize = transform.localScale.x;
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + blockSize);
            Vector3 randomRotation = Vector3.forward * Random.Range(-10f, 10f);
            GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(randomRotation));
            newBlock.transform.localScale = randomSize;
            InstantaionTime = Random.Range(0.1f, 0.24f);
        }
    }
}
