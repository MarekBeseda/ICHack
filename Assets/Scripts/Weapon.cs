using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	protected int damage;
	public int fireSpeed;
	public GameObject Bullet;

	// Use this for initialization
	void Start () {
		// Create a GameObject 
	}

	// This function moves a bullet.
	void Fire(Vector3 VelocityVector){
		GameObject bullet = Instantiate (Bullet);
		
		bullet.GetComponent<Rigidbody> ().position = transform.position;
		bullet.GetComponent<Rigidbody> ().velocity = VelocityVector * fireSpeed; 
	}
		
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			float XvelocityVector = (Camera.main.ScreenToWorldPoint(Input.mousePosition).x) - (transform.position.x);
			float ZvelocityVector = (Camera.main.ScreenToWorldPoint(Input.mousePosition).z) - (transform.position.z);
			Debug.Log (XvelocityVector + " " + ZvelocityVector);

			Vector3 VelocityVector = new Vector3(XvelocityVector, 0, ZvelocityVector);
			VelocityVector.Normalize ();
			Fire (VelocityVector);
		}
	}
}
