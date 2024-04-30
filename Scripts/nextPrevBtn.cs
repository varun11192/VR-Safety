using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextPrevBtn : Interactable
{
    [SerializeField] private int expChanger;
    [SerializeField] private GameObject Exp;
    [SerializeField] private Renderer buttonRenderer;
    [SerializeField] private Color interactColor = Color.green;
    private Color originalButtonColor;

    private bool isInteracting = false;
    private float interactionTimer = 0f;
    private float requiredInteractionTime = 2f;

    void Start()
    {
        originalButtonColor = buttonRenderer.material.color;
    }

    public override void OnInteractStart()
    {
        base.OnInteractStart();

        isInteracting = true;
        interactionTimer = 0f;

        // Change the color of the button when interaction starts
        buttonRenderer.material.color = interactColor;
    }

    public override void OnInteractEnd()
    {
        base.OnInteractEnd();

        // Revert the color of the button when interaction ends
        buttonRenderer.material.color = originalButtonColor;

        // Reset interaction variables
        isInteracting = false;
        interactionTimer = 0f;
    }

    private void Update()
    {
        if (isInteracting)
        {
            // Increment the interaction timer
            interactionTimer += Time.deltaTime;

            // Check if the required interaction time has elapsed
            if (interactionTimer >= requiredInteractionTime)
            {
                // Change the experience after the required interaction time
                ExperiencesManager manager = Exp.GetComponent<ExperiencesManager>();
                manager.ChangeExperience(expChanger);
            }
        }
    }
}
