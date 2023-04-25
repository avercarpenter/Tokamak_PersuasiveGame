using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    public GameObject windPopupBox;
    public GameObject solarPopupBox;

    public void ContinueGame()
    {
        
        windPopupBox.SetActive(false);
        solarPopupBox.SetActive(false);
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

}
