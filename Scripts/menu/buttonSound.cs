using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonSound : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip[] clips;

	void Start(){
		audioSource = this.gameObject.GetComponent<AudioSource>();
		DontDestroyOnLoad(this.gameObject);
	}

	public void NormalBtn(){
		audioSource.clip = clips[0];
		audioSource.Play();
	}

}
