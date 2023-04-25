using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        float randomSpeedVariation = Random.Range(-0.2f, 0.2f);
        moveSpeed += randomSpeedVariation;
    }
    void FixedUpdate()
    {
        float horizontalMovement = -1f * moveSpeed * Time.deltaTime;
        Vector2 movement = new Vector2(horizontalMovement, 0f);
        rb.MovePosition(rb.position + movement);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
