using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMover : MonoBehaviour {

	public Vector3 openDoorPosition;
	public Vector3 closeDoorPosition;

	// open, closed, locked, key needed
	public string doorStatus;
	public string keyName;

	// Update is called once per frame
	public void DoorUse () {

		if (doorStatus == "Closed") {
			SetDoorStatus("Open");
		} else if (doorStatus == "Open") {
			doorStatus = "Closed";
		}

	}

	public void SetDoorStatus(string newStatus) {

		doorStatus = newStatus;
		if (newStatus == "Open") {

		}
	}
}
