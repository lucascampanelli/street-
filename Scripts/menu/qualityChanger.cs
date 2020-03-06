using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class qualityChanger : MonoBehaviour {

	public int currentQuality;
	public Slider slider;
	public int sliderValue;

	void Start (){
		QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("qualidade"), true);
		slider.value = PlayerPrefs.GetInt("qualidade");
	}

	// Update is called once per frame
	public void Definir () {
		sliderValue = (Mathf.FloorToInt(slider.value));
		currentQuality = sliderValue;
		PlayerPrefs.SetInt("qualidade", currentQuality);
		QualitySettings.SetQualityLevel(currentQuality, true);
	}
}
