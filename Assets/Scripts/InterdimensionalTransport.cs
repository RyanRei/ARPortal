using System;
using UnityEngine;
using UnityEngine.Rendering;

public class InterdimensionalTransport : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is createdpublic
    //public Material[] materials;
    public GameObject[] gameObjects;


    
    void Start()
    {
        /*foreach (var mat in materials)
        {
            mat.SetInt("_StencilTest", (int)CompareFunction.Equal);
        } */
        foreach (var obj in gameObjects)
        {
            obj.layer = 7;

        }


    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name != "empty")
        {
            Debug.Log("RETURNING");
            return;
        }

        if (transform.position.z > other.transform.position.z)
        {
            Debug.Log("OUTSIDE Portal");
            

            /*foreach (var mat in materials)
            {
                mat.SetInt("_StencilTest", (int)CompareFunction.Equal);
            }*/
            foreach(var obj in gameObjects)
            {
                obj.layer = 7;

            }

        }
        else
        {
            /*foreach (var mat in materials)
            {
                Debug.Log("In PORTAL");
                mat.SetInt("_StencilTest", (int)CompareFunction.NotEqual);
            }*/
            foreach (var obj in gameObjects)
            {
                obj.layer = 0;

            }
        }
    }


    private void OnDestroy()
    {
        /*foreach (var obj in gameObjects)
        {
            obj.layer = 0;

        }*/
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
