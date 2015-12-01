using UnityEngine;
using System.Collections;

public class cargaEscena : MonoBehaviour {
	int y=0;
	// Use this for initialization
	void Start () {

		for (int x = 0; x < 5000; x++ ){
			y++;	
			
		}

	
	}
	
	// Update is called once per frame
	void Update () {

		if (y > 4000){
			Debug.Log("yyyy: " + y);
			Application.LoadLevel("Final");
		}
	}
}
