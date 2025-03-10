using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Array To Hold All Spawn Points
    public Transform[] spawnPoints;
    // The Enemy To Spawn
    public GameObject enemyPrefab;
    // Time Between The Spawns Of The Enemies
    public float startSpawnInterval = 10f;
    public float spawnIntervalDecrease = 0.05f;
    public float minSpawnInterval = 1f;

    private float currentSpawnInterval;

    private float nextSpawnTime;

    void Start()
    {
        currentSpawnInterval = startSpawnInterval;
        nextSpawnTime = Time.time + currentSpawnInterval;  
    }

    void Update()
    {
        if (currentSpawnInterval > minSpawnInterval)
        {
            currentSpawnInterval -= spawnIntervalDecrease * Time.deltaTime;
            currentSpawnInterval = Mathf.Max(currentSpawnInterval, minSpawnInterval);
        }

        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            // Updates The Next Spawn Time
            nextSpawnTime = Time.time + currentSpawnInterval; 
        }
    }

    void SpawnEnemy()
    {
        // Pick Between 1 Or 2 Enemies
        int numOfEnemies = Random.Range(1, 3);

        for (int i = 0; i < numOfEnemies; i++)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
        }
    }
}
