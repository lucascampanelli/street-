using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeManager : MonoBehaviour {

	public Slider sliderGeral;

	public AudioSource sourceMusic;
	public Slider sliderMusic;

	public AudioSource sourceEfeito;
	public Slider sliderEfeito;

	public Slider sliderMotor;


	// Use this for initialization
	void Start () {

		sourceMusic = GameObject.FindWithTag("music").GetComponent<AudioSource>();
		sourceEfeito = GameObject.FindWithTag("efeitos").GetComponent<AudioSource>();
		sliderMusic.value = PlayerPrefs.GetFloat("volumeMusic");
		sliderEfeito.value = PlayerPrefs.GetFloat("volumeEfeito");

		if(PlayerPrefs.HasKey("volumeMusic") == true){
			sourceMusic.volume = PlayerPrefs.GetFloat("volumeMusic");

		}
		//Se não existir, define o volume e o slider para o máximo
		else{
			sliderMusic.value = 1;
			sourceMusic.volume = sliderMusic.value;
		}

		//Checando se existe uma preferencia de volume salva para os EFEITOS
		if(PlayerPrefs.HasKey("volumeEfeito") == true){
			sourceEfeito.volume = PlayerPrefs.GetFloat("volumeEfeito");

		}
		//Se não existir, define o volume e o slider para o máximo
		else{
			sliderEfeito.value = 1;
			sourceEfeito.volume = sliderEfeito.value;
		}

		if(PlayerPrefs.HasKey("volumeMotor") == true) {
			sliderMotor.value = PlayerPrefs.GetFloat("volumeMotor");
		}
		else{
			sliderMotor.value = 1;
		}

	}

	public void definirMusic(){
		PlayerPrefs.SetFloat("volumeMusic", sliderMusic.value);
			sourceMusic.volume = PlayerPrefs.GetFloat("volumeMusic");
	}
	public void definirEfeito(){
		PlayerPrefs.SetFloat("volumeEfeito", sliderEfeito.value);
			sourceEfeito.volume = PlayerPrefs.GetFloat("volumeEfeito");
	}
	public void definirMotor(){
		PlayerPrefs.SetFloat("volumeMotor", sliderMotor.value);
	}
}
