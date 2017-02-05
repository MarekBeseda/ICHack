using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class AbstractDamageTaker : MonoBehaviour
{
    public int Health;

    public virtual void TakeDamage(int dmg)
    {
        Health -= dmg;

        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}