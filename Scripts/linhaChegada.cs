using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linhaChegada : MonoBehaviour {

	carMovement carMovement;
	opponentMovement opponentMovement;
	showEnding showEnding;

	public string firstPlace = "";
	public string secondPlace = "";

	void Start(){
		carMovement = GameObject.FindWithTag("Player").GetComponent<carMovement>();
		opponentMovement = GameObject.FindWithTag("Opponent").GetComponent<opponentMovement>();
		showEnding = GameObject.FindWithTag("events").GetComponent<showEnding>();
	}

	void OnTriggerEnter2D (Collider2D other){
		if(other.tag == "Player"){
			if(firstPlace == ""){
				firstPlace = "Player";
				secondPlace = "Opponent";
			}
			else{
				secondPlace = "Player";
			}
			carMovement.endingArea = true;
			showEnding.Invoke("ativar", 5f);
		}

		if(other.tag == "Opponent"){
			if(firstPlace == ""){
				secondPlace = "Player";
				firstPlace = "Opponent";
			}
			else{
				secondPlace = "Opponent";
			}
			opponentMovement.endingArea = true;
		}
	}
}
