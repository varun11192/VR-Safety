using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonForAll : Interactable
{
    [SerializeField] public GameObject exp;
    private Animator animator;
    [SerializeField] public string trigger;
    [SerializeField] public string resetTrigger;
    private bool canPlay = true;

    // Add the following line
    [SerializeField] private Renderer playButtonRenderer;
    [SerializeField] private Color activeColor = Color.blue;
    private Color originalColor;

    void Start()
    {
        animator = exp.GetComponent<Animator>();
        // Get the Renderer component from the "playBtn" game object
        playButtonRenderer = GetComponent<Renderer>();
        originalColor = playButtonRenderer.material.color; // Cache the original color
    }

    /*public override void OnInteractStart()
    {
        base.OnInteractStart();

        if (canPlay)
        {
            // Change the color of the play button to activeColor
            playButtonRenderer.material.color = activeColor;

            canPlay = false;
            StartCoroutine(PlayAnimationAndWait(trigger));
        }
    }*/

    public override void OnInteractEnd()
    {
        base.OnInteractEnd();

        // Revert the color of the play button to its original color
        playButtonRenderer.material.color = originalColor;
    }

    public IEnumerator PlayAnimationAndWait(string trigger, Animator anim)
    {

        Debug.Log("message");
        anim.SetTrigger(trigger);

        // Wait for the animation to complete
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Wait for an additional 20 seconds before triggering the reset animation
        yield return new WaitForSeconds(5f);

        anim.SetTrigger(resetTrigger);

        PlayAnimationAndWait(trigger, anim);

        canPlay = true;
    }

}
