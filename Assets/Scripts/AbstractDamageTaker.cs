using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class AbstractDamageTaker : MonoBehaviour, ITakeDamage
{
    private int _health;

    public void TakeDamage(int dmg)
    {
        _health -= dmg;

        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}