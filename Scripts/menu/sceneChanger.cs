using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour {

	public void sãoPauloMap(){
		PlayerPrefs.SetString("proximaCena", "sãoPaulo");
		SceneManager.LoadScene("loadingScene", LoadSceneMode.Single);
	}

	public void menu(){
		if(Time.timeScale == 0){
			Time.timeScale = 1;
		}
		PlayerPrefs.SetString("proximaCena", "mainMenu");
		SceneManager.LoadScene("loadingScene", LoadSceneMode.Single);
	}

	public void voltarMenu (){
		SceneManager.LoadScene("mainMenu", LoadSceneMode.Single);
	}

	public void loja(){
		SceneManager.LoadScene("store", LoadSceneMode.Single);
	}

	public void garagem(){
		SceneManager.LoadScene("garagem", LoadSceneMode.Single);
	}

	public void quit(){
		Application.Quit();
	}

}
