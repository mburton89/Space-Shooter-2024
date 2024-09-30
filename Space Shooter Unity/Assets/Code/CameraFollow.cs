using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;        // Public variable to store a reference to the player GameObject
    public float smoothing = 5f;    // Smoothing factor for camera movement

    private Vector3 offset;         // The initial offset from the player

    void Start()
    {
        // Calculate the initial offset.
        offset = transform.position - player.position;
    }

    void FixedUpdate()
    {
        // Create a position for the camera based on where the player is.
        if (player == null) return;

        Vector3 targetCamPos = player.position + offset;

        // Smoothly interpolate between the camera's current position and the target position.
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
