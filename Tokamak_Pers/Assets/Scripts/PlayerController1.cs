using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController1 : MonoBehaviour
{
[SerializeField] private float movementSpeed = 5f;
private Rigidbody2D rb;
public string triggerTag = "SceneTrigger";
public string nextSceneName = "NextScene";

private void Awake()
{
    rb = GetComponent<Rigidbody2D>();
}

private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(triggerTag))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

private void Update()
{
    // Get input values for movement
    float moveHorizontal = Input.GetAxisRaw("Horizontal");
    float moveVertical = Input.GetAxisRaw("Vertical");

    // Calculate movement vector
    Vector2 moveDirection = new Vector2(moveHorizontal, moveVertical).normalized;

    // Move the player
    rb.velocity = moveDirection * movementSpeed;
}
}