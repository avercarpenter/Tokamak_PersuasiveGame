using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Raindrop3 : MonoBehaviour
{
    public float speed = 5f; // the speed at which the player moves
    public float pushForce = 10f; // the force of the push when the player collides with a collider

    private Rigidbody2D rb;
    
      private bool isInsideTrigger = false; // the Rigidbody2D component of the player

    public string triggerTag = "SceneTrigger";
    public string nextSceneName = "Hydro";

    void Start()
    {
        // get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // get the horizontal input (left and right arrow keys or A/D keys)
        float horizontalInput = Input.GetAxis("Horizontal");

        // calculate the player's velocity based on the input and speed
        Vector2 velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        // set the player's velocity
        rb.velocity = velocity;
        
         // check if the player is currently inside the trigger
        if (isInsideTrigger)
        {
            // calculate the direction of the push
            Vector2 pushDirection = new Vector2(1f, 0f);

            // calculate the magnitude of the push
            float pushMagnitude = pushForce * rb.mass;

            // apply the push to the player's Rigidbody2D component
            rb.AddForce(pushDirection * pushMagnitude, ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wind"))
        {// set the flag to true when the player enters the trigger
        isInsideTrigger = true;
        }
        if (other.CompareTag(triggerTag))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Wind"))
        { // set the flag to false when the player exits the trigger
        isInsideTrigger = false;
        }

    }

    }
