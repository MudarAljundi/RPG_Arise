using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UsableEntity : MonoBehaviour {

	public string entityName;
	public string description;

	public UnityEvent useEntity;

	private GameObject greenSquareContainer;

	private void Start() {
		greenSquareContainer = transform.GetChild(0).gameObject;
	}
	public void UseEntity() {

		useEntity.Invoke();
	}
	public void BeingLookedAt () {
		greenSquareContainer.SetActive(true);
	}
	public void NotBeingLookedAt() {

		greenSquareContainer.SetActive(false);
	}
}
