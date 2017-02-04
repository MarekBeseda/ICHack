using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public int power;
	// Use this for initialization
	void Start () {
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.GetComponent<AbstractDamageTaker>().CompareTag("enemy")) {
			Destroy(this.gameObject);
			collision.gameObject.GetComponent<AbstractDamageTaker> ().TakeDamage (power);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
