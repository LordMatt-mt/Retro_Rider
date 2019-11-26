using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI2 : MonoBehaviour {

    private int scores = 0;
    public Text scoreText;
    public Text scoreText2;
    public Text highScores;

    // Use this for initialization
    void Start()
    {

        highScores.text = PlayerPrefs.GetInt("Bests", 0).ToString();
  
    }

    // Update is called once per frame
    void Update()
    {

        if (scores > PlayerPrefs.GetInt("Bests", 0))
        {
            PlayerPrefs.SetInt("Bests", scores);
            highScores.text = scores.ToString();
        }
    }

    void OnTriggerEnter(Collider coll)
    {

        if (coll.gameObject.tag == "Points")
        {
            print("Collided");
            scores += 1;
            scoreText.text = "SCORE: " + scores;
            scoreText2.text = "Score: " + scores;
           
        }

    }
		
    public void ReloadBrutaller()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
