using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  enum AvatarType{
    PlayerAvatar,
    EnemyAvatar
}
public abstract class BaseAvatar : MonoBehaviour
{
 
    [SerializeField]
    private float maxSpeed;
    public float health;
    public float maxHealth;
    public AvatarType type;

     public float MaxSpeed {
        get 
        {
            return this.maxSpeed;
        }
        private set 
        {
                this.maxSpeed = value;
        }
    }

    public virtual void TakeDamage(float damage)
    {

        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
