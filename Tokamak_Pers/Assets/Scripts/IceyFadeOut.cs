using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IceyFadeOut : MonoBehaviour
{
    public float startTime = 45.0f; // Time to start the fade out
    public float duration = 10.0f; // Duration of the fade out
    private SpriteRenderer spriteRenderer;
    private float timeElapsed = 0.0f;

    private bool isFading = false;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Tokamak")
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            Invoke("IsFading", startTime); // Set initial opacity to 1
        }
    }

    void Update()
    {
        if (isFading)
        { // Check if it's time to start the fade out and the current scene is "Tokamak"
            if (Time.time >= startTime && SceneManager.GetActiveScene().name == "Tokamak")
            {
                // Calculate the current progress of the fade out
                timeElapsed += Time.deltaTime;
                float t = Mathf.Clamp01(timeElapsed / duration);

                // Lerp the opacity from 1 to 0 over duration seconds
                Color newColor = spriteRenderer.color;
                newColor.a = Mathf.Lerp(1f, 0f, t);
                spriteRenderer.color = newColor;

                // Destroy the object once the fade out is complete
                if (t >= 1.0f)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    void IsFading()
    {
        isFading = true;
    }
}