﻿using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	private Vector2 speed = new Vector2 (15,0);
	private	Rigidbody2D rbBullet;
	// Use this for initialization
	void Start () {

		rbBullet = GetComponent<Rigidbody2D>();
		rbBullet.velocity = speed * this.transform.localScale.x;
		Destroy (gameObject, 3);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//When Collide
	void OnCollisionEnter2D(Collision2D Collission){
		Destroy (gameObject);
	}
}
