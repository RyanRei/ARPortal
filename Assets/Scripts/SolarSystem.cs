using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    readonly float G = 100f;
    GameObject[] celestials;
    public float speed = 5f;
    private Transform arCamera;  // AR Camera reference
    private bool isMoving = false;
    void Start()
    {
        arCamera = Camera.main.transform;
        //celestials = GameObject.FindGameObjectsWithTag("Celestials");
    }

    // Update is called once per frame
    void Update()
    {   /*foreach (GameObject a in celestials)
        {
            a.transform.Rotate(Vector3.up * 7f * Time.deltaTime);
        }*/


        if (isMoving)
        {
            Vector3 moveDirection = -arCamera.forward; // Move forward in camera direction
            moveDirection.y = 0;  // Keep movement level
            transform.position += moveDirection * speed * Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        //Gravity();
    }
    void Gravity()
    {
        foreach(GameObject a in celestials)
        {
            foreach (GameObject b in celestials)
            {
                if(!a.Equals(b))
                {
                    float m1 = a.GetComponent<Rigidbody>().mass;
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r=Vector3.Distance(a.transform.position, b.transform.position);
                    a.GetComponent<Rigidbody>().AddForce((b.transform.position-a.transform.position).normalized*
                        (G*(m1*m2)/(r*r)));

                }
            }
        }
    }




    public void StartMoving() { isMoving = true; }   // Call when button is pressed
    public void StopMoving() { isMoving = false; }
}
