using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType {
        PlayerBullet,
        EnemyBullet
}
public abstract class Bullet : MonoBehaviour
{
    public LayerMask layerTarget;
    public float Damage;
    public Vector2 Speed;
    Vector2 Position;
    public BulletType type;

    public virtual void Init(float damage, Vector2 speed)
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
        // // Récupérez le calque du GameObject impliqué dans la collision
        // int layer = collision.gameObject.layer;

        // // Vérifiez si le calque est inclus dans le LayerMask
        // if (((1 << layer) & layerTarget) != 0)
        // {
        //     collision.gameObject.GetComponent<BaseAvatar>().TakeDamage(Damage);
        //     Destroy(gameObject);
        // }

        if (type == BulletType.PlayerBullet && collision.gameObject.GetComponent<BaseAvatar>().type == AvatarType.EnemyAvatar){
            collision.gameObject.GetComponent<BaseAvatar>().TakeDamage(Damage);
            Destroy(gameObject);
        }else if (type == BulletType.EnemyBullet && collision.gameObject.GetComponent<BaseAvatar>().type == AvatarType.PlayerAvatar){
             collision.gameObject.GetComponent<BaseAvatar>().TakeDamage(Damage);
             Destroy(gameObject);
        }
    }
}
