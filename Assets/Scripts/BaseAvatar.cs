using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAvatar : MonoBehaviour
{
    // Start is called before the first frame update
    public float MaxSpeed;
    public float Health;
    public float MaxHealth;


    public virtual void TakeDamage(float damage)
    {

        Health -= damage;

        if (Health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {

            Destroy(gameObject);
        
    }
}
