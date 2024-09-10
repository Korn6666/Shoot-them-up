using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public float Damage;
    public Vector2 Speed;
    Vector2 Position;

    protected virtual void Init(float damage, Vector2 speed)
    {
        UpdatePosition();
        Damage = damage;
        Speed = speed;
    }

    protected virtual void UpdatePosition()
    {

        Position = transform.position;
        Position += Speed * Time.deltaTime;
        transform.position = Position;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.TryGetComponent<BaseAvatar>(out BaseAvatar baseAvatar))
            collision.gameObject.GetComponent<BaseAvatar>().TakeDamage(Damage);

        Destroy(gameObject);
    }

}
