using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lights : MonoBehaviour
{

    public float startTime1 = 20.0f; // Time to start the first color change
    public float duration1 = 10.0f; // Duration of the first color change
    public Color startColor; // Starting color
    public Color color2; // Second color
    public float startTime2 = 40.0f; // Time to start the second color change
    public float duration2 = 10.0f; // Duration of the second color change
    public Color endColor; // Ending color
    private Light lightComponent;
    private float timeElapsed1 = -10.0f; // Time elapsed for the first color change
    private float timeElapsed2 = 0.0f; // Time elapsed for the second color change
    private bool isChanging = false;

    void OnEnable()
    {
        // Check if the current scene is the one where the Lights script should be active
        if (SceneManager.GetActiveScene().name == "Tokamak")
        {
            lightComponent = GetComponent<Light>();
            Invoke("StartChanging", startTime1);
        }
    }

    void Update()
    {
        // Check if it's time to start the color changes and the current scene is "Tokamak"
        if (isChanging && SceneManager.GetActiveScene().name == "Tokamak")
        {
            if (timeElapsed1 >= 0)
            {
                // Calculate the current progress of the first color change
                timeElapsed1 += Time.deltaTime;
                float t = Mathf.Clamp01(timeElapsed1 / duration1);

                // Lerp the color from startColor to color2 over duration1 seconds
                Color newColor = Color.Lerp(startColor, color2, t);

                // Set the light color to the new color
                lightComponent.color = newColor;
            }

            // Check if it's time to start the second color change
            if (Time.time >= startTime2)
            {
                // Calculate the current progress of the second color change
                timeElapsed2 += Time.deltaTime;
                float t = Mathf.Clamp01(timeElapsed2 / duration2);

                // Lerp the color from color2 to endColor over duration2 seconds
                Color newColor = Color.Lerp(color2, endColor, t);

                // Set the light color to the new color
                lightComponent.color = newColor;
            }
        }
    }

    void StartChanging()
    {
        isChanging = true;
    }
}