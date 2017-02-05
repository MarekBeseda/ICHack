using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ZombieSpawner : MonoBehaviour {
    public GameObject Boss_Prefab;
    public GameObject Fast_Prefab;
    public GameObject Tank_Prefab;
    public GameObject Fighter_Prefab;
    public GameObject Basic_Prefab;
    public GameObject Slow_Prefab;
    public GameObject Stupid_Prefab;
    public GameObject Kamikaze_Prefab;
    public int MaxZombies;
    public int SpawnCount { get { return Math.Min(MaxZombies, (Game.GameInstance.Wave + 1) * (Game.GameInstance.Wave + 1)); } }
    public float MinRadius;
    public float Radius;

    private float AllowedRadiusRatio {
        get { return MinRadius / Radius; }
    }

    private Cooldown _waveCooldown;

	// Use this for initialization
	void Start ()
	{
        _waveCooldown = new Cooldown(40f);
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
            Vector2 pos = Random.insideUnitCircle;
            if (pos.magnitude < AllowedRadiusRatio)
            {
                pos.Normalize();
                pos.Scale(new Vector2(AllowedRadiusRatio, AllowedRadiusRatio));
            }

            new ZombieBuilder(ZombieBuilder.WeightedRandomSpecialization()).Generate(PrefabResolver, new Vector3(pos.x, 0, pos.y) * Radius + Game.GameInstance.Player.transform.position);
        }
    }

    private GameObject PrefabResolver(ZombieSpecialization specialization)
    {
        switch (specialization)
        {
            case ZombieSpecialization.BOSS:
                return Boss_Prefab;
            case ZombieSpecialization.FAST:
                return Fast_Prefab;
            case ZombieSpecialization.TANK:
                return Tank_Prefab;
            case ZombieSpecialization.FIGHTER:
                return Fighter_Prefab;
            case ZombieSpecialization.BASIC:
                return Basic_Prefab;
            case ZombieSpecialization.SLOW:
                return Slow_Prefab;
            case ZombieSpecialization.STUPID:
                return Stupid_Prefab;
            case ZombieSpecialization.KAMIKAZE:
                return Kamikaze_Prefab;
            default:
                throw new ArgumentOutOfRangeException("oops wrong zombie type, you're probably a stupid zombie if you caused this to break :0");
        }
    }
}
