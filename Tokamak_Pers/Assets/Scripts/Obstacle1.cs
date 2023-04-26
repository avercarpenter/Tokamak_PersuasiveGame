using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle1 : MonoBehaviour
{

    public float startSpeed = 5f;
    public float acceleration = 1f;

    private GameManager gameManager;
    private Coroutine moveCoroutine;

    void OnEnable()
    {
        gameManager = FindObjectOfType<GameManager>();
        
        // Check if the current scene is the third scene
        if (SceneManager.GetActiveScene().name == "Tokamak")
        {
            moveCoroutine = StartCoroutine(MoveObstacle());
            Debug.Log("Obstacles Enabled");
        }
    }

    void OnDisable()
    {
        StopCoroutine(moveCoroutine);
    }

    IEnumerator MoveObstacle()
    {
        while (gameObject.activeInHierarchy)
        {
            float currentSpeed = startSpeed + acceleration * Time.time;
            transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
            yield return null;
        }
    }


    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("LeftBoundary"))
        {
        
            Destroy(gameObject);
        }
    }
}