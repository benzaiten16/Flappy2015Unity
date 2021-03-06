﻿using UnityEngine;
using System.Collections;

public class Tubes : MonoBehaviour {

    Vector3 vSpeed;
    Vector3 vDistance;
    bool hasPlayed = false;


    public GameObject objetoPuntuacion;
    private puntuacion puntuacionScript;

    public float speed;
    public float distance;
	//public bool arranca = false; **********************************1 comento

	// Use this for initialization
	void Start(){ 

		//get script de puntuacion
		puntuacionScript = objetoPuntuacion.GetComponent<puntuacion>();
		
		vSpeed.x = speed;
		vDistance.x = distance;
		//Time.timeScale = 0; ***********************************2 comento
	}
	
	// Update is called once per frame
	void Update(){
		//Time.timeScale = 1;
		scrollTubes (); //Para como estaba antes hay que descomentar esto 3
		/*********************************** 4 comento
			if(Input.GetKeyDown(KeyCode.Space)  || Input.GetMouseButtonDown(0)){
			//Time.timeScale = 0;
				arranca = true;
		}
		if (arranca) {
			Time.timeScale = 1;
			scrollTubes ();
		}*/
	}



	private void scrollTubes(){

        //Scroll
        this.transform.position = this.transform.position + (vSpeed * Time.deltaTime);
 		/**
        //Out of camera position
        if (this.transform.position.x <= -8.22f){

        	//New respawn postion 'x'
            Vector3 newRespawn = this.transform.position + vDistance;
            
            //Set a random range of 'y' for respawn
            newRespawn.y = Random.Range (1.3f, 5f);
            
            //Move the old tube to the respawn area
            this.transform.position = newRespawn;

            //Reset sfx flag
            hasPlayed = false;
        }
		**/
        //Play audio
		if( (this.transform.position.x <= -5f) && (hasPlayed == false) ){
			GetComponent<AudioSource>().Play();
			hasPlayed = true;

			
			puntuacionScript.sumarUno();
        }

    }


	//Destroy tube anim
	IEnumerator detroyTube(){
		GetComponent<Animation>().Play("TubesGone");
		yield return new WaitForSeconds(1F);
		Destroy(gameObject);
	}


    //When Collide
    void OnCollisionEnter2D(Collision2D Collission){

		//Get publics components of Bird.cs script
		Bird bird = Collission.gameObject.GetComponent<Bird>();

		//Destroy when bird is unstopable
		if(bird.birdState == "unstopable"){
			puntuacionScript.sumarUno();
			StartCoroutine(detroyTube());
        }

    }
}
