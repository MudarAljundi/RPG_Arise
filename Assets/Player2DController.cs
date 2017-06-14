using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DController : MonoBehaviour {

	public float maxSpeed;
	public float movementForce;

	private Rigidbody myRigidbody;

	// Use this for initialization
	private void Start () {
		myRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	private void FixedUpdate () {
		ClampVelocity();
		if (hardInput.GetKey("Forward") == true) {
			myRigidbody.AddForce(Vector3.forward * movementForce, ForceMode.Force);
		}
		if (hardInput.GetKey("Backward") == true) {
			myRigidbody.AddForce(Vector3.back * movementForce, ForceMode.Force);
		}
		if (hardInput.GetKey("Strafe_Left") == true) {
			myRigidbody.AddForce(Vector3.left * movementForce, ForceMode.Force);
		}
		if (hardInput.GetKey("Strafe_Right") == true) {
			myRigidbody.AddForce(Vector3.right * movementForce, ForceMode.Force);
		}
	}
	private void ClampVelocity() {

		Vector3 tempClamped = Vector3.ClampMagnitude(myRigidbody.velocity, maxSpeed);

		myRigidbody.velocity = new Vector3(tempClamped.x, myRigidbody.velocity.y, tempClamped.z);
	}
}
