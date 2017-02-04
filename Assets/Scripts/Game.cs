using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

class Game : MonoBehaviour
{
    public Text MoneyDisplay;
    public static Game GameInstance;
    private Player _player;
    private ZombieSpawner _zombieSpawner;
    private int _money;

    void Start()
    {
        GameInstance = this;
    }

    /* TODO: Event system? This should be ok for now */
    public void ZombieDied()
    {
        _money += 5;
        MoneyDisplay.text = "Money: " + _money;
    }

    public void StructureDestroyed()
    {
        
    }
}