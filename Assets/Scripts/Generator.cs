using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

	public GameObject[] obj;  //Lista objetos a generar
	public float tiempoMin = 1f;  //Tiempo minimo de lapso
	public float tiempoMax = 1f;  //Tiempo maximo de lapso
	public GameObject[] pwr; //Lista de Powerups a generar
	GameObject tube;

	// Use this for initialization
	void Start () {
		GenerateTube ();
		GeneratePowerup ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void GeneratePowerup (){
		//Las monedas se instancian cada x cantidad de tubos, y para que sean alcanzables y no se superpongan
		//con los tubos, se toma de referencia el valor 'y' del ultimo tubo generado y se varia entre -1.5 y -3.5 
 		
		//Instancia de nueva powerUp
		Vector3 pos = tube.transform.position + new Vector3 (0, Random.Range (-1.7f, -3.6f),0);
		Instantiate ((pwr [Random.Range (0, pwr.Length)]),pos, (Quaternion.identity)); 
		Invoke ("GeneratePowerup", 11f);
	}
	void GenerateTube(){ 
		//Instancia de nuevo tubo
		tube = (GameObject)Instantiate ((obj [Random.Range (0, obj.Length)]),new Vector3(8,Random.Range (2.50f, 6.10f),0), (Quaternion.identity)); 
		Invoke ("GenerateTube", Random.Range (tiempoMin, tiempoMax));
	}
}
