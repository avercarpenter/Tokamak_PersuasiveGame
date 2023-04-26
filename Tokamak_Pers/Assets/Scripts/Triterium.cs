using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Triterium : MonoBehaviour
{
    public float speed = 5f;

    private bool isMoving = false;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Tokamak")
        {
            Invoke("StartMoving", 55f);
        }
    }

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    void StartMoving()
    {
        isMoving = true;
    }
}