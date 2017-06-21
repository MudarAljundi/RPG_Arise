using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput: MonoBehaviour {

	private Transform playerTransform;
	private LineRenderer playerLineRenderer;

	private Vector3 pointOfContact;
	private GameObject entityBeingLookedAt;
	private Vector3 mouseToWorldPlane;

	private void Start() {
		playerTransform = RefrenceManager.player.transform;
		playerLineRenderer = RefrenceManager.player.transform.Find("LineOfSight").GetComponent<LineRenderer>();
	}
	private void Update() {

		mouseToWorldPlane = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mouseToWorldPlane = new Vector3(mouseToWorldPlane.x, playerTransform.position.y, mouseToWorldPlane.z);

		//Vector3 lookDirection = new Vector3(mouseToWorldPlane.x, playerTransform.position.y, mouseToWorldPlane.z) - playerTransform.position;
		//Ray lookRay = new Ray(playerTransform.position, lookDirection);

		RaycastHit hit;

		Physics.Linecast(playerTransform.position, mouseToWorldPlane, out hit);

		if (hit.collider != null) {

			pointOfContact = hit.point;

			if (hit.collider.gameObject == entityBeingLookedAt) {
				

			} else {

				if (entityBeingLookedAt != null) {
					entityBeingLookedAt.GetComponent<UsableEntity>().NotBeingLookedAt();
					entityBeingLookedAt = null;
				}

				if (hit.collider.GetComponent<UsableEntity>()) {

					entityBeingLookedAt = hit.collider.gameObject;
					hit.collider.GetComponent<UsableEntity>().BeingLookedAt();
				}
			}

		} else {

			pointOfContact = mouseToWorldPlane;

			if (entityBeingLookedAt != null) {
				entityBeingLookedAt.GetComponent<UsableEntity>().NotBeingLookedAt();
				entityBeingLookedAt = null;
			}
		}
		
		if (hardInput.GetKeyDown("Use") == true) {

			if (entityBeingLookedAt != null && entityBeingLookedAt.GetComponent<UsableEntity>()) {
				entityBeingLookedAt.GetComponent<UsableEntity>().UseEntity();
			}
		}

		/*
		 * The cursor is the mouse
		 * 
		Ray camInWorld = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Physics.Raycast(camInWorld, out hit);

		Debug.DrawRay(camInWorld.GetPoint(0f), camInWorld.direction, Color.green, 1f);
		if (hit.collider != null) {
			print(hit.collider.name);
		}
		*/
	}

	private void LateUpdate() {
		
		playerLineRenderer.SetPosition(0, playerTransform.position);
		playerLineRenderer.SetPosition(1, pointOfContact);
	}
}
