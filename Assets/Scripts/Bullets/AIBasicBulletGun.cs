using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBasicBulletGun : MonoBehaviour
{
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

        coolDownTimer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (coolDownTimer <= 0)
        {
            simpleBullet = bullet.GetComponent<SimpleBullet>();
            simpleBullet.Damage = Damage;
            simpleBullet.Speed = Speed;
            GameObject theBullet = Instantiate(bullet, gameObject.transform.position + 2f * Speed.x * Vector3.right, Quaternion.identity);
            theBullet.transform.localScale = newScale;

            coolDownTimer = Cooldown;
        }

        if (coolDownTimer >= 0)
        {
            coolDownTimer -= Time.deltaTime;
        }
    }
}
