using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Linq;
using System.Collections.Generic;


public class Shop : MonoBehaviour
{
	public GameObject contentPanel;
    private Buildable selected;
    public Color Valid = Color.green, Invalid = Color.red;
    public int ArmorCost = 25;
    public int ArmorPerBuy = 100;

    public void onItem(string data)
    {
        if(data == "armor" && Game.GameInstance._money >= ArmorCost)
        {
            Game.GameInstance.Player.Armor += ArmorPerBuy;
            Game.GameInstance._money -= ArmorCost;
        }
    }

    public void onBuild(string data)
    {
        Buildable prefab = Resources.Load<GameObject>("Prefabs\\Buildable\\" + data).GetComponent<Buildable>();
        if (prefab.Price <= Game.GameInstance._money)
        {
            selected = Instantiate(prefab);
            contentPanel.SetActive(false);
        }
    }

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (Input.GetKeyDown(KeyCode.Q))
        {
            contentPanel.SetActive(!contentPanel.activeSelf);
        }

        if (Input.GetMouseButtonDown(1))
        {
            contentPanel.SetActive(false);
            if (selected != null)
            {
                Destroy(selected.gameObject);
                selected = null;
            }
        }
        if (selected != null)
        {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float x = Mathf.Floor(mousepos.x + 1.5f);
            float z = Mathf.Floor(mousepos.z + 1.5f);
            selected.transform.position = new Vector3(x - x % 3, 2, z - z % 3);
            
            if (Physics.BoxCast(selected.transform.position - new Vector3(0,10,0), new Vector3(1.4F, 1.4F, 1.4F), Vector3.up)) 
            {
                selected.GetComponent<SpriteRenderer>().color = Invalid;
            }
            else
            {
                selected.GetComponent<SpriteRenderer>().color = Valid;
                if (Input.GetMouseButtonDown(0))
                {
                    Game.GameInstance._money -= selected.Price;
                    GameObject tower = Instantiate(selected.Prefab);
                    tower.transform.position = new Vector3(selected.transform.position.x, 1, selected.transform.position.z);
                    Destroy(selected.gameObject);
                }
            }
        }
	}
}