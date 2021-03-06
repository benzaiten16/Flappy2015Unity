using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

	Vector3 speed = Vector3.zero;
	Vector3 vForce;
	Vector3 vJump;

	public float force;
	public float jump;
	public float maxSpeed;
	public string birdState;
	public Transform spawnBullet;
	public GameObject bullet;

	public GameObject objetoPuntuacion;
    private puntuacion puntuacionScript;

	bool flap = false;
	bool hasPlayed = false;

	//Definiciones para bullet
	//private float shootingRate = 0.1f;
	private	float shootCooldown = 0f;
	//************************

	string[] states = {"normal", "unstopable", "tiny", "killer"};
	Vector3 xPosition = Vector3.zero;

	AudioSource bloob;
	AudioSource peow;
	AudioSource pipe;
	AudioSource boup;



	//Set Bird to Normal
	void setBirdToNormal(){
		
		//Set normal state
		birdState = states[0];
		
		//Set scale
		transform.localScale = new Vector3(6.064453F, 7.314585F, 1F);
		
		//Set mass values
		vForce.y = -18;
		vJump.y = 7;
		maxSpeed = 7;
		
		//Set position
		xPosition = this.gameObject.transform.position;
		xPosition.x = -4.73F;
		transform.position = xPosition;
	}



	//Use this for initialization
	void Start(){

		//Set thhe public vars
    	vForce.y = force;
    	vJump.y = jump;

    	//get script de puntuacion
		puntuacionScript = objetoPuntuacion.GetComponent<puntuacion>();


    	//Set all audio sources
    	AudioSource[] allMyAudioSources = GetComponents<AudioSource>();
	    bloob = allMyAudioSources[0];
	    peow = allMyAudioSources[1];
		pipe = allMyAudioSources[2];
		boup = allMyAudioSources[3];
		print (Application.loadedLevelName);
		//Set state according scene
		if (Application.loadedLevelName == "Final") {
			birdState = states[3];
		} 
		else {
			//Set bird
			setBirdToNormal();

		}

	}




	//Update is called once per frame
	void Update(){
		
		if(Input.GetKeyDown(KeyCode.Space)  || Input.GetMouseButtonDown(0)){
            flap = true;

            //bloob sound
            bloob.Play();
        }
        // diparando
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			if (birdState == states[3]) { 
				Fire ();
				}
			}
	}
   


	//Update more slow than normal
	void FixedUpdate(){

		//Bird movement
		speed += vForce * Time.deltaTime;
		if(flap == true){
			flap = false;
			speed.y = vJump.y;
		}
		transform.position += speed * Time.deltaTime;

		//Transform angle when bird is falling down & is flappying
		float rotation = 0;
		if(speed.y >= 0){
			rotation = Mathf.Lerp (0, 40, speed.y / maxSpeed);
		}
		else{
			rotation = Mathf.Lerp (0, -70, -speed.y / maxSpeed);
		}
		transform.rotation = Quaternion.Euler(0, 0, rotation);
	}

void Fire(){

	if (shootCooldown <= 0f){
			//Get position
		Vector3 pos = Vector3.zero;
		pos.x = this.gameObject.transform.position.x + 1;//this.gameObject.transform.position;
		pos.y = this.gameObject.transform.position.y;
			//xPosition = this.gameObject.transform.position
		var cloneBullet = Instantiate (bullet,pos,Quaternion.identity) as GameObject;
			//cloneBullet.transform.localScale = this.transform.localScale;
			//  transform.position + new Vector3(0.70f,0,0))  new Vector3(1.3f,4,0)
	}
}

/****** COLLISIONS ******/

	//When Collide
	void OnCollisionEnter2D(Collision2D Collission){

		//Collide with the sky
		if(Collission.gameObject.name == "Sky"){
			//boup sound
			boup.Play ();

			//falling
			Vector3 falling = new Vector3(0,3.0F,0);
			speed.y = -falling.y;
		}
		//Collide with his bullet
		if (Collission.gameObject.tag =="Bullet")
		{
			//Esta mal que colisione con la bala,lo dejo por mientras sacar despues******************
		}


		//Or Im not unstopable and I collide with the rest
		else if( birdState != states[1] ){

			//peow sound
			peow.Play();

			//reseteo la puntuacion
			puntuacionScript.resetPunt();

			//Restart Current Scene (Pause?)
			Application.LoadLevel("gameover");
		}

		//Else: Im unstopable bitch, but better if I dont collide with the ground o pajaro mutante
		else{
			//peow sound
			peow.Play();

			if(Collission.gameObject.name == "Ground" || Collission.gameObject.name == "Mutated_Bird")
            {
            	//reseteo la puntuacion
				puntuacionScript.resetPunt();

				//Restart Current Scene (Pause?)
				Application.LoadLevel("gameover");
			}
		}

	}



/****** POWER UPS ******/

	//PowerUp timer
	IEnumerator powerUpTimer(){
		
		//Restore Values after 7'
		yield return new WaitForSeconds(7F);
		setBirdToNormal();
		
		//Loosing powerup sound
		if(hasPlayed == false){
			pipe.Play();
			hasPlayed = true;
			yield return new WaitForSeconds(0.5F);
		}
	}


	//Used in Unstopable Power Up
	IEnumerator waitGrow(){
		
		yield return new WaitForSeconds(0.200F);
		
		//Change position & scale
		xPosition = this.gameObject.transform.position;
		xPosition.x = -3.2F;
		transform.position = xPosition;
		transform.localScale = new Vector3(32, 32, 1);
		
		//Changes mass value
		vForce.y = -20;
		vJump.y = 6;
		maxSpeed = 20;
	}

    
	//When Trigger with a powerup
	void OnTriggerEnter2D(Collider2D Collider){
		
		//Unstopable Power Up
		if(Collider.gameObject.tag == "UnstopablePowerUp"){

			//Set unstopable state to bird
	    	birdState = states[1];
			hasPlayed = false;

			//First size
			transform.localScale = new Vector3(15, 15, 1);
			
			//Delay of 0.3ms and then get 2nd size
			StartCoroutine(waitGrow());

			StartCoroutine(powerUpTimer());
		}

		//Tiny Power Up
		else if(Collider.gameObject.tag == "TinyPowerUp"){

			//Set tiny state
			birdState = states[2];
			hasPlayed= false;

			//Size
			transform.localScale = new Vector3(4, 4, 1);

			//Mass value
			vForce.y = -14;
			vJump.y = 5;
			maxSpeed = 5;

			StartCoroutine(powerUpTimer());
		}


        //Killer Power Up
        else if (Collider.gameObject.tag == "KillerPowerUp") //Chequea por TAG
        {

            //Set killer state
            birdState = states[3];
            hasPlayed = false;

            StartCoroutine(powerUpTimer());
        }
    }

} //End
