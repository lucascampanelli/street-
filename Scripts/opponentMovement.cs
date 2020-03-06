using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opponentMovement : MonoBehaviour {

	public AudioClip engineStartClip;
  	public AudioClip engineLoopClip;
	public bool endingArea = false;
	public int marcha = 0;
	public GameObject carGameObject;
	public Transform carTransform;
	public float time;
	public float velocity;
	public float rpm;
	public Animator animator;
	public AudioSource sound;
	public int gearChange;
	public Rigidbody2D opponentRB;
	public float acceleration;

	public float tempoTroca;

	startTime startTime;

	void Start () {
		tempoTroca = 0;
		gearChange = Random.Range(0, 4); //Gerando um valor aleatório que definirá o momento da troca
		StartCoroutine(playEngineSound());
		sound = this.gameObject.GetComponent<AudioSource>();
		carGameObject = this.gameObject;
		carTransform = this.gameObject.GetComponent<Transform>();
		animator = this.gameObject.GetComponent<Animator>();
		startTime = GameObject.Find("EventSystem").GetComponent<startTime>();
		opponentRB = GetComponent<Rigidbody2D>();
		acceleration = 2.5f;
	}

	void FixedUpdate () {
		
		if(tempoTroca < 10){
			tempoTroca += 0.5f;
		}


		animator.speed = rpm;
		rpm = (opponentRB.velocity.magnitude / 8);
		velocity = opponentRB.velocity.magnitude;

		if(startTime.getTempo() > 6.2f && startTime.hornPlayed){

			if(marcha == 0){
				marcha++;
				if(sound.pitch <= 3.2f){
						sound.pitch += 0.0002f;
				}
			}

			if(marcha == 1){
				//Velocidade máxima da primeira marcha
				if(velocity < 25 && tempoTroca >= 10){
					opponentRB.AddForce(transform.right * acceleration);
						if(sound.pitch <= 2f){
							sound.pitch += 0.001f;
						}
				}

				//Troca de marcha automática do oponente
				if((velocity > 7 && velocity <= 10) && gearChange == 0){
					acceleration = 2.4f;
					sound.pitch -= 0.555f;
					gearChange = Random.Range(0, 4); //Gerando um valor aleatório que definirá o momento da troca
					marcha++;
					tempoTroca = 0;
					opponentRB.AddForce(transform.right * (-(acceleration*20)));
				}
				if((velocity > 10 && velocity <= 14) && gearChange == 1){
					acceleration = 2.4f;
					sound.pitch -= 0.555f;
					gearChange = Random.Range(0, 4); //Gerando um valor aleatório que definirá o momento da troca
					marcha++;
					tempoTroca = 0;
					opponentRB.AddForce(transform.right * (-(acceleration*20)));
				}
				if((velocity > 13 && velocity <= 17) && gearChange == 2){
					acceleration = 2.5f;
					sound.pitch -= 0.777f;
					gearChange = Random.Range(0, 4); //Gerando um valor aleatório que definirá o momento da troca
					marcha++;
					tempoTroca = 0;
					opponentRB.AddForce(transform.right * (-(acceleration*20)));
				}
				if((velocity > 17 && velocity < 22) && gearChange == 3){
					acceleration = 2.9f;
					sound.pitch -= 0.444f;
					gearChange = Random.Range(0, 4); //Gerando um valor aleatório que definirá o momento da troca
					marcha++;
					tempoTroca = 0;
					opponentRB.AddForce(transform.right * (-(acceleration*20)));
				}
				if((velocity >= 22 && velocity < 26) && gearChange == 4){
					acceleration = 2.6f;
					sound.pitch -= 0.777f;
					gearChange = Random.Range(0, 4); //Gerando um valor aleatório que definirá o momento da troca
					marcha++;
					tempoTroca = 0;
					opponentRB.AddForce(transform.right * (-(acceleration*20)));
				}
			}

			if(marcha == 2){
				//Velocidade máxima da segunda marcha
				if(velocity < 50 && tempoTroca >= 10){
					opponentRB.AddForce(transform.right * acceleration);
						if(sound.pitch <= 2.8f){
							sound.pitch += 0.001f;
						}
				}

				//Troca de marcha automática do oponente
				if((velocity > 30 && velocity < 36) && gearChange == 0){
					acceleration = 2.4f;
					sound.pitch -= 0.222f;
					gearChange = Random.Range(0, 4); //Gerando um valor aleatório que definirá o momento da troca
					marcha++;
					tempoTroca = 0;
					opponentRB.AddForce(transform.right * (-(acceleration*20)));
				}
				if((velocity >= 36 && velocity <= 39) && gearChange == 1){
					acceleration = 2.5f;
					sound.pitch = 1.3f;
					gearChange = Random.Range(0, 4); //Gerando um valor aleatório que definirá o momento da troca
					marcha++;
					tempoTroca = 0;
					opponentRB.AddForce(transform.right * (-(acceleration*20)));
				}
				if((velocity > 39 && velocity <= 43) && gearChange == 2){
					acceleration = 2.6f;
					sound.pitch = 1.3f;
					gearChange = Random.Range(0, 4); //Gerando um valor aleatório que definirá o momento da troca
					marcha++;
					tempoTroca = 0;
					opponentRB.AddForce(transform.right * (-(acceleration*20)));
				}
				if((velocity > 43 && velocity < 48) && gearChange == 3){
					acceleration = 3f;
					sound.pitch = 1.3f;
					gearChange = Random.Range(0, 4); //Gerando um valor aleatório que definirá o momento da troca
					marcha++;
					tempoTroca = 0;
					opponentRB.AddForce(transform.right * (-(acceleration*20)));
				}
				if((velocity >= 478 && velocity < 51) && gearChange == 4){
					acceleration = 2.7f;
					sound.pitch = 1.3f;
					gearChange = Random.Range(0, 4); //Gerando um valor aleatório que definirá o momento da troca
					marcha++;
					tempoTroca = 0;
					opponentRB.AddForce(transform.right * (-(acceleration*20)));
				}
			}

			if(marcha == 3 && tempoTroca >= 10){

				//Velocidade máxima da terceira marcha
				if(velocity < 74){
					opponentRB.AddForce(transform.right * acceleration);
						if(sound.pitch <= 3.2f){
							sound.pitch += 0.000899f;
						}
				}

				//Troca de marcha automática do oponente
				if((velocity > 53 && velocity <= 57) && gearChange == 0){
					acceleration = 2.2f;
					sound.pitch -= 0.222f;
					gearChange = Random.Range(0, 4); //Gerando um valor aleatório que definirá o momento da troca
					marcha++;
					tempoTroca = 0;
					opponentRB.AddForce(transform.right * (-(acceleration*20)));
				}
				if((velocity > 57 && velocity <= 61) && gearChange == 1){
					acceleration = 2.4f;
					sound.pitch = 1.4f;
					gearChange = Random.Range(0, 4); //Gerando um valor aleatório que definirá o momento da troca
					marcha++;
					tempoTroca = 0;
					opponentRB.AddForce(transform.right * (-(acceleration*20)));
				}
				if((velocity > 61 && velocity <= 65) && gearChange == 2){
					acceleration = 2.5f;
					sound.pitch = 1.4f;
					gearChange = Random.Range(0, 4); //Gerando um valor aleatório que definirá o momento da troca
					marcha++;
					tempoTroca = 0;
					opponentRB.AddForce(transform.right * (-(acceleration*20)));
				}
				if((velocity > 65 && velocity < 70) && gearChange == 3){
					acceleration = 2.9f;
					sound.pitch = 1.3f;
					gearChange = Random.Range(0, 4); //Gerando um valor aleatório que definirá o momento da troca
					marcha++;
					tempoTroca = 0;
					opponentRB.AddForce(transform.right * (-(acceleration*20)));
				}
				if((velocity >= 70 && velocity < 75) && gearChange == 4){
					acceleration = 2.8f;
					sound.pitch = 1.3f;
					gearChange = Random.Range(0, 4); //Gerando um valor aleatório que definirá o momento da troca
					marcha++;
					tempoTroca = 0;
					opponentRB.AddForce(transform.right * (-(acceleration*20)));
				}
			}

			if(marcha == 4 && tempoTroca >= 10){

				//Velocidade máxima da quarta marcha
				if(velocity < 107){
					opponentRB.AddForce(transform.right * acceleration);
						if(sound.pitch <= 3.2f){
							sound.pitch += 0.000555f;
						}
				}

				//Troca de marcha automática do oponente
				if((velocity > 83 && velocity <= 87) && gearChange == 0){
					acceleration = 2.4f;
					sound.pitch -= 0.005f;
					gearChange = Random.Range(0, 4); //Gerando um valor aleatório que definirá o momento da troca
					marcha++;
					tempoTroca = 0;
					opponentRB.AddForce(transform.right * (-(acceleration*20)));
				}
				if((velocity > 87 && velocity <= 93) && gearChange == 1){
					acceleration = 2.5f;
					sound.pitch = 1.3f;
					gearChange = Random.Range(0, 4); //Gerando um valor aleatório que definirá o momento da troca
					marcha++;
					tempoTroca = 0;
					opponentRB.AddForce(transform.right * (-(acceleration*20)));
				}
				if((velocity > 93 && velocity <= 97) && gearChange == 2){
					acceleration = 2.6f;
					sound.pitch = 1.4f;
					gearChange = Random.Range(0, 4); //Gerando um valor aleatório que definirá o momento da troca
					marcha++;
					opponentRB.AddForce(transform.right * (-(acceleration*20)));
					tempoTroca = 0;
				}
				if((velocity > 97 && velocity < 103) && gearChange == 3){
					acceleration = 3.2f;
					sound.pitch = 1.4f;
					gearChange = Random.Range(0, 4); //Gerando um valor aleatório que definirá o momento da troca
					marcha++;
					opponentRB.AddForce(transform.right * (-(acceleration*20)));
					tempoTroca = 0;
				}
				if((velocity >= 103 && velocity < 107) && gearChange == 4){
					acceleration = 2.8f;
					sound.pitch = 1.3f;
					gearChange = Random.Range(0, 4); //Gerando um valor aleatório que definirá o momento da troca
					marcha++;
					opponentRB.AddForce(transform.right * (-(acceleration*20)));
					tempoTroca = 0;
				}
			}

			if(marcha == 5 && tempoTroca >= 10){

				//Velocidade máxima da quinta marcha
				if(velocity < 180){
					opponentRB.AddForce(transform.right * acceleration);
						if(sound.pitch <= 3f){
							sound.pitch += 0.00000222f;
						}
				}

				//Troca de marcha automática do oponente
				/*if((velocity > 7.5 && velocity < 8.2) && gearChange == 0){
					velocity -= 0.7f;
					sound.pitch -= 1f;
					gearChange = Random.Range(0, 4); //Gerando um valor aleatório que definirá o momento da troca
					marcha++;
				}
				if((velocity > 8.2 && velocity < 8.5) && gearChange == 1){
					velocity -= 0.6f;
					sound.pitch -= 1f;
					gearChange = Random.Range(0, 4); //Gerando um valor aleatório que definirá o momento da troca
					marcha++;
				}
				if((velocity > 8.5 && velocity < 8.7) && gearChange == 2){
					velocity -= 0.5f;
					sound.pitch -= 1.2f;
					gearChange = Random.Range(0, 4); //Gerando um valor aleatório que definirá o momento da troca
					marcha++;
				}
				if((velocity > 8.7 && velocity < 9) && gearChange == 3){
					velocity += 1f;
					sound.pitch -= 1.5f;
					gearChange = Random.Range(0, 4); //Gerando um valor aleatório que definirá o momento da troca
					marcha++;
				}
				if((velocity > 9 && velocity < 9.3) && gearChange == 4){
					velocity -= 0.2f;
					sound.pitch -= 1.6f;
					gearChange = Random.Range(0, 4); //Gerando um valor aleatório que definirá o momento da troca
					marcha++;
				}*/
			}

			if(endingArea == true){
				animator.speed = rpm;
				rpm = (opponentRB.velocity.magnitude / 8);
				velocity = opponentRB.velocity.magnitude;
				if(sound.pitch > 0){
					sound.pitch -= 0.0026f;
				}
				if(velocity > 0.1){
					opponentRB.AddForce(transform.right * (-(acceleration*2.5f)));
				}
		}
		}
	}

	IEnumerator playEngineSound(){
        sound.clip = engineStartClip;
        sound.Play();
        yield return new WaitForSeconds(sound.clip.length - 0.74f);
        sound.clip = engineLoopClip;
        sound.Play();
		sound.pitch = 0.7f;
		sound.volume = 0.1f;
    }

}
