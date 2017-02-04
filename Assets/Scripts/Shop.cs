using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Item {
	public string name;
	public Sprite icon;
	public int price;
}

public class Shop : MonoBehaviour
{

	public List<Item> items;
	public Transform contentPanel;

	public void sell(Item item, Player player) {
		Game.GameInstance._money -= item.price;
		UpdateDisplay ();
	}

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		UpdateDisplay ();
	}

	private void UpdateDisplay() {
		/*
			1. Check if player has X money for an item I.
			2. Display item on the shop panel.
			3. Remove any items above the player's budget.
		*/
	}
}

