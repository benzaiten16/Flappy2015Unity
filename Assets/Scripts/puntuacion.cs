using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class puntuacion : MonoBehaviour {
	
	public float punt = 0;
	GameObject myTextgameObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void sumarUno(){
		if(punt > 10){
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
}