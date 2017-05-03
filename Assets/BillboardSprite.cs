using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardSprite : MonoBehaviour {

	private Transform myCameraTransform;
	private Transform myTransform;
	public bool lockXAxis = true;

	// Use this for initialization
	private void Start() {
		myTransform = transform;
		myCameraTransform = Camera.main.transform;
	}

	// Update is called once per frame
	private void LateUpdate() {

		myTransform.forward = myCameraTransform.forward;

		if (lockXAxis == true) {

			myTransform.rotation = Quaternion.Euler(0, myTransform.rotation.eulerAngles.y, myTransform.rotation.eulerAngles.z);
		}
	}
}
