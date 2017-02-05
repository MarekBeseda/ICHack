using UnityEngine;
using UnityEngine.AI;

public class Zombie : AbstractDamageTaker
{
    protected NavMeshAgent nma;
    protected Rigidbody body;
    public Transform target;
	public int power;
    public float attackStopTime;
    private Cooldown attackCooldown;


    // Use this for initialization
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
        body = GetComponent<Rigidbody>();
        attackCooldown = new Cooldown(attackStopTime);
    }

    // Update is called once per frame
    void Update()
    {
        attackCooldown.Update(Time.deltaTime);

        if (!attackCooldown.Check())
        {
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

        if (target != null && target.CompareTag("friendly") && attackCooldown.Check())
        {
            Debug.Log("test");
            Attack(target);
        }
    }

	void Attack(AbstractDamageTaker player) {
        attackCooldown.Trigger();
		player.TakeDamage (power);
	}
}
