using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBasicBulletGun : MonoBehaviour
{
    [SerializeField] private LayerMask layerTarget;
    [SerializeField] private GameObject bullet;
    private SimpleBullet simpleBullet;
    [SerializeField] private float Damage;
    [SerializeField] private Vector2 Speed;
    [SerializeField] private float Cooldown;
    private float coolDownTimer;
    Vector3 newScale;
    void Start()
    {
        newScale = bullet.transform.localScale;
        newScale.x *= -1;

        coolDownTimer = 0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        if (coolDownTimer <= 0)
        {
            simpleBullet = bullet.GetComponent<SimpleBullet>();
            simpleBullet.Damage = Damage;
            simpleBullet.Speed = Speed;
            GameObject theBullet = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
            theBullet.transform.localScale = newScale;
            theBullet.GetComponent<SimpleBullet>().type = BulletType.EnemyBullet;
            theBullet.GetComponent<SimpleBullet>().layerTarget = layerTarget;

            coolDownTimer = Cooldown;
        }

        if (coolDownTimer >= 0)
        {
            coolDownTimer -= Time.deltaTime;
        }
    }
}
