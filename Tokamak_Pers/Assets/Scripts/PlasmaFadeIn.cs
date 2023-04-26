using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaFadeIn : MonoBehaviour
{
    public float startTime = 50.0f; // Time to start the fade in
    public float duration = 10.0f; // Duration of the fade in
    private SpriteRenderer spriteRenderer;
    private float timeElapsed = 0.0f;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f); // Set initial opacity to 0
    }

    void Update()
    {
        // Check if it's time to start the fade in
        if (Time.time >= startTime)
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