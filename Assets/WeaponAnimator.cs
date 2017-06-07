using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimator : MonoBehaviour {

	public bool rightHand;


	private Rigidbody playerRigidbody;
	private Animator myAnimator;

	private void Start() {
		playerRigidbody = RefrenceManager.player.GetComponent<Rigidbody>();
		myAnimator = GetComponent<Animator>();

		myAnimator.SetBool("RightHand", rightHand);
	}
		// Update is called once per frame
	private void Update () {

		bool isMoving = (Mathf.Abs(playerRigidbody.velocity.x) > 1.5f || Mathf.Abs(playerRigidbody.velocity.z) > 1.5f);

		if (isMoving == true) {
			float movementspeed = Mathf.Clamp(playerRigidbody.velocity.sqrMagnitude * 0.01f, 0f, 1f);
			myAnimator.SetFloat("MovementSpeed", movementspeed);
		}
		myAnimator.SetBool("IsMoving", isMoving);
	}
}
