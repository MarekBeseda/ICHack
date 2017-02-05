using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector]
	public int Power;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 5);

	}

	void OnCollisionEnter(Collision collision)
	{
        AbstractDamageTaker target = collision.gameObject.GetComponent<AbstractDamageTaker>();

        if (collision.gameObject.CompareTag("enemy")) {
			Destroy(this.gameObject);
            if(target != null)
            {
			    collision.gameObject.GetComponent<AbstractDamageTaker> ().TakeDamage (Power);
            }
		}
	}

	// Update is called once per frame
	void Update () {
	}
}
