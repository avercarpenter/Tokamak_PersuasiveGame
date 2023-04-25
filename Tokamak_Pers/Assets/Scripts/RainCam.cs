using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCam : MonoBehaviour
{
   public Transform playerTransform; // Reference to the player transform
    public float yOffset; // Offset in the y direction between the camera and the player
    public float minYPosition; // The minimum y position of the camera
    public float maxYPosition; // The maximum y position of the camera
    public float transitionYPosition; // The y position at which the camera should start following horizontal movement
    public float xOffset; // Offset in the x direction between the camera and the player after transition

    private bool followHorizontal; // Flag indicating whether the camera should follow horizontal movement

    // LateUpdate is called after all other Update functions have been called
    void LateUpdate()
    {
        // Get the current position of the camera
        Vector3 newPos = transform.position;

        // Follow the player's vertical movement
        newPos.y = playerTransform.position.y + yOffset;

        // Check if the camera has reached the transition y position
        if (newPos.y >= transitionYPosition)
        {
            followHorizontal = true;
        }

        // Follow the player's horizontal movement if necessary
        if (followHorizontal)
        {
            newPos.x = playerTransform.position.x + xOffset;
        }

        // Clamp the camera's y position to the minimum and maximum values
        newPos.y = Mathf.Clamp(newPos.y, minYPosition, maxYPosition);

        // Set the new position of the camera
        transform.position = newPos;
    }
}

