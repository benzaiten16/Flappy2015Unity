using UnityEngine;
using System.Collections;

public class pusainicioescena : MonoBehaviour {
	bool pausado = true;
	// Use this for initialization
	void Start () {
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) { 
			pausado = !pausado; //Cambia el valor de la variable boolean "pausado" de "false" a "true" y viceversa cada vez que se pulsa la tecla elegida. 
			
			if (pausado == false) { // 
				Time.timeScale = 1; 
			} else { 
				Time.timeScale = 0; 
				Cursor.visible = false; 
			} 
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}