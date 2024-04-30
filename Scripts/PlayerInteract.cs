using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask mask;
    [SerializeField] private float distance = 3f;
    private Interactable lastInteractable; // Track the last interactable hit by the raycast

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //create a ray at the center of the camera, shooting outwards.
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;

        // Cast a ray and check if it hits any interactable object
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            Interactable interactable = hitInfo.collider.GetComponent<Interactable>();

            // If the raycast hits a new interactable object
            if (interactable != null && interactable != lastInteractable)
            {
                // Call OnInteractStart on the new interactable
                interactable.OnInteractStart();

                // If there was a previous interactable, call OnInteractEnd on it
                if (lastInteractable != null)
                {
                    lastInteractable.OnInteractEnd();
                }

                // Update the lastInteractable reference to the new one
                lastInteractable = interactable;
            }
        }
        else
        {
            // If the raycast does not hit any interactable object, and there was a previous interactable
            // call OnInteractEnd on it
            if (lastInteractable != null)
            {
                lastInteractable.OnInteractEnd();
                lastInteractable = null;
            }
        }
    }
}
