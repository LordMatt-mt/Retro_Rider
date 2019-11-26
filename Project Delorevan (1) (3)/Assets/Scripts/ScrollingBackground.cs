using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

    public float backgroundSpeed = 0.2f;
    private Renderer rd;

	// Use this for initialization
	void Start () {

        rd = GetComponent<Renderer>();

	}
	
	// Update is called once per frame
	void Update () {

        Vector2 offSet = new Vector2(0, Time.time * backgroundSpeed);

        rd.material.mainTextureOffset = offSet;

	}
}
