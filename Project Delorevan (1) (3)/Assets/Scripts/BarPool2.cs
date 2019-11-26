using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarPool2 : MonoBehaviour {

	public int barPoolSize = 8;
	public GameObject barPrefab;
	private GameObject[] bars;
	private Vector3 barPoolPosition = new Vector2 (-1.5f, -10f);
	private float timeSinceLastSpawned;
	public float spawnRate = 3f;
	public float spawnXPos = 1f;
	public float spawnYPos = 15f;
	public float spawnZPos = -0.5f;
	private int currentBar = 0;

	// Use this for initialization
	void Start () 
	{

		bars = new GameObject[barPoolSize];
		for (int i = 0; i < barPoolSize; i++) 
		{
			bars [i]	= (GameObject)Instantiate (barPrefab, barPoolPosition, Quaternion.identity);
		}

	}

	// Update is called once per frame
	void Update () 
	{
		timeSinceLastSpawned += Time.deltaTime;

		if (timeSinceLastSpawned >= spawnRate) 
		{
			timeSinceLastSpawned = 0;
			bars [currentBar].transform.position = new Vector3 (spawnXPos, spawnYPos, spawnZPos);
			currentBar++;
			if (currentBar >= barPoolSize) 
			{
				currentBar = 0;
			}
		}
	}
}
