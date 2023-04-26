using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] private float magnetForce = 10.0f;
    [SerializeField] private bool isPulling = true;
    private Animator anim;
    private bool isPlayerInside = false;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
      //  anim.enabled = false;
       // anim.SetBool("Magnet", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInside = true;
           // anim.enabled = true;
            anim.SetBool("Magnet", true);
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInside = false;
            anim.SetBool("Magnet", false);
        }
    }

    private void FixedUpdate()
    {
        if (isPlayerInside)
        {
            Rigidbody2D otherRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
            if (otherRigidbody)
            {
                Vector2 direction = (transform.position - otherRigidbody.transform.position).normalized;
                Vector2 force = direction * magnetForce;
                if (!isPulling)
                {
                    force *= -1f;
                }
                otherRigidbody.AddForce(force);
            }
        }
    }
}
