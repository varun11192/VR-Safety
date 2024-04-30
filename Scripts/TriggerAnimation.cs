using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    [SerializeField] private Animator cube;
    [SerializeField] private string cubeRotate = "cubeRotate";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {

            cube.Play(cubeRotate, 0, 0.0f);

        }  
    }
    void Start()
    {
        cube = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
