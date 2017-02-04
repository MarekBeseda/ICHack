using UnityEngine;
using UnityEngine.AI;

public class Zombie : AbstractDamageTaker
{
    protected NavMeshAgent nma;
    public Transform target;
	private int power;

    // Use this for initialization
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nma.SetDestination(target.position);
    }

    void OnDestroy()
    {
        Game.GameInstance.ZombieDied();
    }

	void Attack(AbstractDamageTaker player) {
		player.TakeDamage (power);
	}
}
