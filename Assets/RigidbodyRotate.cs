using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyRotate : MonoBehaviour {

	public Vector3 rotateDegreesPerSecond;

	private Rigidbody myRigidbody;

	private void Start() {
		myRigidbody = GetComponent<Rigidbody>();
	} 
	private void FixedUpdate () {

		myRigidbody.MoveRotation(myRigidbody.rotation * Quaternion.Euler(rotateDegreesPerSecond * Time.fixedDeltaTime));
	}
}
