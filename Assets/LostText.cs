using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LostText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    GetComponent<Text>().text = "You probably sucked.\n\nYou killed: " + Game.ZombiesKilled + " zombies\nYou earned: " +
	                                Game.MoneyEarned + " money\nYou beat: " + Game.WaveNumber + " waves!";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
