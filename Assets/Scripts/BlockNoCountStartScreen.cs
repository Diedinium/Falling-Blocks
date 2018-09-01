using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockNoCountStartScreen : MonoBehaviour {

    public Vector2 speedMinMax;
    public float speed;
    BlockSpawnerVisual blockSpawnerVisual;
    float screenWidthLocal;

    void Start()
    {
        blockSpawnerVisual = FindObjectOfType<BlockSpawnerVisual>();
        screenWidthLocal = Camera.main.orthographicSize;
        speed = Mathf.Lerp(speedMinMax.y, speedMinMax.x, Difficulty.GetDifficultyPercent());
    }

    void Update()
    {
        BlockMovement();
    }

    void BlockMovement()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.Self);
        //screenWidthLocal + blockSpawner.blockSize
        if (transform.position.y <= -screenWidthLocal - blockSpawnerVisual.blockSize)
        {
            Destroy(gameObject);
        }
    }
}
