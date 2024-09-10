using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGun : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private SimpleBullet simpleBullet;
    [SerializeField] private float Damage;
    [SerializeField] private Vector2 Speed;
    [SerializeField] private float Cooldown;
    private float coolDownTimer;
    void Start()
    {
        coolDownTimer = 0;
    }

    // Update is called once per frame
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
            simpleBullet = bullet.GetComponent<SimpleBullet>();
            simpleBullet.Damage = Damage;
            simpleBullet.Speed = Speed;
            Instantiate(bullet, gameObject.transform.position + 0.5f*Speed.x*Vector3.right, Quaternion.identity);


            coolDownTimer = Cooldown;
        }
        
    }
}
