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

        if (Input.GetKeyDown(KeyCode.Space))
        {

            GetComponent<BulletGun>().Fire();
        }
    }
}
