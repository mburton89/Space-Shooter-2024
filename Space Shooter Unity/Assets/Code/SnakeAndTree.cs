using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAndTree : MonoBehaviour
{
    public Transform player; // Drag the player GameObject here in the Inspector
    public Transform tree;
    public float stretchSpeed = 2f; // Adjust the speed of stretching
    public float rotateSpeed = 5f; // Adjust the speed of rotation
    public float rotationOffset = -90f; // Offset angle for rotation
    public float rotationDistance = 1f; // Distance from end to rotate around
    public float distanceToAttack = 5f;

    private bool isStretching = false;
    private Vector3 originalScale;
    private Vector3 targetScale;
    private Quaternion targetRotation;

    private void Start()
    {
        originalScale = transform.localScale;
        targetScale = originalScale;
    }

    private void Update()
    {


        if (Vector3.Distance(player.position, tree.position) < distanceToAttack)
        {
            SetTargetScale();
            // Smoothly interpolate towards the target scale
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * stretchSpeed);

            // Rotate towards the player's direction
            Vector3 directionToPlayer = player.position - transform.position;
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
            targetRotation = Quaternion.AngleAxis(angle + rotationOffset, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);

            // Rotate around the end of the object
            Vector3 endPosition = transform.position + transform.right * rotationDistance;
            transform.RotateAround(endPosition, Vector3.forward, rotateSpeed * Time.deltaTime);

            // Scale the trigger collider back to its original size
            //triggerCollider.transform.localScale = originalColliderSize;
        }
        else
        {
            ResetStretch();
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, Time.deltaTime * stretchSpeed);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isStretching = true;
            SetTargetScale();
            Debug.Log("Enter");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isStretching = false;
            ResetStretch();
            Debug.Log("Leave");
        }
    }

    private void SetTargetScale()
    {
        Vector3 playerPosition = player.position;
        float distance = Vector3.Distance(transform.position, playerPosition);

        // Set the target scale based on the distance to the player
        targetScale.y = distance;
    }

    private void ResetStretch()
    {
        // Reset to original scale
        targetScale = originalScale;
    }

}

