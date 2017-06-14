using UnityEngine;
using System.Collections;

public class LockCameraToNode : MonoBehaviour {

	public float newCameraOrthoSize;

    private Transform rememberTransform;
    private float awakeMainCameraOrthographicSize;
    private void Start() {
        awakeMainCameraOrthographicSize = Camera.main.orthographicSize;
    }

	public void ChangeSizeOnly() {
		rememberTransform = Camera.main.GetComponent<TopDownCameraTarget>().target;

		Camera.main.GetComponent<Camera>().orthographicSize = newCameraOrthoSize;
	}
	public void LockOn () {
		rememberTransform = Camera.main.GetComponent<TopDownCameraTarget> ().target;

		Camera.main.GetComponent<TopDownCameraTarget> ().target = transform;
		Camera.main.GetComponent<Camera> ().orthographicSize = newCameraOrthoSize;
	}
	public void LockBackToRemember () {

		Camera.main.GetComponent<TopDownCameraTarget> ().target = rememberTransform;
		Camera.main.GetComponent<Camera> ().orthographicSize = awakeMainCameraOrthographicSize;
	}
}
