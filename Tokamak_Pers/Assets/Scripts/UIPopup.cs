using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPopup : MonoBehaviour
{
    public GameObject uiCanvas; // reference to the UI canvas object
    public string triggerTag = "Player"; // the tag of the object that can trigger the UI canvas
    //public AudioClip ding;

    void OnTriggerEnter2D(Collider2D other)
    {
        // check if the object that entered the trigger has the correct tag
        if (other.CompareTag(triggerTag))
        {
            // pause the game
            Time.timeScale = 0f;

            // activate the UI canvas
            uiCanvas.SetActive(true);
        }
        //audioSouce.Play();
    }

    public void OnContinueButtonClicked()
    {
        // deactivate the UI canvas
        uiCanvas.SetActive(false);

        // resume the game
        Time.timeScale = 1f;
    }
}