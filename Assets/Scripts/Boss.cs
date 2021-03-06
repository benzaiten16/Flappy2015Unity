﻿using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	public Transform flappy;
	public float vidas = 5;
	public GameObject explotion;

	public GameObject objetoPuntuacion;
    private puntuacion puntuacionScript;
	
	Vector3 movement = Vector3.zero;
	Vector3 attackMovement = Vector3.zero;
	Vector3 repositionPlace = Vector3.zero;

	AudioSource peow;

	float rotation = 0;
	float tiempo = 0;
	float attackSpeed = 1;
	float xPosOriginal = 4.86f;

	bool ataco = false;
	bool reposition = false;
	bool arranca = false;




	// Use this for initialization
	void Start () {

		//get script de puntuacion
		puntuacionScript = objetoPuntuacion.GetComponent<puntuacion>();

		Time.timeScale = 0;
		repositionPlace.x = 9.30f;
		repositionPlace.y = transform.position.y;
		repositionPlace.z = transform.position.z;
		
		movement.y = 3.35f;
		rotation = Mathf.Lerp (0, -7, 5);
		attackMovement.x = -9f;

		//Set all audio sources
    	AudioSource[] allMyAudioSources = GetComponents<AudioSource>();
	    peow = allMyAudioSources[0];

		//seteo al bird en estado Killer
		//Cri cri



	}
	

	void Update(){


		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
			//Time.timeScale = 0;
			arranca = true;
		}
		

		if (arranca) {
			Time.timeScale = 1;
			if (ataco == true) {
				Attack ();
			} else if (reposition == true) {
				Reposition ();
			} else if (Time.time > tiempo) {
				Prepare ();
			} else {
				Movimiento ();
			}
		}

		//Debug.Log (vidas);

	}



	void Movimiento(){

		if(transform.position.y >= 3.30f){
			movement.y = -2.50f;
			rotation = Mathf.Lerp (0, 2, 5);
		}
		else if(transform.position.y <= -2.45f){
			movement.y = 3.35f;
			rotation = Mathf.Lerp (0, -7, 5);
		}

		if(vidas > 3){
			transform.position += movement * (Time.deltaTime / 1.3f);
		}
		else if(vidas == 3){
			transform.position += movement * (Time.deltaTime);
		}
		else if(vidas < 3){
			transform.position += movement * (Time.deltaTime * 1.5f);
		}

		transform.rotation = Quaternion.Euler(0, 0, rotation);
	}


	void Prepare(){
		
		if(this.transform.position.y > 2.10f && this.transform.position.y < 3.70f && flappy.transform.position.y > 1.6f && flappy.transform.position.y < 4.50f){
			ataco = true;
		}
		else if(this.transform.position.y > -0.40f && this.transform.position.y < 1f && flappy.transform.position.y > -1.5f && flappy.transform.position.y < 1.6f){
			ataco = true;
		}
		else if(this.transform.position.y > -2.75f && this.transform.position.y < -0.40f && flappy.transform.position.y > -3.3f && flappy.transform.position.y < -1.5f){
			ataco = true;
		}
		else{
			tiempo = Time.time + attackSpeed;
		}
	}


	void Attack(){
		if(transform.position.x <= attackMovement.x){
			ataco = false;
			reposition = true;
		}
		else{
			transform.position += attackMovement * (Time.deltaTime);
		}
	}

	void Reposition(){
		//transform.position = repositionPlace;
		
		if(transform.position.x > xPosOriginal){
			reposition = false;
			tiempo = Time.time + 7;
		}
		else{
			transform.position -= attackMovement * (Time.deltaTime/2);
		}
		
	}



	//When Collide
	void OnCollisionEnter2D(Collision2D Collission){

		peow.Play();

		//Collide with the sky
		if(Collission.gameObject.tag == "Bullet"){ 
			if(vidas > 1){
				vidas--;

			}
			else{
				puntuacionScript.sumarBoss();
				Instantiate(explotion,transform.position,(Quaternion.identity));
				Destroy(gameObject); 	

			}

		}
	}

	void OnGUI(){ 
		
		if(vidas < 1){ 
		//Time.timeScale = 0.30f; 
		//Cursor.visible = true; 
		GUI.Box(new Rect(0,0,Screen.width,Screen.height),"Felicitaciones"); 
		GUI.Box(new Rect(0,100,Screen.width,Screen.height),"You WIN"); 
		GUI.backgroundColor = Color.green; 

		if(GUI.Button(new Rect(Screen.width/2-100,(Screen.height/2)-0,200,50),"Reiniciar juego")){ 
			Application.LoadLevel("Main"); 
			Time.timeScale = 1; 
		} 
		
		if(GUI.Button(new Rect(Screen.width/2-100,(Screen.height/2)-50,200,50),"Menu Principal")){ 
			Application.LoadLevel("Menues");
			Time.timeScale = 1; 
		} 
		
		if(GUI.Button(new Rect(Screen.width/2-100,(Screen.height/2)-100,200,50),"Salir")){ 
			Application.Quit(); 
		} 
		
		} 

	} 

	/* Para cuando pierde*/ // Hay q ver cual es el descencadenante
	/*void OnGUI1(){ 
		
		//if(vidas <= 1){ 
			Time.timeScale = 0.30f; 
			//Cursor.visible = true; 
			GUI.Box(new Rect(0,0,Screen.width,Screen.height),"Lo siento!"); 
			GUI.Box(new Rect(0,100,Screen.width,Screen.height),"You LOSE"); 
			GUI.backgroundColor = Color.red; 
			
			if(GUI.Button(new Rect(Screen.width/2-100,(Screen.height/2)-0,200,50),"Reiniciar juego")){ 
				Application.LoadLevel("Main"); 
				Time.timeScale = 1; 
			} 
			
			if(GUI.Button(new Rect(Screen.width/2-100,(Screen.height/2)-50,200,50),"Menu Principal")){ 
				Application.LoadLevel("Menues");
				Time.timeScale = 1; 
			} 
			
			if(GUI.Button(new Rect(Screen.width/2-100,(Screen.height/2)-100,200,50),"Salir")){ 
				Application.Quit(); 
			} 
			
		//} 
		
	} */

}
