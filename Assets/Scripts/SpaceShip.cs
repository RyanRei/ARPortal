using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class SpaceShip : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Transform arCamera;  // AR Camera reference
    void Start()
    {
        arCamera = Camera.main.transform;
        
        gameObject.transform.SetParent(Camera.main.transform);
        gameObject.transform.localPosition = new Vector3(-0.05f, -0.64f, 0.5f);  // Position relative to parent
        gameObject.transform.localRotation = Quaternion.Euler(-83.8f, 546.99f, -0.079f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Moon")){
            Debug.Log("moooooooon");
            SceneManager.LoadScene("OnMoon");
        }
    }



}
