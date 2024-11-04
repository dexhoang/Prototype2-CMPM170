using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTest : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float force = 50f;  // Serialized field for easy tuning in the editor
    //[SerializeField] private float rotationSpeed = 5f; // Speed of rotation

    public int intelligence;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = false; // Ensure Rigidbody is not kinematic
        }

        StartCoroutine(GravityChanged());
    }

    void Update()
    {
        /*Vector3 newGravity = Vector3.zero;

        // Change gravity based on input
        if (Input.GetKey(KeyCode.U))
        {
            newGravity = new Vector3(0, 9.8f, 0); // Gravity upwards
        }
        else if (Input.GetKey(KeyCode.J))
        {
            newGravity = new Vector3(0, -9.8f, 0); // Gravity downwards
        }
        else if (Input.GetKey(KeyCode.H))
        {
            newGravity = new Vector3(-9.8f, 0, 0); // Gravity to the left
        }
        else if (Input.GetKey(KeyCode.K))
        {
            newGravity = new Vector3(9.8f, 0, 0); // Gravity to the right
        }
        else if (Input.GetKey(KeyCode.M))
        {
            newGravity = new Vector3(0, 0, 9.8f); // Gravity forwards
        }
        else if (Input.GetKey(KeyCode.N))
        {
            newGravity = new Vector3(0, 0, -9.8f); // Gravity backwards
        }

        // Apply the new gravity if it has changed
        if (newGravity != Vector3.zero)
        {
            Physics.gravity = newGravity * force;
            rb.isKinematic = false; // Ensure Rigidbody is not kinematic
        }*/
    }

    IEnumerator GravityChanged() 
    {
        while (true)  // Loop to keep changing gravity
        {
            Vector3 newGravity = Vector3.zero;
            intelligence = Random.Range(1, 5);  // 1 to 4 inclusive
            
            Debug.Log("Number: " + intelligence);

            switch (intelligence)
            {
                case 4:
                    newGravity = new Vector3(0, 9.8f, 0); // Gravity upwards
                    break;

                case 3:
                    newGravity = new Vector3(0, -9.8f, 0); // Gravity downwards
                    break;
                
                case 2:
                    newGravity = new Vector3(-9.8f, 0, 0); // Gravity to the left
                    break;
        
                case 1:
                    newGravity = new Vector3(9.8f, 0, 0); // Gravity to the right
                    break;
                
                default:
                    Debug.Log("No gravity used");
                    break;
            }

            // Apply the new gravity if it has changed
            if (newGravity != Vector3.zero)
            {
                Physics.gravity = newGravity * force;
                rb.isKinematic = false; // Ensur Rigidbody is not kinematic
            }

            yield return new WaitForSeconds(8.0f);  // Wait 8 seconds before changing again
        }
    }
}
