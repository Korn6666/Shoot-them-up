using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : Bullet
{
    // Start is called before the first frame update

    void Start()
    {
        Init(Damage, Speed);
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }
}
