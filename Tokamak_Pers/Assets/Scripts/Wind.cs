using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{

    public float windForce = 50f;
    public float windDuration = 3f;

    private bool isActive = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isActive = true;
            StartCoroutine(StopWind());
        }
    }

    private IEnumerator StopWind()
    {
        yield return new WaitForSeconds(windDuration);
        isActive = false;
    }

    public bool IsActive()
    {
        return isActive;
    }
}