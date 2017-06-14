using UnityEngine;
using System.Collections;

public class TopDownCameraTarget : MonoBehaviour {
	public Transform target = null;
	public Vector3 offset;
	public float smoothTime = 0.2f;

	private Transform thisTransform;
	private Vector3 actualGoTo;
	private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	private void Start () {
		thisTransform = GetComponent<Transform> ();
	}

	private void LateUpdate () {
		if (target) {
			GoToTarget ();
		}
	}

	private void GoToTarget () {

		actualGoTo = new Vector3(target.position.x, 0, target.position.z) + offset; // a little head room for z-space

		//if (Vector2.Distance (thisTransform.position, target.position) > 0.2f) {

		thisTransform.position = Vector3.SmoothDamp(transform.position, actualGoTo, ref velocity, smoothTime);
		//thisTransform.position = Vector3.Lerp (thisTransform.position, actualGoTo, smoothTime);
		
	}
}
