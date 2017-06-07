using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DController : MonoBehaviour {

	public float movementForce;

	private Rigidbody myRigidbody;

	// Use this for initialization
	private void Start () {
		myRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	private void FixedUpdate () {
		if (hardInput.GetKey("Forward") == true) {
			myRigidbody.AddForce(Vector3.forward * movementForce, ForceMode.Force);
		}
	}
}
+