using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle1 : MonoBehaviour
{

    public float startSpeed = 5f;
    public float acceleration = 1f;

    private float spawnTime;

    void OnEnable()
    {
        spawnTime = Time.time;
    }

    void Update() 
    {
        float currentSpeed = startSpeed + acceleration * (Time.time - spawnTime);
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {

        if (other.CompareTag("LeftBoundary"))
        {
            Destroy(gameObject);
        }
    }
}