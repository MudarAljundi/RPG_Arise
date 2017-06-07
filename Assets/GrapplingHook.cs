using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour {

	public float grappleHookSpeed;
	public float hookPower;

	private bool shootingHook = false;
	private bool hookFoundEnd = false;

	private LineRenderer myLineRenderer;
	private Transform fpsCameraTransform;
	private Quaternion hookRotation;
	private Vector3 hookDestination;
	private Vector3 hookEndPoint;

	// Use this for initialization
	private void Start () {
		myLineRenderer = GetComponent<LineRenderer>();
		fpsCameraTransform = RefrenceManager.player.transform.Find("FPSCamera");
	}

	// Update is called once per frame
	private void Update () {
		if (hardInput.GetKeyDown("Grapple") == true) {
			//Physics.Raycast(transform.position, transform.forward, )
			hookEndPoint = transform.position;
			hookDestination = fpsCameraTransform.forward * 50;
			hookRotation = transform.rotation;
			
		}
		if (hardInput.GetKey("Grapple") == true) {
			shootingHook = true;
		}

		if (shootingHook == true) {
			if (hookFoundEnd == false) {
				hookEndPoint = Vector3.MoveTowards(hookEndPoint, hookDestination, Time.deltaTime * grappleHookSpeed);
				RaycastHit hit;

				Physics.Raycast(transform.position, transform.forward, out hit, Vector3.Distance(transform.position, hookEndPoint));
				if (hit.collider != null) {
					hookEndPoint = hit.point;
				}
			}
			if (hookFoundEnd == true) {

				Debug.DrawLine(transform.position, hookEndPoint, Color.green);
				RefrenceManager.player.GetComponent<Rigidbody>().AddForce((hookEndPoint - transform.position) * hookPower, ForceMode.Force);
			}
			if (hookEndPoint == hookDestination) {
				hookFoundEnd = true;
			}

			myLineRenderer.SetPosition(1, transform.InverseTransformPoint(hookEndPoint)); // visual, line end

		}
	}
	private void LateUpdate() {
		myLineRenderer.SetPosition(0, transform.InverseTransformPoint(fpsCameraTransform.position + (fpsCameraTransform.right * -0.3f))); // visual, line start
		// ignore parent (player) roation 
		transform.rotation = hookRotation;
	}
}
