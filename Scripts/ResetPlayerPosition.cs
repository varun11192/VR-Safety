using UnityEngine;

public class ResetPlayerPosition : Interactable
{
    public GameObject defaultPosition;
    public GameObject Player; 
    public override void OnInteractStart()
    {
        
        if (defaultPosition != null)
        {
            // Reset the player's position and rotation to the defaultPosition
            Player.transform.position = defaultPosition.transform.position;
            Player.transform.rotation = defaultPosition.transform.rotation;
        }
    }
}
