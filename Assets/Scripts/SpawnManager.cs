using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script spawns enemies at random positions
// Attach this script to an empty GameObject called Spawn Manager

public class SpawnManager : MonoBehaviour
{
    public int enemyCount; // Number of enemies in the scene
    public int waveNumber = 1; // Current wave number
    public GameObject enemyPrefab; // Reference to the enemy prefab
    public GameObject powerUpPrefab; // Reference to the powerup prefab
    private float spawnRange = 9;


    // Start is called before the first frame update
    void Start()
    {
        // Spawn 3 enemies at the start of the game
        SpawnEnemyWave(waveNumber);
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if there are no more enemies in the scene
        enemyCount = FindObjectsOfType<Enemy>().Length;

        // New wave
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        // Create a random position for the enemy to spawn
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        // Spawn 3 enemies
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
}
