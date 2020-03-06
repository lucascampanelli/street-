using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearPrefs : MonoBehaviour {

	public GameObject confirm;
	public GameObject success;

	public void deletar(){
			confirm.SetActive(true);
	}

	void desativarSuccess(){
		success.SetActive(false);
	}

	public void Negar(){
		confirm.SetActive(false);
	}

	public void Confirmar(){
		PlayerPrefs.DeleteAll();
		PlayerPrefs.Save();
		success.SetActive(true);
		Invoke("desativarSuccess", 5f);
		confirm.SetActive(false);
	}

}
