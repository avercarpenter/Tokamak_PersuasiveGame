using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseScreeenController : MonoBehaviour
{
    public Image loseImage;

    void Start()
    {
        StartCoroutine(ShowLoseImage());
    }

    IEnumerator ShowLoseImage()
    {
        loseImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        loseImage.gameObject.SetActive(false);
    }
}