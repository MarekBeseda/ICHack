using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : AbstractDamageTaker {

	private bool recoveringStamina;
	public float stamina;
	public float baseSpeed;
	private Rigidbody player;
    public Image healthDisplay;
	public Image staminaDisplay;
    public Weapon weapon;

	// Use this for initialization
    void Start () {
		player = GetComponent<Rigidbody> ();
	}



	// This function moves the character
	void Move(float moveX,float moveZ,float speed) {
		Vector3 movement = new Vector3 (moveX,0, moveZ);
		movement *= speed;
		player.velocity = movement;
	}


	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		float speed = baseSpeed;

		if (stamina <= 0) {
			recoveringStamina = true;
		}

		if (stamina >= 10 && recoveringStamina) {
			recoveringStamina = false;
		}

		if (Input.GetKey (KeyCode.LeftShift) && !recoveringStamina) {
			speed *= 2;
			stamina -= (2 * Time.deltaTime);
		} else if (stamina < 10) {
			stamina += Time.deltaTime;
		}

		Move (moveHorizontal, moveVertical, speed);
        healthDisplay.transform.localScale = new Vector3((float)Health / 100F, 1, 1);
		staminaDisplay.transform.localScale = new Vector3(stamina / 10F, 1, 1);

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 VelocityVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            VelocityVector.y = 0;

            VelocityVector.Normalize();
            weapon.Fire(VelocityVector);
        }

        Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.rotation = Quaternion.Euler(90, 0, Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg -90);
    }
}
