using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {
    public GameObject Prefab;
    public int SpawnCount;
    public float MinRadius;
    public float Radius;
	public int _health;

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
			// Random way to get progressively stronger zombies.
			_health = 100 + 30 * _wave;
			Debug.Log (_health);

			Debug.Log ("Sup");

	        SpawnWave();
	    }
	}

    private void SpawnWave()
    {
		Game.GameInstance.WaveDied ();

        for (int i = 0; i < SpawnCount; i++)
        {
            GameObject spawnling = GameObject.Instantiate(Prefab);
			spawnling.GetComponent<AbstractDamageTaker> ().Health = _health;
            Vector2 pos = Random.insideUnitCircle;
            if (pos.magnitude < AllowedRadiusRatio)
            {
                pos.Normalize();
                pos.Scale(new Vector2(AllowedRadiusRatio, AllowedRadiusRatio));
            }
            spawnling.transform.position = new Vector3(pos.x, 0, pos.y) * Radius + transform.position;
        }

//        SpawnCount += _wave * 5;
    }
}
