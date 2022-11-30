using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;
    public float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");
        
        //get the user's horizontal input
        horizontalInput = Input.GetAxis("Horizontal");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // tilt the plane up/down based on up/down arrow keys
        if (verticalInput < 0)
        {
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        }
        else if(verticalInput > 0)
        {
            transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
        }

        if (horizontalInput < 0)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        } else if (horizontalInput > 0)
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }
        
    }
}
