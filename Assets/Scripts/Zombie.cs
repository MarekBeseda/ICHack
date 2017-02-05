using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Zombie : AbstractDamageTaker
{
    protected NavMeshAgent nma;
    protected Rigidbody body;
    public Transform target;
    public int reward;
    public int power;
    public float attackStopTime;
    public bool Kamikaze;
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

        if (Kamikaze && target != null && (target.transform.position - transform.position).sqrMagnitude < 8)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector2 pos = Random.insideUnitCircle;
                if (pos.magnitude < Game.GameInstance._zombieSpawner.AllowedRadiusRatio)
                {
                    pos.Normalize();
                    pos.Scale(new Vector2(Game.GameInstance._zombieSpawner.AllowedRadiusRatio,
                        Game.GameInstance._zombieSpawner.AllowedRadiusRatio));
                }

                new ZombieBuilder(ZombieSpecialization.KAMIKAZE).Generate(
                    Game.GameInstance._zombieSpawner.PrefabResolver,
                    new Vector3(pos.x, 0, pos.y) * Game.GameInstance._zombieSpawner.Radius +
                    Game.GameInstance.Player.transform.position);
            }

            Destroy(target.gameObject);
            Destroy(this.gameObject);
        }

        if (!attackCooldown.Check())
        {
            nma.Stop();
        }
        else
        {
            nma.Resume();
        }

        if (target == null)
        {
            target = getTarget();
        }

        if (target != null) nma.SetDestination(target.position);
    }


    public Transform getTarget()
    {
        if (Game.GameInstance.Player == null) return null;

        if (Kamikaze)
        {
            RaycastHit hit;
            Physics.Raycast(new Ray(this.transform.position, Game.GameInstance.Player.transform.position - this.transform.position), out hit, Mathf.Infinity, LayerMask.GetMask("Friendly"));

            if (hit.transform.gameObject.GetComponent<Wall>() != null
                || hit.transform.gameObject.GetComponent<Tower>() != null) this.nma.speed *= 5;

            return hit.transform;
        }
        else
        {
            return Game.GameInstance.Player.transform;
        }
    }

    void OnDestroy()
    {
        Game.GameInstance.ZombieDied(reward);
    }

    void OnCollisionStay(Collision collision)
    {
        AbstractDamageTaker target = collision.gameObject.GetComponent<AbstractDamageTaker>();
        if (target != null && target.CompareTag("friendly") && attackCooldown.Check())
        {
            Debug.Log("test");
            Attack(target);
        }
    }

    void Attack(AbstractDamageTaker player)
    {
        attackCooldown.Trigger();
        player.TakeDamage(power);
    }
}