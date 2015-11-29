using UnityEngine;
using System.Collections;

public class pausa : MonoBehaviour {
	bool pausado = false;
	// Use this for initialization
	void Start () {

		

	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.Escape)) { 
			pausado = !pausado; //Cambia el valor de la variable boolean "pausado" de "false" a "true" y viceversa cada vez que se pulsa la tecla elegida. 
			
			if (pausado == false) { // 
				Time.timeScale = 1; 
			} 
			else { 
				Time.timeScale = 0; 
				Cursor.visible = false; 
			} 
			
		} 
		
	} 
	
	
	void OnGUI(){ 
		
		if(pausado){ 
			Cursor.visible = true; 
			GUI.Box(new Rect(0,0,Screen.width,Screen.height),"PAUSA"); 
			GUI.backgroundColor = Color.blue; 
			
			if(GUI.Button(new Rect(Screen.width/2-100,(Screen.height/2)-0,200,50),"Reiniciar juego")){ 
				Application.LoadLevel("Main"); 
			} 
			
			if(GUI.Button(new Rect(Screen.width/2-100,(Screen.height/2)-50,200,50),"Menu Principal")){ 
				Application.LoadLevel("Menues");
			} 
			
			if(GUI.Button(new Rect(Screen.width/2-100,(Screen.height/2)-100,200,50),"Salir")){ 
				Application.Quit(); 
			} 
			
		} 
		
	} 
}
