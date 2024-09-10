using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engines : MonoBehaviour
{
    private float MaxSpeed;
    public Vector2 Speed;
    public Vector2 Position;
    
    void Start()
    {
        MaxSpeed = GetComponent<BaseAvatar>().MaxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Position = transform.position;
        Position += Speed * MaxSpeed * Time.deltaTime;
        transform.position = Position;
    }
}
