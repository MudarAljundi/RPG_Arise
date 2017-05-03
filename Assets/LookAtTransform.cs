using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTransform : MonoBehaviour {

	private Transform target;

	public void Update () {
		transform.LookAt(target);
	}
	
}
