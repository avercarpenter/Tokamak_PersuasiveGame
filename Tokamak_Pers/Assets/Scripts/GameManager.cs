using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    // The spawn interval for the single obstacle
    public float singleObstacleSpawnInterval = 3f;

    // The delay before the first single obstacle spawns
    public float singleObstacleSpawnDelay = 5f;

    private float startTime;

    void OnEnable()
    {
        if (SceneManager.GetActiveScene().name == "Tokamak")
        {
            startTime = Time.time;
            InvokeRepeating("SpawnObstacle", spawnDelay, spawnInterval);
            InvokeRepeating("SpawnSingleObstacle", singleObstacleSpawnDelay, singleObstacleSpawnInterval);
        }
    }

    void SpawnObstacle()
    {
        if (Time.time - startTime > 50f) {
            return;
        }

        if (Time.time >= singleObstacleTime)
        {
            Instantiate(singleObstacle, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
        }
        else
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];
            Instantiate(obstaclePrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
        }
    }

    void SpawnSingleObstacle()
    {
        if (Time.time - startTime > 50f) {
            return;
        }

        if (Time.time >= singleObstacleTime)
        {
            Instantiate(singleObstaclePrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
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








