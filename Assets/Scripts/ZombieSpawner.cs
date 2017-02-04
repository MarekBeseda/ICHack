using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour{

    public GameObject Prefab;
    public int SpawnCount;
    public float Radius;
        
	// Use this for initialization
	void Start () {
        for (int i = 0; i < SpawnCount; i++)
        {
            GameObject spawnling = GameObject.Instantiate(Prefab);
            Vector2 pos = Random.insideUnitCircle;
            spawnling.transform.position =  new Vector3(pos.x, 0, pos.y) * Radius + transform.position;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
