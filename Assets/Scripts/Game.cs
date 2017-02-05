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
	public int _wave;

	private int _numZombies;

	private bool isPaused = false;
    void Start()
    {
        GameInstance = this;
    }

	void Update() {
		if(Input.GetKeyDown("escape") && !isPaused)
		{
			print("Paused");
			Time.timeScale = 0.0f;
			isPaused = true;
		}
		else if(Input.GetKeyDown("escape") && isPaused)
		{
			print("Unpaused");
			Time.timeScale = 1.0f;
			isPaused = false;  
		} 
	}

    public void ZombieDied(int value)
    {
        _money += value;
        if(MoneyDisplay != null) {
            MoneyDisplay.text = "Money: " + _money;
        }
		_numZombies--;
        if(ZombieDisplay != null)
        {
            ZombieDisplay.text = "Zombies alive: " + _numZombies;
        }

    }

	public void WaveDied() {
		_wave++;
		WaveDisplay.text = "Wave: " + _wave;
		_numZombies += _zombieSpawner.SpawnCount;
	}

    public void StructureDestroyed()
    {
        
    }
}