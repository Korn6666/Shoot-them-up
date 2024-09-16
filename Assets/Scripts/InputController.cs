using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private Vector2 speed;
    void Update()
    {
        speed = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        speed = speed.normalized;


        GetComponent<Engines>().Speed = speed;

        if (Input.GetKey(KeyCode.Space)&&!GetComponent<PlayerAvatar>().waitForFullEnergy)
        {
            GetComponent<PlayerAvatar>().Shooting = true;
            GetComponent<BulletGun>().Fire();
        }else{
            GetComponent<PlayerAvatar>().Shooting = false;
        }
    }
}
