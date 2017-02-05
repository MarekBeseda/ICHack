using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public int Damage;
	public int BulletSpeed;
	public GameObject Bullet;
    protected Cooldown cd;
    public float CooldownTime;

	// Use this for initialization
	void Start () {
        cd = new Cooldown(CooldownTime); 
	}

	// This function moves a bullet.
	public void Fire(Vector3 VelocityVector){
        if (cd.Check())
        {
            if (GetComponent<AudioSource>() != null) GetComponent<AudioSource>().Play();

            GameObject bullet = Instantiate(Bullet);
            bullet.GetComponent<Bullet>().Power = Damage;
            bullet.transform.position = transform.position;
            bullet.GetComponent<Rigidbody>().velocity = VelocityVector.normalized * BulletSpeed;
            cd.Trigger();
        }
    }
		
	// Update is called once per frame
	void Update () {
        cd.Update(Time.deltaTime);   
	}
}
