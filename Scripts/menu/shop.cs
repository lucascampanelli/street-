using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour {

	playerStats playerStats;
	ScrollSnapRect scroll;

	public GameObject scrollObject;
	public Button comprarBtn;
	public int carPosition;
	public float[] precos;
	public string[] nome;
	public int tamanho;

	public Text valorText;
	public Text nomeText;

	void Start () {
		scroll = scrollObject.GetComponent<ScrollSnapRect>();
		playerStats = GetComponent<playerStats>();

		if(PlayerPrefs.GetInt("carrosComprados").ToString() == ""){
			PlayerPrefs.SetInt("carrosComprados", 0);
		}

	}

	// Update is called once per frame
	void Update () {

		if(tamanho == 0){
		tamanho = scroll._pageCount;

		precos = new float[scroll._pageCount];
		nome = new string[scroll._pageCount];
		carPosition = scroll._currentPage;
		precos[0] = 0; nome[0] = "Goal 93'"; PlayerPrefs.SetString("car"+carPosition+"Posse", "true");
		precos[1] = 3200; nome[1] = "Carro2";
		precos[2] = 16500; nome[2] = "Carro3";
		precos[3] = 50000; nome[3] = "Carro4";
		valorText.text = "R$ "+precos[(int)carPosition].ToString()+",00";
		nomeText.text = nome[(int)carPosition];
	}

		if(playerStats.getMoney() >= precos[(int)carPosition] && PlayerPrefs.GetString("car"+carPosition+"Posse") != "true"){
			comprarBtn.interactable = true;
		}
		else{
			comprarBtn.interactable = false;
		}
	}

	public void changeValue(){
		carPosition = scroll._currentPage;
		valorText.text = "R$ "+precos[(int)carPosition].ToString()+",00";
		nomeText.text = nome[(int)carPosition];
	}

	public void buyCar(){
		PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - ((int)precos[(int)carPosition]));
		PlayerPrefs.SetInt("carrosComprados", PlayerPrefs.GetInt("carrosComprados")+1);
		PlayerPrefs.SetString("garagem "+PlayerPrefs.GetInt("carrosComprados"), nome[(int)carPosition]);
		PlayerPrefs.SetString("car"+carPosition+"Posse", "true");
	}

}
