using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triterium : MonoBehaviour
{
    public float speed = 5f;

    private bool isMoving = false;

    void Update()
    {
        if (Time.time >= 55f && !isMoving)
        {
            isMoving = true;
        }

        if (isMoving)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           // GameManager.Instance.PlayCutSceneAndEndGame();
        }
    }
}