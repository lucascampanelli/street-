using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour {

	public int money;
	public int exp;
	public float tempoCorrido;
	public int partidasJogadas;
	public int vitorias;
	public int derrotas;

	void Update(){
		money = PlayerPrefs.GetInt("money");
		exp = PlayerPrefs.GetInt("exp");
		tempoCorrido = PlayerPrefs.GetFloat("tempoCorrido");
		partidasJogadas = PlayerPrefs.GetInt("partidasJogadas");
		vitorias = PlayerPrefs.GetInt("vitorias");
		derrotas = PlayerPrefs.GetInt("derrotas");
	}

	public int getMoney(){
		return this.money;
	}

	public int getExp(){
		return this.exp;
	}

	public float gettempoCorrido(){
		return this.tempoCorrido;
	}

	public int getpartidasJogadas(){
		return this.partidasJogadas;
	}

	public int getVitorias(){
		return this.vitorias;
	}

	public int getDerrotas(){
		return this.derrotas;
	}

	public void dinheiroInfinito(){
		PlayerPrefs.SetInt("money", 10000000);
	}

}
