using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefrenceManager : MonoBehaviour {

	public static GameObject player;
	// Use this for initialization
	private void Awake() {
		player = GameObject.Find("AriseFPSController");
	}
	
}
