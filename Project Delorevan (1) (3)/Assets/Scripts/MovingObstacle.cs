using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour {

	Vector2 startPos;
	public float moveSpeedinUnits = 1;
	public float distToMove = 1.0f;


	enum Direction
	{
		Right = 1,
		Left = -1
	};


	private Direction moveDirection;

	// Use this for initialization
	void Start()
	{
		startPos = transform.position;

	}

	void Update()
	{
		if ((transform.position.x - startPos.x) >= distToMove)
		{
			moveDirection = Direction.Left;

		}
		else if (transform.position.x <= startPos.x)
		{
			moveDirection = Direction.Right;
		}

		transform.Translate((float)moveDirection * moveSpeedinUnits * Time.deltaTime, 0, 0);

	}
		
}
