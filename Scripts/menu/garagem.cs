using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class garagem : MonoBehaviour {

	public Transform container;

	int numSelectors;
	public GameObject[] prefabCarros;
	GameObject selector;

	public GameObject[] carros;
	public Text carroQnt;


	// Use this for initialization
	void Start () {
		numSelectors = PlayerPrefs.GetInt("carrosComprados");
		carros = new GameObject[PlayerPrefs.GetInt("carrosComprados")];
		carroQnt.text = PlayerPrefs.GetInt("carrosComprados").ToString() + " carros na garagem.";
		Debug.Log(PlayerPrefs.GetString("garagem2"));

		for (int i = 0; i < numSelectors; i++){
		selector = prefabCarros[i];
		Instantiate(selector, container);
	}
	}

	// Update is called once per frame
	void Update () {

	}
}
