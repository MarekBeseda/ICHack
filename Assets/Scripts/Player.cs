using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : AbstractDamageTaker {

	public float speed;
	private Rigidbody player;
    public Image healthDisplay;

    // Use this for initialization
    void Start () {
		player = GetComponent<Rigidbody>();
    }

	// This function moves the character
	void Move(float moveX,float moveZ) {
		Vector3 movement = new Vector3 (moveX,0, moveZ);
		movement *= speed;
		player.velocity = movement;
	}


	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Move (moveHorizontal, moveVertical);
        healthDisplay.transform.localScale = new Vector3((float)Health / 100F, 1, 1);
	}
}
