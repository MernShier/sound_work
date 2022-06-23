using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = System.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject Enemy, EnemyStorage;
    [SerializeField] private float spawnTime, spawnTimeLimit, spawnTimer, spawnSpeedProgressionTime, spawnSpeedProgressionTimer, spawnSpeedProgressionValue;
    [SerializeField] private Random rnd = new Random();
    private void FixedUpdate()
    {
        spawnTimer += Time.deltaTime;
        spawnSpeedProgressionTimer += Time.deltaTime;

        if(spawnSpeedProgressionTimer >= spawnSpeedProgressionTime && spawnTime > spawnTimeLimit)
        {
            SpawnerUpgrade();
        }

        if (spawnTimer >= spawnTime)
        {
            SpawnEnemy();
        }

    }
    private void SpawnEnemy()
    {
        int rndSpawn;
        rndSpawn = rnd.Next(0, spawnPoints.Length);
        Instantiate(Enemy, new Vector3(spawnPoints[rndSpawn].transform.position.x, spawnPoints[rndSpawn].transform.position.y, spawnPoints[rndSpawn].transform.position.z), Quaternion.identity, EnemyStorage.transform);
        spawnTimer = 0;
    }
    private void SpawnerUpgrade()
    {
        spawnTime -= spawnSpeedProgressionValue;
        
        spawnSpeedProgressionTimer = 0;
    }
}
