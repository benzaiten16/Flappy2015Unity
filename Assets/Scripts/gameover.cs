using UnityEngine;
using System.Collections;

public class gameover : MonoBehaviour {
	int y=0;
	// Use this for initialization
	void Start () {
		
		for (int x = 0; x < 5000; x++ ){
			y++;	
			
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (y > 4999){
			Debug.Log("yyyy: " + y);
			Application.LoadLevel("Main");
		}
	}
}
