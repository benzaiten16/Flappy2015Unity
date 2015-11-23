using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	public Transform flappy;
	Vector3 movement = Vector3.zero;
	float rotation = 0;
	public float vidas = 5;


	// Use this for initialization
	void Start () {
		movement.y = 3.35f;
		rotation = Mathf.Lerp (0, -7, 5);
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y >= 3.30f){
			movement.y = -2.50f;
			rotation = Mathf.Lerp (0, 2, 5);
		}
		else if(transform.position.y <= -2.45f){
			movement.y = 3.35f;
			rotation = Mathf.Lerp (0, -7, 5);
		}
	}

	//Update more slow than normal
	void FixedUpdate(){
		Movimiento();
	}

	void Movimiento(){
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
}
