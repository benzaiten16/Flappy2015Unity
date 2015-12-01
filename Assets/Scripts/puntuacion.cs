using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class puntuacion : MonoBehaviour {
	
	public static puntuacion instanciaPuntuacion;
	public float punt = 0;
	GameObject myTextgameObject;

	void Awake(){
		if(instanciaPuntuacion == null){
			instanciaPuntuacion = this;
			DontDestroyOnLoad(gameObject);
		}
		else if(instanciaPuntuacion != this){
			Destroy(gameObject);
		}

		//Seteo el score actual
		myTextgameObject = GameObject.Find("Score");
		myTextgameObject.GetComponent<TextMesh>().text = punt.ToString();
	}

	public void sumarUno(){
		if(punt > 20){
			Application.LoadLevel("Final");
		}
		else{
			punt++;
			myTextgameObject = GameObject.Find("Score");
			myTextgameObject.GetComponent<TextMesh>().text = punt.ToString();
		}
	}

	public void resetPunt(){
		punt = 0;
		myTextgameObject = GameObject.Find("Score");
		myTextgameObject.GetComponent<TextMesh>().text = punt.ToString();
	}

	public void sumarBoss(){
		punt = punt + 50;
		myTextgameObject = GameObject.Find("Score");
		myTextgameObject.GetComponent<TextMesh>().text = punt.ToString();
	}
}