using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carMovement : MonoBehaviour {

	public GameObject carGameObject;
	public GameObject camera;
	public Transform carTransform;
	public float time;
	public int delayTime;
	public float velocity;
	public float rpm;
	public Animator animator;
	public Animator cameraAnim;
	public AudioSource sound;
	public AudioClip engineStartClip;
  	public AudioClip engineLoopClip;
	public bool endingArea = false;
	public int marcha = 0;
	public Text geartxt;
	public GameObject gearShow;
	public GameObject muitoAdiantado;
	public GameObject atrasado;
	public GameObject perfeito;
	public GameObject adiantado;
	public Rigidbody2D carRB;
	public float acceleration;
	startTime startTime;

	public bool embreagem;
	public bool acelerador;

	// Use this for initialization
	void Start () {
		embreagem = false;
		acelerador = false;
		sound.volume = PlayerPrefs.GetFloat("volumeMotor");
   		StartCoroutine(playEngineSound());
		sound = this.gameObject.GetComponent<AudioSource>();
		carGameObject = this.gameObject;
		carTransform = this.gameObject.GetComponent<Transform>();
		animator = this.gameObject.GetComponent<Animator>();
		cameraAnim = camera.GetComponent<Animator>();
		geartxt = geartxt.GetComponent<Text>();
		startTime = GameObject.Find("EventSystem").GetComponent<startTime>();
		gearShow.SetActive(false);
		carRB = GetComponent<Rigidbody2D>();
		acceleration = 2.5f;
	}

	IEnumerator playEngineSound()
         {
             sound.clip = engineStartClip;
             sound.Play();
             yield return new WaitForSeconds(sound.clip.length - 0.74f);
             sound.clip = engineLoopClip;
             sound.Play();
						 sound.pitch = 0.7f;
         }

	// Update is called once per frame
	void FixedUpdate () {
		geartxt.text = "" + marcha.ToString();
		animator.speed = rpm;
		rpm = (carRB.velocity.magnitude / 8);
		velocity = carRB.velocity.magnitude;
		cameraAnim.speed = velocity * 0.04f;

		if(Input.GetKeyDown("left alt")){
			ativarAcelerador();
		}
		else if(Input.GetKeyUp("left alt")){
			desativarAcelerador();
		}

		if(Input.GetKeyDown("left ctrl")){
			ativarEmbreagem();
		}
		else if(Input.GetKeyUp("left ctrl")){
			desativarEmbreagem();
		}

		if(endingArea == false && marcha >= 0 && marcha < 6){

			animator.speed = rpm;

			if(marcha == 0 && sound.clip == engineLoopClip){
				if(acelerador){
					if(sound.pitch <= 1.3f){
						sound.pitch += 0.01f;
					}
					else{
						if(sound.pitch > 0.9f){
							sound.pitch -= 0.3f;
						}
					}
				}
				else{
					if(sound.pitch > 0.7){
						sound.pitch -= 0.03f;
					}
				}
			}

			if(marcha == 1){
				if(velocity < 25){
					if(acelerador && !embreagem){
						carRB.AddForce(transform.right * acceleration);
						if(sound.pitch <= 1.5f){
							sound.pitch += 0.001f;
						}
					}
					else{
						if(carRB.velocity.magnitude > 3){
							carRB.AddForce(transform.right * -(acceleration/20));
						}

						if(sound.pitch > 0.33){
							sound.pitch -= 0.0003f;
						}

					}
				}
			}

			if(marcha == 2){
				if(velocity < 50){
					if(acelerador && !embreagem){
						carRB.AddForce(transform.right * acceleration);
						if(sound.pitch <= 2f){
							sound.pitch += 0.001f;
						}
					}
					else{
						if(carRB.velocity.magnitude > 3){
							carRB.AddForce(transform.right * -(acceleration/20));
						}

						if(sound.pitch > 0.33){
							sound.pitch -= 0.0003f;
						}

					}
				}
			}

			if(marcha == 3){
				if(velocity < 74){
					if(acelerador && !embreagem){
						carRB.AddForce(transform.right * acceleration);
						if(sound.pitch <= 3.2f){
							if(carRB.velocity.magnitude < 40){
								sound.pitch += 0.001f;
							}
							else{
								sound.pitch += 0.000777f;
							}
						}
					}
					else{
						if(carRB.velocity.magnitude > 3){
							carRB.AddForce(transform.right * -(acceleration/20));
						}

						if(sound.pitch > 0.33){
							sound.pitch -= 0.0003f;
						}

					}
				}
			}

			if(marcha == 4){
				if(velocity < 107){
					if(acelerador && !embreagem){
						carRB.AddForce(transform.right * acceleration);
						if(sound.pitch <= 3.2f){
							if(carRB.velocity.magnitude < 60){
								sound.pitch += 0.001f;
							}
							else{
								sound.pitch += 0.000777f;
							}
						}
					}
					else{
						if(carRB.velocity.magnitude > 3){
							carRB.AddForce(transform.right * -(acceleration/20));
						}

						if(sound.pitch > 0.33){
							sound.pitch -= 0.0003f;
						}

					}
				}
			}

			if(marcha == 5){
				if(velocity < 180){
					if(acelerador && !embreagem){
						carRB.AddForce(transform.right * acceleration);
						if(sound.pitch <= 1.4f){
							if(carRB.velocity.magnitude < 15){
								sound.pitch += 0.000555f;
							}
							else{
								sound.pitch += 0.000333f;
							}
						}
						else{
							sound.pitch -= 0.001f;
						}
					}
					else{
						if(carRB.velocity.magnitude > 3){
							carRB.AddForce(transform.right * -(acceleration/20));
						}

						if(sound.pitch > 0.33){
							sound.pitch -= 0.00009f;
						}

					}
				}
			}

			if(velocity >= 18 && velocity < 22 && marcha == 1){
				gearShow.SetActive(true);
			}
			else if(velocity >= 43 && velocity < 48 && marcha == 2){
				gearShow.SetActive(true);
			}
			else if(velocity >= 65 && velocity < 70 && marcha == 3){
				gearShow.SetActive(true);
			}
			else if(velocity >= 97 && velocity < 103 && marcha == 4){
				gearShow.SetActive(true);
			}
			else if(velocity > 130 && velocity < 160 && marcha == 5){
				gearShow.SetActive(true);
			}
			else{
				gearShow.SetActive(false);
			}
		}

		if(endingArea == true){
			animator.speed = rpm;
			rpm = (carRB.velocity.magnitude / 8);
			velocity = carRB.velocity.magnitude;
			if(sound.pitch > 0){
				sound.pitch -= 0.00098f;
			}
			if(velocity > 0.1){
				carRB.AddForce(transform.right * (-(acceleration*2.5f)));
			}

		}


	}


	public void AumentarMarcha(){

		if((marcha >= 0) && (startTime.getTempo() > 6.1f && startTime.hornPlayed == true && embreagem)){

			switch(marcha){
				case 0:
					marcha ++;
					sound.pitch = 0.7f;
					delayTime = startTime.time;
				break;

				case 1:
					if(velocity < 14){
						acceleration = 2.4f;
						sound.pitch -= 0.555f;
						ativarmuitoAdiantado();
						Invoke("desativarmuitoAdiantado", 1.5f);
						marcha ++;
						carRB.AddForce(transform.right * (-(acceleration*20)));
					}
					if(velocity >= 14 && velocity < 18){
						acceleration = 2.5f;
						sound.pitch -= 0.777f;
						ativarAdiantado();
						Invoke("desativarAdiantado", 1.5f);
						marcha ++;
						carRB.AddForce(transform.right * (-(acceleration*20)));
					}
					if(velocity >= 18 && velocity < 22){
						ativarPerfeito();
						Invoke("desativarPerfeito", 1.5f);
						acceleration = 2.9f;
						sound.pitch -= 0.444f;
						marcha ++;
						carRB.AddForce(transform.right * (-(acceleration*20)));
					}
					if(velocity >= 22 && velocity < 26){
						acceleration = 2.6f;
						sound.pitch = 1f;
						ativarAtrasado();
						Invoke("desativarAtrasado", 1.5f);
						marcha ++;
						carRB.AddForce(transform.right * (-(acceleration*20)));
					}
				break;

				case 2:
					if(velocity < 36){
						acceleration = 2.4f;
						sound.pitch -= 0.222f;
						ativarmuitoAdiantado();
						Invoke("desativarmuitoAdiantado", 1.5f);
						marcha ++;
						carRB.AddForce(transform.right * (-(acceleration*20)));
					}
					if(velocity >= 36 && velocity < 39){
						acceleration = 2.5f;
						sound.pitch = 1.3f;
						ativarmuitoAdiantado();
						Invoke("desativarmuitoAdiantado", 1.5f);
						marcha ++;
						carRB.AddForce(transform.right * (-(acceleration*20)));
					}
					if(velocity >= 39 && velocity < 43){
						acceleration = 2.6f;
						sound.pitch = 1.3f;
						ativarAdiantado();
						Invoke("desativarAdiantado", 1.5f);
						marcha ++;
						carRB.AddForce(transform.right * (-(acceleration*20)));
					}
					if(velocity >= 43 && velocity < 48){
						acceleration = 3f;
						sound.pitch = 0.8f;
						ativarPerfeito();
						Invoke("desativarPerfeito", 1.5f);
						marcha ++;
						carRB.AddForce(transform.right * (-(acceleration*20)));
					}
					if(velocity >= 48 && velocity < 51){
						acceleration = 2.7f;
						sound.pitch = 1f;
						ativarAtrasado();
						Invoke("desativarAtrasado", 1.5f);
						marcha ++;
						carRB.AddForce(transform.right * (-(acceleration*20)));
					}
				break;

				case 3:
				if(velocity < 57){
					acceleration = 2.2f;
					sound.pitch -= 0.222f;
					ativarmuitoAdiantado();
					Invoke("desativarmuitoAdiantado", 1.5f);
					marcha ++;
					carRB.AddForce(transform.right * (-(acceleration*20)));
				}
				if(velocity >= 57 && velocity < 61){
					acceleration = 2.4f;
					sound.pitch = 1.4f;
					ativarmuitoAdiantado();
					Invoke("desativarmuitoAdiantado", 1.5f);
					marcha ++;
					carRB.AddForce(transform.right * (-(acceleration*20)));
				}
				if(velocity >= 61 && velocity < 65){
					acceleration = 2.5f;
					sound.pitch = 1.4f;
					ativarAdiantado();
					Invoke("desativarAdiantado", 1.5f);
					marcha ++;
					carRB.AddForce(transform.right * (-(acceleration*20)));
				}
				if(velocity >= 65 && velocity < 70){
					acceleration = 2.9f;
					sound.pitch = 0.9f;
					ativarPerfeito();
					Invoke("desativarPerfeito", 1.5f);
					marcha ++;
					carRB.AddForce(transform.right * (-(acceleration*20)));
				}
				if(velocity >= 70 && velocity < 75){
					acceleration = 2.8f;
					sound.pitch = 1f;
					ativarAtrasado();
					Invoke("desativarAtrasado", 1.5f);
					marcha ++;
					carRB.AddForce(transform.right * (-(acceleration*20)));
				}
				break;

				case 4:
					if(carRB.velocity.magnitude < 87){
						acceleration = 2.4f;
						if(carRB.velocity.magnitude < 15){
							sound.pitch = 0.001f;
						}
						else{
							sound.pitch -= 0.222f;
						}
						ativarmuitoAdiantado();
						Invoke("desativarmuitoAdiantado", 1.5f);
						marcha ++;
						carRB.AddForce(transform.right * (-(acceleration*20)));
					}
					if(carRB.velocity.magnitude >= 87 && carRB.velocity.magnitude < 93){
						acceleration = 2.5f;
						sound.pitch = 1.3f;
						ativarmuitoAdiantado();
						Invoke("desativarmuitoAdiantado", 1.5f);
						marcha ++;
						carRB.AddForce(transform.right * (-(acceleration*20)));
					}
					if(carRB.velocity.magnitude >= 93 && carRB.velocity.magnitude < 97){
						acceleration = 2.6f;
						sound.pitch = 1.4f;
						ativarAdiantado();
						Invoke("desativarAdiantado", 1.5f);
						marcha ++;
						carRB.AddForce(transform.right * (-(acceleration*20)));
					}
					if(carRB.velocity.magnitude >= 97 && carRB.velocity.magnitude < 103){
						acceleration = 3.2f;
						sound.pitch = 1f;
						ativarPerfeito();
						Invoke("desativarPerfeito", 1.5f);
						marcha ++;
						carRB.AddForce(transform.right * (-(acceleration*20)));
					}
					if(carRB.velocity.magnitude >= 103 && carRB.velocity.magnitude < 108){
						acceleration = 2.8f;
						sound.pitch = 1.1f;
						ativarAtrasado();
						Invoke("desativarAtrasado", 1.5f);
						marcha ++;
						carRB.AddForce(transform.right * (-(acceleration*20)));
					}
				break;
			}

			/*if(marcha == 0){
				marcha ++;
			}

			//Primeira Marcha
			else if(marcha == 1){
				if(velocity <= 14){
					acceleration = 2.4f;
					sound.pitch -= 0.555f;
					ativarmuitoAdiantado();
					Invoke("desativarmuitoAdiantado", 1.5f);
					marcha ++;
				}
				else if(velocity > 13 && velocity <= 18){
					acceleration = 2.5f;
					sound.pitch -= 0.777f;
					ativarAdiantado();
					Invoke("desativarAdiantado", 1.5f);
					marcha ++;
				}
				else if(velocity > 17 && velocity < 22){
					ativarPerfeito();
					Invoke("desativarPerfeito", 1.5f);
					acceleration = 2.9f;
					sound.pitch -= 0.444f;
					marcha ++;
				}
				else if(velocity >= 21 && velocity < 26){
					acceleration = 2.6f;
					sound.pitch -= 0.777f;
					ativarAtrasado();
					Invoke("desativarAtrasado", 1.5f);
					marcha ++;
				}
			}


			//Segunda marcha
			else if(marcha == 2){
				if(velocity < 36){
					acceleration = 2.4f;
					sound.pitch -= 0.222f;
					ativarmuitoAdiantado();
					Invoke("desativarmuitoAdiantado", 1.5f);
					marcha ++;
				}
				else if(velocity >= 35 && velocity <= 39){
					acceleration = 2.5f;
					sound.pitch = 1.3f;
					ativarmuitoAdiantado();
					Invoke("desativarmuitoAdiantado", 1.5f);
					marcha ++;
				}
				else if(velocity > 38 && velocity <= 43){
					acceleration = 2.6f;
					sound.pitch = 1.3f;
					ativarAdiantado();
					Invoke("desativarAdiantado", 1.5f);
					marcha ++;
				}
				else if(velocity > 42 && velocity < 48){
					acceleration = 3f;
					sound.pitch = 1.3f;
					ativarPerfeito();
					Invoke("desativarPerfeito", 1.5f);
					marcha ++;
				}
				else if(velocity >= 47 && velocity < 51){
					acceleration = 2.7f;
					sound.pitch = 1.3f;
					ativarAtrasado();
					Invoke("desativarAtrasado", 1.5f);
					marcha ++;
				}
			}

			//Terceira Marcha
			else if(marcha == 3){
				if(velocity <= 57){
					acceleration = 2.2f;
					sound.pitch -= 0.222f;
					ativarmuitoAdiantado();
					Invoke("desativarmuitoAdiantado", 1.5f);
					marcha ++;
				}
				else if(velocity > 56 && velocity <= 61){
					acceleration = 2.4f;
					sound.pitch = 1.4f;
					ativarmuitoAdiantado();
					Invoke("desativarmuitoAdiantado", 1.5f);
					marcha ++;
				}
				else if(velocity > 60 && velocity <= 65){
					acceleration = 2.5f;
					sound.pitch = 1.4f;
					ativarAdiantado();
					Invoke("desativarAdiantado", 1.5f);
					marcha ++;
				}
				else if(velocity > 64 && velocity < 70){
					acceleration = 2.9f;
					sound.pitch = 1.3f;
					ativarPerfeito();
					Invoke("desativarPerfeito", 1.5f);
					marcha ++;
				}
				else if(velocity >= 69 && velocity < 75){
					acceleration = 2.8f;
					sound.pitch = 1.3f;
					ativarAtrasado();
					Invoke("desativarAtrasado", 1.5f);
					marcha ++;
				}
			}



			//Quarta Marcha
			else if(marcha == 4){
				if(velocity <= 87){
					acceleration = 2.4f;
					sound.pitch -= 0.005f;
					ativarmuitoAdiantado();
					Invoke("desativarmuitoAdiantado", 1.5f);
					marcha ++;
				}
				else if(velocity > 86 && velocity <= 93){
					acceleration = 2.5f;
					sound.pitch = 1.3f;
					ativarmuitoAdiantado();
					Invoke("desativarmuitoAdiantado", 1.5f);
					marcha ++;
				}
				else if(velocity > 92 && velocity <= 97){
					acceleration = 2.6f;
					sound.pitch = 1.4f;
					ativarAdiantado();
					Invoke("desativarAdiantado", 1.5f);
					marcha ++;
				}
				else if(velocity > 96 && velocity < 103){
					acceleration = 3.2f;
					sound.pitch = 1.4f;
					ativarPerfeito();
					Invoke("desativarPerfeito", 1.5f);
					marcha ++;
				}
				else if(velocity >= 102 && velocity < 107){
					acceleration = 2.8f;
					sound.pitch = 1.3f;
					ativarAtrasado();
					Invoke("desativarAtrasado", 1.5f);
					marcha ++;
				}
			}*/
		}
	}


		public void ativarmuitoAdiantado(){
			muitoAdiantado.SetActive(true);
		}
		public void ativarAtrasado(){
			atrasado.SetActive(true);
		}
		public void ativarPerfeito(){
			perfeito.SetActive(true);
			cameraAnim.SetTrigger("rightGear");
		}
		public void ativarAdiantado(){
			adiantado.SetActive(true);
		}
		public void desativarmuitoAdiantado(){
			muitoAdiantado.SetActive(false);
		}
		public void desativarAtrasado(){
			atrasado.SetActive(false);
		}
		public void desativarPerfeito(){
			perfeito.SetActive(false);
		}
		public void desativarAdiantado(){
			adiantado.SetActive(false);
		}

		public void ativarEmbreagem(){
			embreagem = true;
		}

		public void desativarEmbreagem(){
			embreagem = false;
		}

		public void ativarAcelerador(){
			acelerador = true;
		}

		public void desativarAcelerador(){
			acelerador = false;
		}

}
