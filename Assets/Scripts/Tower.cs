using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Tower : AbstractDamageTaker
{
    private int _level;
    private AbstractDamageTaker _target;

    void Start()
    {
        _target = null;
    }

    void OnCollisionStay(Collision collision)
    {
        AbstractDamageTaker target = collision.gameObject.GetComponent<AbstractDamageTaker>();

        if (target != null && target.CompareTag("enemy") && _target == null)
        {
            _target = target;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        var target = collision.gameObject.GetComponent<AbstractDamageTaker>();

        if (target == _target)
        {
            _target = null;
        }
    }

    void Update()
    {
        if (_target != null)
        {
            Debug.Log("Pew pew");
            _target.TakeDamage(1);
        }
    }
}
