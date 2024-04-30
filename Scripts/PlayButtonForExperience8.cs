using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayButtonForExperience8 : Interactable
{
    [SerializeField] private GameObject exp;
    private Animator animator;
    [SerializeField] private string trigger;
    [SerializeField] private string resetTrigger;
    private bool canPlay = true;

    [SerializeField] private Renderer playButtonRenderer;
    [SerializeField] private Color activeColor = Color.blue;
    private Color originalColor;

    [SerializeField] private GameObject bloodGushObject; // Assign the GameObject containing the Visual Effect component
    private VisualEffect bloodGushVFX;

    private void Start()
    {
        animator = exp.GetComponent<Animator>();
        playButtonRenderer = GetComponent<Renderer>();
        originalColor = playButtonRenderer.material.color; // Cache the original color

        // Get the Visual Effect component from the bloodGushObject
        bloodGushVFX = bloodGushObject.GetComponent<VisualEffect>();
        // Disable the blood gush effect GameObject at the start
        bloodGushObject.SetActive(false);
    }

    public override void OnInteractStart()
    {
        base.OnInteractStart();

        if (canPlay)
        {
            // Change the color of the play button to activeColor
            playButtonRenderer.material.color = activeColor;

            canPlay = false;
            StartCoroutine(PlayAnimationAndWait());
        }
    }

    public override void OnInteractEnd()
    {
        base.OnInteractEnd();

        // Revert the color of the play button to its original color
        playButtonRenderer.material.color = originalColor;
    }

    private IEnumerator PlayAnimationAndWait()
    {
        animator.SetTrigger(trigger);

        // Wait for the animation to complete
        yield return new WaitForSeconds(7f);

        // Enable the blood gush effect GameObject
        bloodGushObject.SetActive(true);

        // Play the blood gush VFX
        if (bloodGushVFX != null)
        {
            bloodGushVFX.Play();
            // Stop the VFX after 17 seconds
            StartCoroutine(StopVFXAfterDelay(27f));
        }

        // Wait for an additional 20 seconds before triggering the reset animation
        yield return new WaitForSeconds(20f);

        animator.SetTrigger(resetTrigger);

        canPlay = true;
    }

    private IEnumerator StopVFXAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (bloodGushVFX != null)
        {
            bloodGushVFX.Stop();
        }
    }
}
