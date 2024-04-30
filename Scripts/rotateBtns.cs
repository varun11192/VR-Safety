using UnityEngine;

public class rotateBtns : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 initialForwardDirection;

    void Start()
    {
        mainCamera = Camera.main;
        initialForwardDirection = transform.forward;
    }

    void Update()
    {
        // Calculate the direction from the button to the player
        Vector3 directionToPlayer = mainCamera.transform.position - transform.position;

        // Project the direction onto the XZ plane to get the horizontal direction
        directionToPlayer.y = 0;

        // Calculate the angle between the initial forward direction of the button and the direction to the player
        float angle = Vector3.SignedAngle(initialForwardDirection, directionToPlayer, Vector3.up);

        // Rotate the button to face the player
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
