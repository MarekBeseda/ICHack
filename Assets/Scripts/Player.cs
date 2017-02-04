using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : AbstractDamageTaker {

	public float speed;
	private Rigidbody player;

	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody>();		
	}

	// This function moves the character
	void Move(float moveX,float moveY) {
		Vector2 movement = new Vector2 (moveX, moveY);
		movement *= speed;
		player.velocity = movement;
	}


	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Move (moveHorizontal, moveVertical);
	}
}
