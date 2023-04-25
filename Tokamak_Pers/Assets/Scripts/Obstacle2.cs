using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle2 : MonoBehaviour
{
    public float startSpeed = 5f;
    public float acceleration = 1f;
    private GameManager gameManager;

    void Start() {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update() {
        float currentSpeed = startSpeed + acceleration * Time.time;
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D other) 
    {
             if (other.CompareTag("LeftBoundary")) {
            Destroy(gameObject);
        }
    }
}