using UnityEngine;
using System.Collections;

public class Gun : Weapon {

	protected int ammo;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void Shoot(AbstractDamageTaker enemy) {
		if (ammo > 0) {
			enemy.TakeDamage (damage);
			ammo--;
		}
	}
}

