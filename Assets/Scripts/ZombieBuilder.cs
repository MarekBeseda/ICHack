using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

class ZombieBuilder
{
    private ZombieSpecialization _specialization;

    public ZombieBuilder(ZombieSpecialization specialization)
    {
        _specialization = specialization;
    }

    public void Generate(Func<ZombieSpecialization, GameObject> prefabResolver, Vector3 position)
    {
        GameObject spawnling = GameObject.Instantiate(prefabResolver.Invoke(_specialization));
        spawnling.GetComponent<AbstractDamageTaker>().Health *= 1 + (zombieRandom.Next(1, 20) / 10);
        spawnling.GetComponent<AbstractDamageTaker>().Health += (int)(100f * Mathf.Pow(1.01f, Game.GameInstance.Wave));
        spawnling.transform.position = position;

        if (_specialization == ZombieSpecialization.KAMIKAZE) spawnling.GetComponent<Zombie>().Kamikaze = true;
    }

    private static Random zombieRandom = new Random();

    public static ZombieSpecialization WeightedRandomSpecialization()
    {
        int x = zombieRandom.Next(32);

        if (Game.GameInstance.Wave < 7)
        {
            if (x < 1) return ZombieSpecialization.BOSS;
            if (x < 4) return ZombieSpecialization.FAST;
            if (x < 7) return ZombieSpecialization.TANK;
            if (x < 10) return ZombieSpecialization.FIGHTER;
            if (x < 20) return ZombieSpecialization.BASIC;
            if (x < 25) return ZombieSpecialization.SLOW;
            if (x < 30) return ZombieSpecialization.STUPID;
            if (x < 32) return ZombieSpecialization.KAMIKAZE;
        }
        else if (Game.GameInstance.Wave < 14)
        {
            if (x < 2) return ZombieSpecialization.BOSS;
            if (x < 6) return ZombieSpecialization.FAST;
            if (x < 9) return ZombieSpecialization.TANK;
            if (x < 12) return ZombieSpecialization.FIGHTER;
            if (x < 22) return ZombieSpecialization.BASIC;
            if (x < 28) return ZombieSpecialization.SLOW;
            if (x < 30) return ZombieSpecialization.STUPID;
            if (x < 32) return ZombieSpecialization.KAMIKAZE;
        }
        else if (Game.GameInstance.Wave < 20)
        {
            if (x < 3) return ZombieSpecialization.BOSS;
            if (x < 7) return ZombieSpecialization.FAST;
            if (x < 12) return ZombieSpecialization.TANK;
            if (x < 18) return ZombieSpecialization.FIGHTER;
            if (x < 28) return ZombieSpecialization.BASIC;
            if (x < 32) return ZombieSpecialization.KAMIKAZE;
        }
        else
        {
            if (x < 4) return ZombieSpecialization.BOSS;
            if (x < 9) return ZombieSpecialization.FAST;
            if (x < 15) return ZombieSpecialization.TANK;
            if (x < 23) return ZombieSpecialization.FIGHTER;
            if (x < 25) return ZombieSpecialization.BASIC;
            if (x < 32) return ZombieSpecialization.KAMIKAZE;
        }

        throw new OutOfMemoryException("didnt actually run out of memory sorry for the misinformation but zombies broke or something");
    }
}
