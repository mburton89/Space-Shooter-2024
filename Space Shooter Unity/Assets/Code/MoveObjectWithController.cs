using UnityEngine;
using UnityEngine.InputSystem;

public class MoveObjectWithController : MonoBehaviour
{
    public InputActionAsset controls;

    public float moveSpeed = 5f; // Adjust this to change the speed of movement
    PlayerShip playerShip;
    public GameObject echoPrefab;

    private void Start()
    {
        playerShip = GetComponent<PlayerShip>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the input values for horizontal and vertical axes of the left thumbstick
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical"); 

        // Calculate the movement direction based on input
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);

        // Apply movement to the object's transform
        //transform.Translate(movement * moveSpeed * Time.deltaTime);
        playerShip.HandleJoystick(movement);

        if (Input.GetButtonDown("Jump"))
        {
            // Debug a message indicating that the button is pressed
            Debug.Log("Button " + "Jump" + " is pressed!");
            Instantiate(echoPrefab, transform.position, transform.rotation, null);
        }
    }

    private void OnPressRightTrigger()
    {
        Instantiate(echoPrefab, transform.position, transform.rotation, null);
    }

    private void OnPressLeftTrigger()
    {
        print("OnPressLeftTrigger");
    }

    private void OnPressSouthButton()
    {
        Instantiate(echoPrefab, transform.position, transform.rotation, null);
    }

    private void OnPressWesthButton()
    {
        print("OnPressWestButton");
    }
}