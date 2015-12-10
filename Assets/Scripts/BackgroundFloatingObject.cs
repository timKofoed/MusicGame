using UnityEngine;
using System.Collections;

public class BackgroundFloatingObject : MonoBehaviour {

    public float rotationalSpeed = 1.0f;
    public float heightVelocity = 0.5f;
    private Rigidbody myRigidbody;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (myRigidbody == null)
            myRigidbody = this.gameObject.GetComponent<Rigidbody>();

        if(myRigidbody != null)
        {
            Move();

            Turn();
        }        
    }

    private void Move()
    {
        // Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
        Vector3 movement = Vector3.up * heightVelocity * Time.deltaTime;

        // Apply this movement to the rigidbody's position.
        myRigidbody.MovePosition(myRigidbody.position + movement);
    }

    private void Turn()
    {
        // Determine the number of degrees to be turned based on the input, speed and time between frames.
        float turn = rotationalSpeed * Time.deltaTime;

        // Make this into a rotation in the y axis.
        Quaternion turnRotation = Quaternion.Euler(0f, 0f, turn);

        // Apply this rotation to the rigidbody's rotation.
        myRigidbody.MoveRotation(myRigidbody.rotation * turnRotation);
    }
}
