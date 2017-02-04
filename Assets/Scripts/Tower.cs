using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Tower : AbstractDamageTaker
{
    private int _level;
    private AbstractDamageTaker _target;
    private Cooldown _cooldown;

    void Start()
    {
        _target = null;
        _cooldown = new Cooldown(0.25f);
    }

    void OnTriggerStay(Collider collider)
    {
        AbstractDamageTaker target = collider.GetComponent<AbstractDamageTaker>();

        if (target != null && target.CompareTag("enemy") && _target == null)
        {
            _target = target;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        var target = collider.GetComponent<AbstractDamageTaker>();

        if (target == _target)
        {
            _target = null;
        }
    }

    void Update()
    {
        if (_target != null && _cooldown.UpdateAndCheck(Time.deltaTime))
        {
            _target.TakeDamage(1);
        }
    }
}
