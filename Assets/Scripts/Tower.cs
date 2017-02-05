using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Tower : AbstractDamageTaker
{
    public Transform TowerHead;
    private int _level;
    private AbstractDamageTaker _target;
    public float radius;
    public Weapon weapon;

    void Start()
    {
        _target = null;
    }

    private void UpdateTarget()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, radius, Vector3.up, 0);
        _target = hits.Select(x => x.collider.GetComponent<AbstractDamageTaker>())
            .Where(x => x != null && x.CompareTag("enemy"))
            .OrderBy(x => (x.transform.position - transform.position).sqrMagnitude)
            .DefaultIfEmpty(null).First();
    }

    void Update()
    {
        if (_target == null)
        {
            UpdateTarget();
        }
        else if ((_target.transform.position - transform.position).sqrMagnitude > radius * radius)
        {
            _target = null;
        }
        if (_target != null)
        {
            Vector3 diff = _target.transform.position - transform.position;
            TowerHead.rotation
                = Quaternion.Euler(90, 0, Mathf.Atan2(diff.z, diff.x) * Mathf.Rad2Deg -90);

            weapon.Fire(_target.transform.position-transform.position + _target.GetComponent<Rigidbody>().velocity * 100000000);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
