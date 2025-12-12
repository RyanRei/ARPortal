using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class PortalManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is createdpublic
    //public Material[] materials;
    public GameObject[] gameObjects;

    private bool inPortal = false;
    private Vector3 camPostionInPortalSpace;
    public GameObject spaceShip;
    public GameObject solarSystem;
    void Start()
    {
        //gameObjects=GameObject.FindGameObjectsWithTag("Celestials");

        foreach (var obj in gameObjects)
        {
            obj.layer = 7;

        }
        
        
    }



    public void OnTriggerEnter(Collider other)
    {
        if (other.name != "Main Camera")
        {
            Debug.Log("RETURNING");
            return;
        }
        if (!inPortal) 
        {
            foreach (var obj in gameObjects)
            {
                obj.layer = 0;
                inPortal=true;

            }
            UpdateTransforms();
           

        }
        else
        {
            foreach (var obj in gameObjects)
            {
                obj.layer = 7;
                inPortal = false;

            }
            removeTransforms();
            

        }
    }

    void UpdateTransforms()
    {
        spaceShip.transform.SetParent(Camera.main.transform);
        spaceShip.transform.localPosition = new Vector3(-0.05f, -0.64f, 0.5f);  // Position relative to parent
        spaceShip.transform.localRotation = Quaternion.Euler(-83.8f, 546.99f, -0.079f);
    }


    void removeTransforms()
    {
        spaceShip.transform.SetParent(solarSystem.transform);
        spaceShip.transform.localPosition = new Vector3(0.51f, 0.25f, 1.7f);  // Position relative to parent
        spaceShip.transform.localRotation = Quaternion.Euler(-90f, 90f, 0f);
    }
    private void OnDestroy()
    {
        /*foreach (var obj in gameObjects)
        {
            obj.layer = 0;

        }*/
    }
    // Update is called once per
    // 


    void Awake()
    {
      
    }

    void Update()
    {

        /* GameObject MainCamera = GameObject.Find("cam");
         Vector3 worldPos = MainCamera.transform.position + MainCamera.transform.forward * Camera.main.nearClipPlane;
         camPostionInPortalSpace = transform.InverseTransformPoint(worldPos);
         Debug.Log(camPostionInPortalSpace.y >= 0 ? true : false);*/
    }
}
