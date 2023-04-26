using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinContinueButton : MonoBehaviour
{
    public GameObject image; 

    public void OnClick()
    {
       image.SetActive(false);
    }
}
