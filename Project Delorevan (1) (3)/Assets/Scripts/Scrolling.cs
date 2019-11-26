using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour {

	public float forceMult = 3.6f;


	private Rigidbody rb;

	//Executes once
	void Start() {

		rb = GetComponent<Rigidbody> ();

		StartCoroutine (SpeedUp ());
	
	}
	//Executes every frame
	void Update() {

		rb.MovePosition (transform.position - (transform.up * Time.smoothDeltaTime * forceMult));
	
	}


	IEnumerator SpeedUp ()
	{
		do {
			yield return new WaitForSeconds (4f);
			forceMult = forceMult + 0.1f;
			Debug.Log ("force" + forceMult.ToString ());
		} while (forceMult != 6.399998f);

			



	}



}
