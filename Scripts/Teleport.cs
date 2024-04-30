using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Interactable
{
    [SerializeField] private GameObject player;
    private ExperiencesManager experiencesManager;

    private void Start()
    {
        experiencesManager = FindObjectOfType<ExperiencesManager>();
    }

    public override void OnInteractStart()
    {

        Debug.Log("teleport");
        base.OnInteractStart();

        // Get the current experience index from the ExperiencesManager
        int currentExperienceIndex = experiencesManager.GetCurrentExperienceIndex();

        // Check if the current experience index is valid
        if (currentExperienceIndex >= 0 && currentExperienceIndex < experiencesManager.customPositions.Length)
        {
            // Update the player's position and rotation based on the custom position of the current experience
            player.transform.position = experiencesManager.customPositions[currentExperienceIndex].transform.position;
            player.transform.rotation = experiencesManager.customPositions[currentExperienceIndex].transform.rotation;
        }
    }
}
