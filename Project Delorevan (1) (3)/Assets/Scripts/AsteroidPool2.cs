﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPool2 : MonoBehaviour {

    public GameObject asteroid;
    public int amountOfAsteroids;
    private GameObject[] asteroids;
    private int currentAsteroid;
    private Vector3 astPoolPosition = new Vector3(-11f, -11f, -0.5f);
    private float timeSinceLastSpawned;
    public float spawnRate = 5f;
    private int currentBar = 0;

    // Use this for initialization
    void Start()
    {

        asteroids = new GameObject[amountOfAsteroids];
        for (int i = 0; i < amountOfAsteroids; i++)
        {
            asteroids[i] = (GameObject)Instantiate(asteroid, astPoolPosition, Quaternion.Euler(new Vector3(0, 0, -180)));
        }

    }

    // Update is called once per frame
    void Update()
    {

        timeSinceLastSpawned += Time.deltaTime;

        if (timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            asteroids[currentBar].transform.position = new Vector3(Random.Range(-6f, -9f), Random.Range(-0.5f, 3f), -0.5f);
            currentBar++;
            if (currentBar >= amountOfAsteroids)
            {
                currentBar = 0;
            }
        }
    }
}
