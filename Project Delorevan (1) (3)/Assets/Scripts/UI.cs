using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UI : MonoBehaviour {

	private int score = 0;
    public Text scoreText;
	public Text scoreText2;
    public Text highScore;

	// Use this for initialization
	void Start () {
		
        highScore.text = PlayerPrefs.GetInt("Best", 0).ToString();

	}
	
	// Update is called once per frame
	void Update () {
		
        if(score > PlayerPrefs.GetInt("Best", 0))
        {
            PlayerPrefs.SetInt("Best", score);
            highScore.text = score.ToString();
	
        }
    }

	void OnTriggerEnter(Collider coll)
	{

		if (coll.gameObject.tag == "Point") {
			score += 1;
			scoreText.text = "SCORE: " + score;
			scoreText2.text = "Score: " + score;
		} 
	

	}

	public void ReloadBrutal()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
