using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	protected int damage;
	public int fireSpeed;
	public GameObject Bullet;
    protected Cooldown cd;
    public float firerate;


	// Use this for initialization
	void Start () {
        cd = new Cooldown(firerate); 
	}

	// This function moves a bullet.
	public void Fire(Vector3 VelocityVector){
        if (cd.Check())
        {
            GameObject bullet = Instantiate(Bullet);
            bullet.transform.position = transform.position;
            bullet.GetComponent<Rigidbody>().velocity = VelocityVector.normalized * fireSpeed;
            cd.Trigger();
        }
    }
		
	// Update is called once per frame
	void Update () {
        cd.Update(Time.deltaTime);
        
	}
}
