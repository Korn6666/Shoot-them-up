using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.UIElements;

public class Levels 
{
    private LevelDescription description;
    List<EnemyDescription> EnemiesToSpawn;
    EnemyDescription[] Enemies;
    private float startTime;
    private float timeSinceLevelStart;
    public void Load(LevelDescription levelDescription)
    {
        EnemiesToSpawn = new List<EnemyDescription>();
        EnemiesToSpawn.AddRange(levelDescription.Enemies);

        startTime  = Time.time;
        description = levelDescription;
    }

    public void Unload()
    {
        EnemiesToSpawn = null;
        description = null;
    }

    public void Execute(){
        timeSinceLevelStart = Time.time - startTime;

        for (int i=0; i < EnemiesToSpawn.Count; i++)
        {
            if (EnemiesToSpawn[i].SpawnDate <= timeSinceLevelStart)
            {
                GameObject.Instantiate(Resources.Load(EnemiesToSpawn[i].PrefabPath), EnemiesToSpawn[i].SpawnPosition, Quaternion.identity);
                EnemiesToSpawn.RemoveAt(i);
            }
        }
    }

    public bool IsFinished()
    {
        timeSinceLevelStart = Time.time - this.startTime;
        if (timeSinceLevelStart >= this.description.Duration)
        {
            return true;
        }

        return false;
    }
}
