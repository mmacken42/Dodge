using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fallingBlockPrefab;
    public Vector2 spawnRateMinMax;
    public Vector2 spawnSizeMinMax;
    public float spawnAngleMax;

    private float nextSpawnTime;
    private Vector2 screenHalfSizeWorldUnits;

    private void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    private void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            float spawnRateSeconds = Mathf.Lerp(spawnRateMinMax.x, spawnRateMinMax.y, Difficulty.GetDifficultyPercent());
            nextSpawnTime = Time.time + spawnRateSeconds;

            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);

            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);

            GameObject block = (GameObject)Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
            block.transform.localScale = Vector2.one * spawnSize;
        }
        
    }
}
