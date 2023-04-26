using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCam2 : MonoBehaviour
{
    public Transform playerTransform; // reference to the player's transform
    public float smoothing = 5f; // the smoothing factor for camera movement

    private Vector3 offset; // the offset between the camera and the player
    private Bounds cameraBounds; // the bounds of the camera boundaries

    void Start()
    {
        // calculate the initial offset between the camera and the player
        offset = transform.position - playerTransform.position;

        // get the bounds of the camera boundaries
        cameraBounds = GetComponent<BoxCollider>().bounds;
    }

    void FixedUpdate()
    {
        // calculate the target position of the camera based on the player's position and the offset
        Vector3 targetPosition = playerTransform.position + offset;

        // clamp the camera position within the camera boundaries
        float cameraHalfWidth = GetComponent<Camera>().aspect * GetComponent<Camera>().orthographicSize;
        targetPosition.x = Mathf.Clamp(targetPosition.x, cameraBounds.min.x + cameraHalfWidth, cameraBounds.max.x - cameraHalfWidth);
        targetPosition.z = Mathf.Clamp(targetPosition.z, cameraBounds.min.z + GetComponent<Camera>().orthographicSize, cameraBounds.max.z - GetComponent<Camera>().orthographicSize);

        // smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.fixedDeltaTime);
    }
}