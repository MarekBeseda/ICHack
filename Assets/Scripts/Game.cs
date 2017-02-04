using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.WSA;

class Game : MonoBehaviour
{
    public static Game GameInstance = new Game();
    private Player _player;
    private ZombieSpawner _zombieSpawner;
    private int _money;

    /* Todo: Event system? This should be ok for now */
    public void ZombieDied()
    {
        _money += 5;
    }

    public void StructureDestroyed()
    {
        
    }

    public void PlaceStructure(Tile tile)
    {
        
    }
}