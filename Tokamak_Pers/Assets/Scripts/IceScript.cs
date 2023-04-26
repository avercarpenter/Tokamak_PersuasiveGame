using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceScript : MonoBehaviour
{
    public float startSpeed = 5f;
    public float acceleration = 1f;
    private GameManager gameManager;

    public float freezeTime = 2f;

    void Start() {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update() {
        float currentSpeed = startSpeed + acceleration * Time.time;
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D other) 
    {
        // if (other.CompareTag("Player"))
        // {
        //     // Disable the player's movement script temporarily
        //     other.GetComponent<PlayerController>().enabled = false;

        //     // Wait for freezeTime seconds before enabling the movement script again
        //     StartCoroutine(FreezeCoroutine(other.GetComponent<PlayerController>()));
        // }
        if (other.CompareTag("LeftBoundary")) 
        {
            Destroy(gameObject);
        }
    }

    // IEnumerator FreezeCoroutine(PlayerController movement)
    // {
    //     yield return new WaitForSeconds(freezeTime);

    //     // Enable the player's movement script again
    //     movement.enabled = true;
    // }
}