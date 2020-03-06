using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musicManager : MonoBehaviour {

	public AudioClip[] musics;
	public Sprite[] musicArts;
	public AudioClip currentMusic;
	public AudioSource audioSource;
	public GameObject popup;
	public Animator anim;
	public Text nome;
	public Text artista;
	public Image art;
	public int playingMus;
	public int musicaAnterior;

	// Use this for initialization
	void Awake() {

		GameObject[] objs = GameObject.FindGameObjectsWithTag("music");

		if (objs.Length > 1)
		{
			Destroy(this.gameObject);
		}

		DontDestroyOnLoad(this.gameObject);
	}

	void Update () {
		if(audioSource.isPlaying == false){
			playingMus = Random.Range(0, musics.Length);
			if(playingMus == musicaAnterior){
				return;
			}
			else{
				audioSource.clip = musics[playingMus];
				audioSource.Play();
				infoPopup(playingMus);
				musicaAnterior = playingMus;
				popup.SetActive(true);
				anim.SetTrigger("ativar");
				Invoke("desativarPopup", 10f);
			}
		}
	}

	public void infoPopup(int m){
		switch(m){
			case 0:
			nome.text = "nightwalk";
			artista.text = "airtone";
			art.sprite = musicArts[0];
			break;

			case 1:
			nome.text = "I Dunno";
			artista.text = "Grapes";
			art.sprite = musicArts[1];
			break;

			case 2:
			nome.text = "Control";
			artista.text = "High Rule";
			art.sprite = musicArts[2];
			break;

			case 3:
			nome.text = "Probably Shouldn't";
			artista.text = "DJ Lang59";
			art.sprite = musicArts[3];
			break;

			case 4:
			nome.text = "Come Inside";
			artista.text = "Snowflake";
			art.sprite = musicArts[4];
			break;

			case 5:
			nome.text = "Living Nightmare";
			artista.text = "Snowflake";
			art.sprite = musicArts[5];
			break;

			case 6:
			nome.text = "Unify";
			artista.text = "Snowflake";
			art.sprite = musicArts[6];
			break;

			case 7:
			nome.text = "On Demand";
			artista.text = "High Rule";
			art.sprite = musicArts[7];
			break;

			case 8:
			nome.text = "FOMO";
			artista.text = "High Rule";
			art.sprite = musicArts[8];
			break;

			case 9:
			nome.text = "Alive";
			artista.text = "High Rule";
			art.sprite = musicArts[9];
			break;

			case 10:
			nome.text = "Basic";
			artista.text = "High Rule";
			art.sprite = musicArts[10];
			break;
		}
	}

	public void desativarPopup(){
		popup.SetActive(false);
	}

	public void pularMusica(){
		audioSource.Stop();
	}

}
