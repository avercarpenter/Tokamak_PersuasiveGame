using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f; 
    public float freezeTime = 2f;

    private Rigidbody2D rb; 
   // private GameManager gameManager;
    private Animator anim; 

    private bool isFrozen = false;
    private float freezeTimer = 0f;
    //public AudioClip fuse1;
    //public AudioClip fuse2;
    //AudioSource FuseSound1;
    //AudioSource FuseSound2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       // gameManager = GameObject.FindObjectOfType<GameManager>();
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
            SceneManager.LoadScene("LoseScene");
          //  gameManager.GameOver();
            
        }

        if (other.CompareTag("Ice"))
        {
            Debug.Log("Frozen");
            anim.SetBool("Frozen", true);
            isFrozen = true;    
        }

        if(other.CompareTag("Tri"))
        {
        // Destroy(other.GameObject);
            Debug.Log("Fuse");
            Destroy(other.gameObject); 
            anim.SetTrigger("Fusion");
            // add audio here 
            //FuseSound1.PlayOneShot(fuse1);
            //FuseSound2.PlayOneShot(fuse2);
            
            isFrozen = true;
            rb.velocity = Vector2.zero;
            transform.position = new Vector2(0f, 0f);
            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}