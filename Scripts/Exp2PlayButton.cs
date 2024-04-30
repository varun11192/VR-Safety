using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp2PlayButton : Interactable
{
    [SerializeField] private GameObject exp;
    private Animator animator;
    private Renderer playButtonRenderer;
    [SerializeField] private Color activeColor = Color.blue;
    private Color originalColor;
    private bool canPlay = true;

    void Start()
    {
        animator = exp.GetComponent<Animator>();
        playButtonRenderer = GetComponent<Renderer>();
        originalColor = playButtonRenderer.material.color; // Cache the original color
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
        animator.SetTrigger("animationStart");

        // Wait for the animation to complete
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Wait for 10 seconds before triggering the animationComplete trigger
        yield return new WaitForSeconds(10f);

        animator.SetTrigger("animationComplete");

        canPlay = true;
    }
}
