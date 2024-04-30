using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    public Transform mainCam;
    public GameObject sphere;
    private Transform target;
    public Canvas canvas;
    private Transform worldSpaceCanvas;
    public Vector3 offset;


    private void Start()
    {
        target = sphere.transform;
        worldSpaceCanvas = canvas.transform;
        mainCam = Camera.main.transform;
        transform.SetParent(worldSpaceCanvas);

    }
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - mainCam.transform.position); // look at camera

        transform.position = target.position + offset;

    }
}