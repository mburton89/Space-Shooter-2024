using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ship
{
    public GameManager GameManager;
    public AudioSource dashSF;
    public float moveSpeed = 10f; // Movement speed of the player
    private float tempMoveSpeed;

    public float dashDistance = 100f; // Distance to dash
    public float dashDuration = 1f; // Duration of the dash
    public float dashCooldown = 1f; // Cooldown between dashes
    public bool isInvincibleDuringDash = true; // Flag to enable invincibility during dash
    public float dashForce = 100f;

    private bool isDashing = false;
    public Animator playerAnimator;

    private bool stopMoveFeature = false;

    [SerializeField] private bl_Joystick Joystick;//Joystick reference for assign in inspector

    bool isMobile;

    public float joystickSpeedBuffer;

    void Start()
    {
        GameManager = GameManager.Instance;
        tempMoveSpeed = moveSpeed;

        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            // Check if it's running on a mobile device or computer
            if (Application.isMobilePlatform)
            {
                isMobile = true;
                Joystick.gameObject.SetActive(true); // Activate joystick for mobile
            }
            else
            {
                isMobile = false;
                Joystick.gameObject.SetActive(false); // Deactivate joystick for desktop
            }
        }
        else if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXEditor)
        {
            // For standalone builds (Windows or Mac) and Editor
            isMobile = false;
            Joystick.gameObject.SetActive(false); // Deactivate joystick for desktop
        }
        else
        {
            // Default case for mobile platforms (if not WebGL)
            isMobile = true;
            Joystick.gameObject.SetActive(true); // Activate joystick for mobile
        }
    }

    void Update()
    {
        if (isMobile)
        {
            HandleJoystick();
            HandleScreenTaps();
        }
        else
        { 
            HandleKeyboard();
            FollowMouse();
            if (Input.GetMouseButton(1))
            {
                Thrust();
                Joystick.gameObject.SetActive(false); // Deactivate joystick for desktop
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Echo();
            }
        }
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

            //playerAnimator.SetTrigger("dive");

            GameManager.dashBarValue -= .33f;

            HUD.Instance.DisplayDashAmount(GameManager.Instance.dashBarValue, 1);

            // Dash Sound
            dashSF.Play();

            // Calculate dash direction based on current facing direction or any other logic
            Vector2 dashDirection = rb.transform.forward;

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
                stopMoveFeature = true;
                // Calculate the current force based on the elapsed time
                float currentForce = Mathf.Lerp(0f, dashForce, elapsed / dashDuration);

                // Apply force to the player in the dash direction
                moveSpeed = tempMoveSpeed * dashForce;

                // Increment elapsed time
                elapsed += Time.deltaTime;

                // Wait for the next frame
                yield return null;
            }
            stopMoveFeature = false;
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

            moveSpeed = tempMoveSpeed;
            isDashing = false;
        }
        else
        {
            Debug.Log("No more stamina :(");
        }
    }

    void HandleKeyboard()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized;

        // Store the current velocity
        Vector2 currentVelocity = rigidBody2D.velocity;

        // Check if there's input for movement
        if (movement != Vector2.zero)
        {
            // Move the player
            rigidBody2D.velocity = movement * moveSpeed;

            // Rotate the player
            float angle = (Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg) - 90;
            rigidBody2D.rotation = angle;

            // Reset stopMoveFeature since the player is moving
            stopMoveFeature = false;
        }
        else if (!stopMoveFeature && currentVelocity.magnitude > 0f && Vector2.Dot(currentVelocity, rigidBody2D.velocity) <= 0f)
        {
            // If there's no input and the ship was previously moving, and it's now starting to slow down
            // Set velocity to zero immediately
            rigidBody2D.velocity = Vector2.zero;

            // Set stopMoveFeature to true to prevent further stopping until player starts moving again
            stopMoveFeature = true;
        }

        //if (Input.GetMouseButton(1))
        //{
        //    if (isDashing == false)
        //    {
        //        StartCoroutine(Dash(rigidBody2D));
        //    }
        //}
        if (Input.GetMouseButtonDown(0))
        {
            Echo();
            //Shoot();
        }


        if (GameManager.dashBarValue <= .33f && stopMoveFeature == false)
        {
            moveSpeed = tempMoveSpeed / 2f;
        }
        else if (GameManager.dashBarValue >= .33f && GameManager.dashBarValue <= .66f && stopMoveFeature == false)
        {
            moveSpeed = tempMoveSpeed / 1.5f;
        }
        else if (GameManager.dashBarValue > .66f && stopMoveFeature == false)
        {
            moveSpeed = tempMoveSpeed;
        }
    }

    void HandleJoystick()
    {
        //Step #2
        //Change Input.GetAxis (or the input that you using) to Joystick.Vertical or Joystick.Horizontal
        float v = Joystick.Vertical; //get the vertical value of joystick
        float h = Joystick.Horizontal;//get the horizontal value of joystick

        //in case you using keys instead of axis (due keys are bool and not float) you can do this:
        //bool isKeyPressed = (Joystick.Horizontal > 0) ? true : false;



        Vector2 directionToFace = new Vector2(h, v);
        transform.up = directionToFace;
        Thrust((Mathf.Abs(v) + Mathf.Abs(h)) * joystickSpeedBuffer);
    }

    void HandleScreenTaps()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                // Check if the current touch just began
                if (touch.phase == TouchPhase.Began)
                {
                    // Get the touch position
                    Vector2 touchPosition = touch.position;

                    // Check if the touch is on the right side of the screen
                    if (touchPosition.x > Screen.width / 2)
                    {
                        // The user tapped the right side of the screen
                        Echo();
                        // Call your method or trigger your event here
                    }
                }
            }
        }
    }
}
