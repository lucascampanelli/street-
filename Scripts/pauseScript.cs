using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseScript : MonoBehaviour {

	carMovement carMovement;
	opponentMovement opponentMovement;
	startTime startTime;
	public bool pausado = false;

	void Start(){
		startTime = GetComponent<startTime>();
		carMovement = GameObject.FindWithTag("Player").GetComponent<carMovement>();
		opponentMovement = GameObject.FindWithTag("Opponent").GetComponent<opponentMovement>();
	}

	public void pausar(){
		Time.timeScale = 0;
		pausado = true;
		startTime.buzina.Pause();
		opponentMovement.sound.Pause();
		carMovement.sound.Pause();
	}

	public void despausar(){
		Time.timeScale = 1;
		pausado = false;
		startTime.buzina.UnPause();
		opponentMovement.sound.UnPause();
		carMovement.sound.UnPause();
	}

}
