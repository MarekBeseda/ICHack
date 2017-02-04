using UnityEngine;
using UnityEngine.AI;

public class Zombie : AbstractDamageTaker
{
    protected NavMeshAgent nma;
    public Transform target;
	public int power;
    public float attackStopTime;
    private float cd;

    // Use this for initialization
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cd > 0)
        {
            cd -= Time.deltaTime;
            nma.Stop();
        }
        else
        {
            nma.Resume();
        }
        if(target == null)
        {
            target = getTarget();
        }
        nma.SetDestination(target.position);
    }


    public Transform getTarget() {
        return Game.GameInstance.Player.transform;
    }

    void OnDestroy()
    {
        Game.GameInstance.ZombieDied();
    }

    void OnCollisionEnter(Collision collision)
    {
        AbstractDamageTaker target = collision.gameObject.GetComponent<AbstractDamageTaker>();
        if (target != null && cd <= 0 && target.CompareTag("friendly"))
        {
            Attack(target);
        }
    }

	void Attack(AbstractDamageTaker player) {
        cd = attackStopTime;
		player.TakeDamage (power);
	}
}
