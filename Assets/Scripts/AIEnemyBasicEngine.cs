using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemyBasicEngine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Engines>().Speed = Vector2.left;

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
