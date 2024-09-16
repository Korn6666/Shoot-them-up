using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAvatar : BaseAvatar
{
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        type = AvatarType.EnemyAvatar;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
