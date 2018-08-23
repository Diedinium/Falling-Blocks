using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public float speed = 6.5f;
    BlockSpawner blockSpawner;
    float screenWidthLocal;

    void Start()
    {
        blockSpawner = FindObjectOfType<BlockSpawner>();
        screenWidthLocal = Camera.main.orthographicSize;
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
