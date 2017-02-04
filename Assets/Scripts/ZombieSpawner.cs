using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {
    public GameObject Prefab;
    public int SpawnCount;
    public float MinRadius;
    public float Radius;
    private float AllowedRadiusRatio {
        get { return MinRadius / Radius; }
    }
	private int _wave;

    private Cooldown _waveCooldown;

	// Use this for initialization
	void Start ()
	{
	    _wave = 0;
        _waveCooldown = new Cooldown(15f);
	}
	
	// Update is called once per frame
	void Update () {
	    if (_waveCooldown.UpdateAndCheck(Time.deltaTime))
	    {
	        SpawnWave();
	    }
	}

    private void SpawnWave()
    {
		Game.GameInstance.WaveDied ();

        for (int i = 0; i < SpawnCount; i++)
        {
            GameObject spawnling = GameObject.Instantiate(Prefab);
            Vector2 pos = Random.insideUnitCircle;
            if (pos.magnitude < AllowedRadiusRatio)
            {
                pos.Normalize();
                pos.Scale(new Vector2(AllowedRadiusRatio, AllowedRadiusRatio));
            }
            spawnling.transform.position = new Vector3(pos.x, 0, pos.y) * Radius + transform.position;
        }

        SpawnCount += _wave * 5;
    }
}
