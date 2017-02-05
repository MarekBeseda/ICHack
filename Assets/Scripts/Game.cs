using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

class Game : MonoBehaviour
{
    public Text MoneyDisplay;
    public Text WaveDisplay;
    public Text ZombieDisplay;
    public static Game GameInstance;
    public Player Player;
    public ZombieSpawner _zombieSpawner;

    public int _money;
    public int _zombieCount;
    public int _wave;

    public int Money
    {
        get { return _money; }
        set
        {
            _money = value;
            if (MoneyDisplay != null)
            {
                MoneyDisplay.text = "Money: " + value;
            }
        }
    }

    public int Wave
    {
        get { return _wave; }
        set
        {
            _wave = value;
            if (WaveDisplay != null)
            {
                WaveDisplay.text = "Wave: " + value;
            }
        }
    }

    public int ZombieCount
    {
        get { return _zombieCount; }
        set
        {
            _zombieCount = value;
            if (ZombieDisplay != null)
            {
                ZombieDisplay.text = "Zombies alive: " + value;
            }
        }
    }

    private bool isPaused = false;

    void Start()
    {
        Money = 0;
        GameInstance = this;
        GetComponent<WorldGenerator>().GenerateTerrain(Terrain.activeTerrain.terrainData);
    }

    void Update()
    {
        if (Input.GetKeyDown("escape") && !isPaused)
        {
            print("Paused");
            Time.timeScale = 0.0f;
            isPaused = true;
        }
        else if (Input.GetKeyDown("escape") && isPaused)
        {
            print("Unpaused");
            Time.timeScale = 1.0f;
            isPaused = false;
        }
    }

    public void ZombieDied(int value)
    {
        Money += value;
        ZombieCount--;
    }

    public void WaveDied()
    {
        Wave++;
        ZombieCount += _zombieSpawner.SpawnCount;
    }

    public void StructureDestroyed()
    {
    }

    public Vector3 GetRandomZombieViablePosition()
    {
        Vector2 pos2 = Random.insideUnitCircle;
        pos2.Normalize();
        var coefficient = (Game.GameInstance._zombieSpawner.MinRadius
                 + Random.value * (Game.GameInstance._zombieSpawner.Radius - Game.GameInstance._zombieSpawner.MinRadius));

        pos2 *= coefficient;
        Vector3 pos3 = new Vector3(pos2.x, 1, pos2.y);
        pos3 += Game.GameInstance.Player.transform.position;
        
        return pos3;
    }
}