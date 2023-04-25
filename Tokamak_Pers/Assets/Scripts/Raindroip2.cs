using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raindroip2 : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = 9f;
    public float windForce = 5f;
    public GameObject windZone;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Move player horizontally
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        // Apply downward force
        rb.AddForce(new Vector2(0f, -gravity));

        // Apply wind force if inside trigger
        if (isInsideWindZone)
        {
           rb.AddForce(windZone.GetComponent<WindArea>().direction * windZone.GetComponent<WindArea>().strength);
        }
    }

    private bool isInsideWindZone = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WindZone"))
        {
           isInsideWindZone = true; 
           windZone = collision.gameObject; 
            Debug.Log("Windy");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("WindZone"))
        {
            isInsideWindZone = false;
        }
    }
}
