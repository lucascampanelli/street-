using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showEnding : MonoBehaviour {

	carMovement carMovement;
	linhaChegada linhaChegada;
	public GameObject painel;
	public Animator animator;
	public Text resultado;

	public int dinheiroRecebido;
	public int expRecebida;

	public Text moneyShow;
	public Text expShow;

	startTime startTime;



	// Use this for initialization
	void Start () {
		carMovement = GameObject.FindWithTag("Player").GetComponent<carMovement>();
		linhaChegada = GameObject.Find("collider").GetComponent<linhaChegada>();
		animator = painel.GetComponent<Animator>();
		startTime = GameObject.Find("EventSystem").GetComponent<startTime>();
	}

	public void ativar(){

		if(linhaChegada.firstPlace == "Player"){
			dinheiroRecebido = 1020 - ((startTime.time / 6) + (carMovement.delayTime * 2));
			expRecebida = 680 - ((startTime.time / 8) + (carMovement.delayTime * 2));
			PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + dinheiroRecebido);
			PlayerPrefs.SetInt("exp", PlayerPrefs.GetInt("exp") + expRecebida);
		}
		else{

			dinheiroRecebido = 880 - ((startTime.time / 8) + (carMovement.delayTime * 2));

			if(dinheiroRecebido <= 0) {
					dinheiroRecebido = Random.Range(10, 40);
			}

			expRecebida = 680 - ((startTime.time / 6) + (carMovement.delayTime * 2));
			if (expRecebida <= 0) {
					expRecebida = Random.Range(10, 100);
			}


			PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + dinheiroRecebido);
			PlayerPrefs.SetInt("exp", PlayerPrefs.GetInt("exp") + expRecebida);
		}

		painel.SetActive(true);
		animator.SetTrigger("show");

		if(linhaChegada.firstPlace == "Player"){
			resultado.text = "Vitória!";
		}
		else{
			resultado.text = "Derrota.";
		}

		moneyShow.text = dinheiroRecebido.ToString();
		expShow.text = expRecebida.ToString();

	}

}
