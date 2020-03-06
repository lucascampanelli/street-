using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statsChanger : MonoBehaviour {

	public Text moneytxt;
	public Text exptxt;

	playerStats playerStats;

	void Start(){
		playerStats = this.gameObject.GetComponent<playerStats>();
	} 
	
	void Update () {
		moneytxt.text = "R$ " + playerStats.getMoney().ToString();
		exptxt.text = playerStats.getExp().ToString();
	}
}
