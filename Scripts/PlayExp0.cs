using UnityEngine;

public class PlayExp0 : Interactable
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Renderer playButtonRenderer;
    [SerializeField] private Color activeColor = Color.green;
    private Color originalColor;

    void Start()
    {
        // Get the Renderer component from the "playBtn" game object
        playButtonRenderer = GetComponent<Renderer>();
        originalColor = playButtonRenderer.material.color; // Cache the original color
    }
    public override void OnInteractStart()
    {

        playButtonRenderer.material.color = activeColor;

        // Check if the AudioSource component is available and not already playing
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public override void OnInteractEnd()
    {
        base.OnInteractEnd();

        // Revert the color of the play button to its original color
        playButtonRenderer.material.color = originalColor;
    }
}
