using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {

	public Canvas image;
	public new Camera camera;
	private Ray ray;
	private RaycastHit hit;
	public GameObject player;
	public bool drag = false;
	private Animator an;
    private SphereCollider freeze;
	private SpriteRenderer sp;
    public AudioClip die;
	public GameObject circle;
    public GameObject flame1;
    public GameObject flame2;

    void Start() 
	{
		an = GetComponent<Animator> () ;
	
        freeze = GetComponent<SphereCollider>();
		sp = GetComponent<SpriteRenderer> ();
	}
		
	void Update()
	{
	  //############THIS CODE JUST CASTS A SPHERECAST ONTO THE PLAYER SO YOU CAN DRAG IT AROUND	
	  if (Input.touchCount > 0) 
		{
			if (Input.GetTouch (0).phase == TouchPhase.Began)
			{
				ray = camera.ScreenPointToRay (Input.mousePosition);
				if (Physics.SphereCast(ray, 0.3f, out  hit)) {
					drag = true;
					if (hit.collider.name == "Player") 
					{
						player = hit.collider.gameObject;
						circle.gameObject.SetActive (true);
					}
			
	            }
		    }

			//begin the touch phase to move the player
		if (player) 
    	 {

				if (Input.GetTouch (0).phase == TouchPhase.Moved) 
				{
					ray = camera.ScreenPointToRay (Input.mousePosition);
					drag = true;
					if (Physics.SphereCast (ray, 0.3f, out hit)) {
						player.transform.position = new Vector3 (hit.point.x, hit.point.y, player.transform.position.z);

						circle.gameObject.SetActive (true);
				}
			}
		}

		if (Input.GetTouch (0).phase == TouchPhase.Ended) 
			{
				drag = false;
				circle.gameObject.SetActive (false);
			}
		}
      //#####################################################################################


     //#######THIS CODE IS FOR KEEPING THE CHARACTER WITHIN BOUND OF THE SCREEN
		if (transform.position.x >= 2.7f) 
		{
			transform.position = new Vector3 (2.7f, transform.position.y, transform.position.z);
		} 
		else if (transform.position.x <= -2.7f) 
		{
			transform.position = new Vector3 (-2.7f, transform.position.y, transform.position.z);
		} 
		else if (transform.position.y <= -4.23f) 
		{
			transform.position = new Vector3 (transform.position.x, -4.23f, transform.position.z);
		}
	}
    //######################################################################################


    //######### This code checks if player collided with asteroid or bars and trigger game over screen and audio source etc.....
    void OnTriggerEnter(Collider other)
		{
		if (other.gameObject.tag == "Asteroid" || other.gameObject.tag == "bar") 
			{
				an.SetTrigger ("Death");
				Invoke ("GameOver", 0.7f);
	            freeze.enabled = false;
	            AudioSource.PlayClipAtPoint(die, new Vector3(hit.point.x, hit.point.y, player.transform.position.z));
			    player = null;
				circle.gameObject.SetActive (false);
                flame1.gameObject.SetActive(false);
                flame2.gameObject.SetActive(false);
        }
			
		}

	public void GameOver()
	{
		image.gameObject.SetActive (true);

		sp.enabled = false;
        
    }
    //#####################################################################################


}
