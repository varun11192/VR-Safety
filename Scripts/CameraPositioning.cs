using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositioning : MonoBehaviour
{
    public Transform playerTransform;
    public float cameraHeightOffset = 2.0f;

    void Start()
    {
        if (playerTransform != null)
        {
            Vector3 newPosition = playerTransform.position + Vector3.up * cameraHeightOffset;
            transform.position = newPosition;
        }
    }
}

