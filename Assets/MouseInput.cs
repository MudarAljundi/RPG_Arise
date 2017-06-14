using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour {
	
	// Update is called once per frame
	private void Update () {
		Ray camInWorld = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Physics.Raycast(camInWorld, out hit);

		Debug.DrawRay(camInWorld.GetPoint(0f), camInWorld.direction, Color.green, 1f);
		if (hit.collider != null) {
			print(hit.collider.name);
		}
	}
}
