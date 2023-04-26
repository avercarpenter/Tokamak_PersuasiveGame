using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IceScript : MonoBehaviour
{

    public float startSpeed = 5f;
    public float acceleration = 1f;

    void Update() {
        float currentSpeed = startSpeed + acceleration * Time.time;
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
    }


    IEnumerator MoveObstacle()
    {
        while (gameObject.activeInHierarchy)
        {
            float currentSpeed = startSpeed + acceleration * Time.time;
            transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
            yield return null;
        }
    }


    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("LeftBoundary")) 
        {
            Destroy(gameObject);
        }
    }


}