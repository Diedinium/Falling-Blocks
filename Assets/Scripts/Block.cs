using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public Vector2 speedMinMax;
    public float speed;
    BlockSpawner blockSpawner;
    float screenWidthLocal;

    void Start()
    {
        blockSpawner = FindObjectOfType<BlockSpawner>();
        screenWidthLocal = Camera.main.orthographicSize;
        speed = Mathf.Lerp(speedMinMax.y, speedMinMax.x, Difficulty.GetDifficultyPercent());
    }

    void Update () {
        BlockMovement();
	}

    void BlockMovement ()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.Self);
        //screenWidthLocal + blockSpawner.blockSize
        if (transform.position.y <= -screenWidthLocal - blockSpawner.blockSize)
        {
            Destroy(gameObject);
            blockSpawner.count++;
            print("Destroyed");
        }
    }
}
