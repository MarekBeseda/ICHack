using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour {

	// Use this for initialization
	public int bulletRate;
	public int bulletSpeed;

	private Rigidbody bullet;

	void Start () {
		bullet = GetComponent<Rigidbody> ();
	}
	
	// This function moves the bullet
	void Move(Vector3 movement) {
		movement *= bulletSpeed;
		bullet.velocity = movement;
	}


	// Update is called once per frame
	void Update () {
		int XvelocityVector =(Camera.main.ScreenToWorldPoint(Input.mousePosition).x) - (transform.position.x);
		int ZvelocityVector = (Camera.main.ScreenToWorldPoint(Input.mousePosition).z) - (transform.position.z);
		Vector3 VelocityVector = new Vector3(XvelocityVector, 0, ZvelocityVector);

		Move (VelocityVector);
	}
}
