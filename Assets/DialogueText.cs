using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueText : MonoBehaviour {

	public float endTime = 15f;
	public float letterCountdown = 0.1f;
	[TextArea(3, 10)]
	public string dialogueText;

	private bool imageIsTalking = false;
	private float overrideLetterCountdown = 0f;
	private bool isWritingDialogue = false;
	private float iternalLetterTimer;
	private int currentIndex;

	private void Update () {
		if (isWritingDialogue == false) {
			return;
		}
		if (dialogueText.Length <= 0) {
			isWritingDialogue = false;
		}

		iternalLetterTimer += Time.deltaTime;
		
		if (iternalLetterTimer > letterCountdown + overrideLetterCountdown) {
			DisplayFirstLetter();
			iternalLetterTimer = iternalLetterTimer - (letterCountdown + overrideLetterCountdown); // reset our timer to 0 plus leftover from last countdown
			overrideLetterCountdown = 0f;
		}
	}
	
	private void Start() {
		//StartDialogueScene("yadadadad");
	}
	public void StartDialogueScene(string jsonDialogueKey) {
		GetComponent<Text>().text = "";
		isWritingDialogue = true;
	} 
	private void DisplayFirstLetter () {
		if (dialogueText.StartsWith("[incoming]")) {

		}
		if (dialogueText.StartsWith("[talk=")) {
			if (dialogueText.Substring(7, dialogueText.Length).StartsWith("overseer-normal]")) {
				//print ();
			}
		}
		/*
		if (dialogueText.StartsWith(",")) {
			overrideLetterCountdown = 1f;
			imageIsTalking = false;
		}
		if (dialogueText.StartsWith(";")) {
		
			overrideLetterCountdown = 1f;
			imageIsTalking = false;
		}
		if (dialogueText.StartsWith("!")) {
		
			overrideLetterCountdown = 2f;
			imageIsTalking = false;
		}
		if (dialogueText.StartsWith("?")) {
		
			overrideLetterCountdown = 2f;
			imageIsTalking = false;
		}
		if (dialogueText.StartsWith(".")) {
			overrideLetterCountdown = 1.5f;
			
			imageIsTalking = false;
		}
		if (dialogueText.StartsWith("[wait=")) {
		
			overrideLetterCountdown = ;
			imageIsTalking = false;
		}
		if (dialogueText.StartsWith("[lcd=")) {
		
			letterCountdown = 0.1f;
		}
		if (dialogueText.StartsWith("[snd=")) {
			GetComponent<AudioSource>().PlayOneShot();
		}
		*/


		GetComponent<Text>().text = GetComponent<Text>().text + dialogueText[0];
		dialogueText = dialogueText.Remove(0, 1);

		imageIsTalking = true;
		currentIndex += 1;
		if (currentIndex % 2 == 0) {
			GetComponent<AudioSource>().Play();
		}
	}
}
