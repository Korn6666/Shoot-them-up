using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.UIElements;

public class Levels 
{ 
    List<EnemyDescription> EnemiesToSpawn;
    EnemyDescription[] Enemies;
    float startTime;
    public void Load(LevelDescription levelDescription)
    {
        EnemiesToSpawn = new List<EnemyDescription>();
        EnemiesToSpawn.AddRange(levelDescription.Enemies);

        startTime  = Time.time;
    }

    public void Execute(){
        float timeSinceLevelStart = Time.time - startTime;
    }
}
