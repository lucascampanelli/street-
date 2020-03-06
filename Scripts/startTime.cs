using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startTime : MonoBehaviour {

	AudioSource music;

	public GameObject playerMusica;

	public AudioSource buzina;
	public float tempo;
	public bool hornPlayed = false;
	public GameObject um;
	public GameObject dois;
	public GameObject tres;
	public GameObject vai;

	public int time;
	carMovement carMovement;

	// Use this for initialization
	void Start () {
		music = GameObject.Find("music").GetComponent<AudioSource>();
		if(music != null) {
			music.Stop();
		}
		else{
			Instantiate(playerMusica);
			playerMusica.GetComponent<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
		}
		buzina = GetComponent<AudioSource>();
		buzina.volume = PlayerPrefs.GetFloat("volumeEfeito");
		carMovement = GameObject.FindWithTag("Player").GetComponent<carMovement>();
	}

	void FixedUpdate () {
		tempo += Time.deltaTime;

		if(tempo > 3 && !hornPlayed){
			buzina.Play();
			hornPlayed = true;
		}

		if(tempo > 3 && tempo < 4){
			tres.SetActive(true);
		}
		if(tempo > 4 && tempo < 5){
			tres.SetActive(false);
			dois.SetActive(true);
		}
		if(tempo > 5 && tempo < 6){
			dois.SetActive(false);
			um.SetActive(true);
		}
		if(tempo > 6 && tempo < 7){
			um.SetActive(false);
			vai.SetActive(true);
		}
		if(tempo > 8 && tempo < 9){
			vai.SetActive(false);
		}

		if(tempo > 6.2 && carMovement.endingArea == false){
			time++;
		}
	}

	public float getTempo(){
		return tempo;
	}
}
