using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

class Game : MonoBehaviour
{
    public Text MoneyDisplay;
    public static Game GameInstance;
    public Player Player;
    private ZombieSpawner _zombieSpawner;
    public int _money;

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