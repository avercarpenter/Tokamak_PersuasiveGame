using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{public Transform playerTransform; // reference to the player's transform
    public float smoothing = 5f; // the smoothing factor for camera movement

    private Vector3 offset; // the offset between the camera and the player

    void Start()
    {
        // calculate the initial offset between the camera and the player
        offset = transform.position - playerTransform.position;
    }

    void FixedUpdate()
    {
        // calculate the target position of the camera based on the player's position and the offset
        Vector3 targetPosition = playerTransform.position + offset;

        // smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.fixedDeltaTime);
    }
}
   
