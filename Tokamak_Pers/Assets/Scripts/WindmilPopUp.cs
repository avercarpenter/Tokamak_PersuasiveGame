using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindmilPopUp : MonoBehaviour
{
    public GameObject popup; 

    public GameObject continueButton;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            popup.SetActive(true);
            continueButton.SetActive(true);
        }
    }
        public void OnContinueButtonClicked()
    {
        Time.timeScale = 1f; // Resume the game
        popup.SetActive(false); // Hide the popup box
        Destroy(this.gameObject); // Destroy the popup box game object
    }

}
