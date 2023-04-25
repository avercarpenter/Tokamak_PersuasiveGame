using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> obstaclePrefabs;
     public Transform[] spawnPoints;

    public float spawnInterval = 2f;
    public float spawnDelay = 2f;

    private bool isGameOver = false;

    // The time at which to switch to a single obstacle prefab
    public float singleObstacleTime = 30f;

    // The obstacle prefab to spawn after the switch time
    public GameObject singleObstaclePrefab;

    // The obstacle prefab to be used for single obstacle spawning
    public GameObject singleObstacle;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", spawnDelay, spawnInterval);
    }

    void SpawnObstacle()
    {
        // Check if the current game time has passed the switch time
        if (Time.time >= singleObstacleTime)
        {
            // Spawn the single obstacle prefab
            Instantiate(singleObstacle, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
        }
        else
        {
            // Spawn a random obstacle prefab from the list
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];
            Instantiate(obstaclePrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
        }
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            Debug.Log("Game Over!");
            // Perform any other game over logic here (e.g. show a game over screen, stop spawning obstacles, etc.)
        }
    }
}
