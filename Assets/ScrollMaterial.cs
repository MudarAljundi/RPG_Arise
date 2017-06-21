using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMaterial : MonoBehaviour {

	public Vector2 scrollFactor;

	private Vector2 scroll;
	private Material myMaterial;

	// Use this for initialization
	private void Start () {
		myMaterial = GetComponent<Renderer>().material;
		
	}

	// Update is called once per frame
	private void LateUpdate () {
		scroll += scrollFactor * Time.deltaTime;

		if (Mathf.Abs(scroll.x) > 10000) {
			scroll = new Vector2(scroll.x - 10000, scroll.y);
		}
		if (Mathf.Abs(scroll.y) > 10000) {
			scroll = new Vector2(scroll.x, scroll.y - 10000);
		}

		myMaterial.mainTextureOffset = new Vector2 (scroll.x, scroll.y);
	}
}
