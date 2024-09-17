using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGun : MonoBehaviour
{
    [SerializeField] private LayerMask layerTarget;
    [SerializeField] private GameObject bullet;
    private Bullet bulletOnFire;
    private SimpleBullet simpleBullet;
    [SerializeField] private float Damage;
    [SerializeField] private Vector2 Speed;
    [SerializeField] private float Cooldown;
    private float coolDownTimer;
    private PlayerAvatar playerAvatar;
    [SerializeField] Transform bulletSpawnPosition;

    void Start()
    {
        coolDownTimer = 0;
        simpleBullet = bullet.GetComponent<SimpleBullet>();
        simpleBullet.Damage = Damage;
        simpleBullet.Speed = Speed;
        playerAvatar = GetComponent<PlayerAvatar>();
    }

    void Update()
    {
        if (coolDownTimer >= 0)
        {
            coolDownTimer -= Time.deltaTime;
        }
        
    }
    public void Fire()
    {

        if (coolDownTimer <= 0)
        {
            // bulletOnFire = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
            // bulletOnFire.GetComponent<SimpleBullet>().Init(Damage,Speed);
            // bulletOnFire.GetComponent<SimpleBullet>().type = BulletType.PlayerBullet;
            bulletOnFire = BulletFactory.Instance.GetBullet(BulletType.PlayerBullet, Damage, Speed, bulletSpawnPosition.position);

            //bulletOnFire.GetComponent<SimpleBullet>().layerTarget = layerTarget;

            coolDownTimer = Cooldown;
            playerAvatar.TakeEnergy(-playerAvatar.drainShoot);
        }
    }

}
