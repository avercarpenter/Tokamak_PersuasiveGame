using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IceyFadeInandOut : MonoBehaviour
{
    public float startTime = 25.0f; // Time to start the fade in
    public float duration = 10.0f; // Duration of the fade in
    private SpriteRenderer spriteRenderer;
    private float timeElapsed = 0.0f;

    private bool isFading = false;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Tokamak")
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
            Invoke("IsFading", 25f); // Set initial opacity to 0
        }
    }

    void Update()
    {
       if (isFading)
       { // Check if it's time to start the fade in and the current scene is "Tokamak"
            if (Time.time >= startTime && SceneManager.GetActiveScene().name == "Tokamak")
            {
                // Calculate the current progress of the fade in
                timeElapsed += Time.deltaTime;
                float t = Mathf.Clamp01(timeElapsed / duration);

                // Lerp the opacity from 0 to 1 over duration seconds
                Color newColor = spriteRenderer.color;
                newColor.a = Mathf.Lerp(0f, 1f, t);
                spriteRenderer.color = newColor;
            }
        }
    }

    void IsFading()
    {
        isFading = true; 
    }
}
