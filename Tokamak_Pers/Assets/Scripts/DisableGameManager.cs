using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGameManager : MonoBehaviour
{
  private void Awake()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.gameObject.SetActive(false);
        }
    }
}
