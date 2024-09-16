using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    [SerializeField]  GameObject bulletPrefab;
    private GameObject bullet;

    public static BulletFactory Instance{
        get;
        private set;
    }

    private void Start(){
        Debug.Assert(BulletFactory.Instance == null);
        BulletFactory.Instance = this;
    }

    public Bullet GetBullet(BulletType type, float Damage, Vector2 Speed, Vector3 Position)
    {
        // switch(type){
        //     case BulletType.PlayerBullet:
        //         bullet = Instantiate(this.bulletPrefab);
        //         bullet.GetComponent<Bullet>().type = BulletType.PlayerBullet;
        //     case BulletType.EnemyBullet:
        //         bullet = Instantiate(this.bulletPrefab);
        //         bullet.GetComponent<Bullet>().type = BulletType.EnemyBulletBullet;
        // }

        bullet = Instantiate(bulletPrefab, Position, Quaternion.identity);
        bullet.GetComponent<Bullet>().type = type;
        bullet.GetComponent<Bullet>().Init(Damage, Speed);
        return bullet.GetComponent<Bullet>();
    }
}
