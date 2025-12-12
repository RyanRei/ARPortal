using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 5f;
    private Transform arCamera;  // AR Camera reference
    private bool isMoving = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        arCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            Vector3 moveDirection = arCamera.forward; // Move forward in camera direction
            moveDirection.y = 0;  // Keep movement level
            transform.position += moveDirection * speed * Time.deltaTime;
        }
    }

    public void StartMoving() { isMoving = true; }   // Call when button is pressed
    public void StopMoving() { isMoving = false; }
}
