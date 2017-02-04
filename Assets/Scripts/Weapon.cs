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
		
		bullet.transform.position = transform.position;
		bullet.GetComponent<Rigidbody>().velocity = VelocityVector * fireSpeed; 
	}
		
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0)) {
            Vector3 VelocityVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            VelocityVector.y = 0;

            VelocityVector.Normalize();
			Fire (VelocityVector);
		}
	}
}
