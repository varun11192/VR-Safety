using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    // Existing code...

    protected bool isInteracting = false;


    // Called when the interaction with the object starts
    public virtual void OnInteractStart()
    {
        isInteracting = true;
    }

    // Called when the interaction with the object ends
    public virtual void OnInteractEnd()
    {
        isInteracting = false;
    }

    public void BaseInteract()
    {

        Interact();

    }

    // Template method to be overridden by subclasses for specific interactions
    protected virtual void Interact()
    {
        // Subclasses should implement their specific interaction logic here
    }

    // Existing code...
}
