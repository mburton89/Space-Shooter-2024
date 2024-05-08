using UnityEngine;

public class BugMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // Adjust speed as needed

    private Vector2 moveDirection;

    void Start()
    {
        // Start by moving in a random direction
        ChangeDirection();
    }

    void Update()
    {
        // Move the moth in its current direction
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Check if it's time to change direction
        if (Random.Range(0f, 1f) < 0.01f) // Adjust frequency of direction change
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        // Randomly choose a new direction
        float randomAngle = Random.Range(0f, 360f);
        moveDirection = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));
    }
}