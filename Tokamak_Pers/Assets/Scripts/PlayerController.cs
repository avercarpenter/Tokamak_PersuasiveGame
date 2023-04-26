using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f; 
    public float freezeTime = 2f;

    private Rigidbody2D rb; 
    private GameManager gameManager;
    private Animator anim; 

    private bool isFrozen = false;
    private float freezeTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (isFrozen)
        {
            freezeTimer += Time.deltaTime;
            if (freezeTimer >= freezeTime)
            {
                isFrozen = false;
                freezeTimer = 0f;
                anim.SetBool("Frozen", false);
            }
            return;
        }

        float hozMovement = Input.GetAxisRaw("Horizontal");
        float verMovement = Input.GetAxisRaw("Vertical");

        rb.AddForce(new Vector2(hozMovement * speed, verMovement * speed));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DeathBoundary"))
        {
            Debug.Log("ded");
            gameManager.GameOver();
        }

        if (other.CompareTag("Ice"))
        {
            Debug.Log("Frozen");
            anim.SetBool("Frozen", true);
            isFrozen = true;    
        }
    }
} 