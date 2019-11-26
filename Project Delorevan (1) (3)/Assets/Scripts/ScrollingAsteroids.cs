﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingAsteroids : MonoBehaviour {
	
	public float asteroidMoveSpeed = 3.6f;


	private Rigidbody rb;

	//Executes once
	void Start() {

		rb = GetComponent<Rigidbody> ();



	}
	//Executes every frame
	void Update() {

		rb.MovePosition (transform.position - (transform.up * Time.smoothDeltaTime * asteroidMoveSpeed));

	}
}