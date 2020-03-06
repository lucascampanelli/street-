using UnityEngine;

using System.Collections;



public class velocimetro : MonoBehaviour {

        public Rigidbody2D Carro;   //seu carro ou corpo de velocidade

        public float AnguloMultipler = 1;

        public float Velocidade;

        void Update(){
        	Velocidade = (-Carro.velocity.magnitude * AnguloMultipler);
            transform.eulerAngles = new Vector3 (0, 0, Velocidade);
        }

    }
