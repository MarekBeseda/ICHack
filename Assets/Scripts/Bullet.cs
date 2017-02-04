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
        AbstractDamageTaker target = collision.gameObject.GetComponent<AbstractDamageTaker>();

        if (target != null && target.CompareTag("enemy")) {
			Destroy(this.gameObject);
			collision.gameObject.GetComponent<AbstractDamageTaker> ().TakeDamage (power);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
