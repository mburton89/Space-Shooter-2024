using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ship
{
    public GameManager GameManager;
    public float moveSpeed = 10f; // Movement speed of the player
    private float tempMoveSpeed;

    public float dashDistance = 100f; // Distance to dash
    public float dashDuration = 1f; // Duration of the dash
    public float dashCooldown = 1f; // Cooldown between dashes
    public bool isInvincibleDuringDash = true; // Flag to enable invincibility during dash
    public float dashForce = 100f;

    private bool isDashing = false;

    void Start()
    {
        tempMoveSpeed = moveSpeed;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;

        // Move the player
        rigidBody2D.velocity = movement * moveSpeed;
        

        if (movement != Vector2.zero)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            rigidBody2D.rotation = angle;
        }

        if (Input.GetMouseButton(1))
        {
            if (isDashing == false)
            {
                StartCoroutine(Dash(rigidBody2D));
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Echo();
            //Shoot();
        }

        if (GameManager.dashBarValue <= .33f)
        {
            moveSpeed = tempMoveSpeed / 2f;
        }
        else if (GameManager.dashBarValue >= .33f && GameManager.dashBarValue <= .66f)
        {
            moveSpeed = tempMoveSpeed / 1.5f;
        }
        else if (GameManager.dashBarValue > .66f)
        {
            moveSpeed = tempMoveSpeed;
        }



        //FollowMouse();
    }

    void FollowMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        Vector2 directionToFace = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = directionToFace;
    }

    public void HandleJoystick(Vector3 direction)
    {
        if (direction.magnitude > 0.1f)
        { 
            transform.up = direction;
            Thrust(direction.magnitude);
        }
    }

    IEnumerator Dash(Rigidbody2D rb)
    {
        if(GameManager.dashBarValue >= .33f)
        {
            isDashing = true;

            GameManager.dashBarValue -= .33f;

            // Calculate dash direction based on current facing direction or any other logic
            Vector2 dashDirection = rb.transform.right;

            // Disable collisions or apply other invincibility logic
            if (isInvincibleDuringDash)
            {
                // Example: Set collider to trigger during dash
                GetComponent<Collider2D>().isTrigger = true;
            }

            // Move the player by the dash distance in the dash direction
            float elapsed = 0f;
            while (elapsed < dashDuration)
            {
                // Calculate the current force based on the elapsed time
                float currentForce = Mathf.Lerp(0f, dashForce, elapsed / dashDuration);

                // Apply force to the player in the dash direction
                rb.AddForce(dashDirection * currentForce);

                // Increment elapsed time
                elapsed += Time.deltaTime;

                // Wait for the next frame
                yield return null;
            }

            Debug.Log("Dashing");

            // Wait for the dash duration
            yield return new WaitForSeconds(dashDuration);

            // Reset velocity
            rb.velocity = Vector2.zero;

            // Enable collisions or revert invincibility logic
            if (isInvincibleDuringDash)
            {
                // Example: Set collider back to solid after dash
                GetComponent<Collider2D>().isTrigger = false;
            }

            // Start cooldown
            yield return new WaitForSeconds(dashCooldown);

            isDashing = false;
        }
        else
        {
            Debug.Log("No more stamina :(");
        }
    }
}
