using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform vrPlayer;
    public float lookDownAngle = 25.0f;
    public float moveSpeed = 3.0f;
    public float backwardSpeed = 1.5f;
    private CharacterController cc;

    private bool moveForward = false;
    private bool moveBackward = false;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {

        if (Application.platform == RuntimePlatform.Android)
        {

            // Check if Back was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                // Quit the application
                Application.Quit();
            }
        }

        /*
        // Check if the camera is looking down within the specified angle range
        bool lookingDown = vrPlayer.eulerAngles.x >= lookDownAngle && vrPlayer.eulerAngles.x < 45.0f;

        // Set the moveForward flag based on the camera orientation and key input
        moveForward = lookingDown || Input.GetKey(KeyCode.A);

        // Set the moveBackward flag based on the key input
        moveBackward = Input.GetKey(KeyCode.B);

        // Move the player based on the flags
        if (moveForward)
        {
            MovePlayer(moveSpeed);
        }
        else if (moveBackward)
        {
            MovePlayer(-backwardSpeed); // Move backward with a slower speed
        }
        else
        {
            MovePlayer(0f); // Stop the player's movement
        }*/
    }

   /* private void MovePlayer(float movementSpeed)
    {
        // Calculate the forward direction based on the camera's forward vector (without vertical component)
        Vector3 forward = Vector3.ProjectOnPlane(vrPlayer.forward, Vector3.up).normalized;

        // Calculate the movement vector based on the forward direction and movement speed
        Vector3 movement = forward * movementSpeed * Time.deltaTime;

        // Move the player using CharacterController's Move method
        cc.Move(movement);
    }*/


}
