using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class positionofSlider : MonoBehaviour {

	public Slider sliderEnemy;
	public Slider sliderPlayer;
	public Transform car;
	public Transform enemyCar;

	// Update is called once per frame
	void Update () {
		if(car.position.x < 6800f){
		sliderPlayer.value = car.position.x;
		sliderEnemy.value = enemyCar.position.x;
		}
		else{
			sliderPlayer.value = 6800f;
			sliderEnemy.value = 6800f;
		}
	}
}
