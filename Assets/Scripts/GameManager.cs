using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

public class GameManager : MonoBehaviour
{
    public  static GameManager instance;
    [SerializeField] GameObject player;
    [SerializeField] Transform playerSpawnPosition;
    [SerializeField] GameObject enemy;
    [SerializeField] Transform Point1;
    [SerializeField] Transform Point2;
    private Vector3 enemySpawn;
    float randomfloat;


    [SerializeField] UIManager uIManager;

 

    private GameManager() {
        // initialize your game manager here. Do not reference to GameObjects here (i.e. GameObject.Find etc.)
        // because the game manager will be created before the objects
    }    

    public static GameManager Instance {
        get {
            if(instance==null) {
                instance = new GameManager();
            }

            return instance;
        }
    }


    [SerializeField] TextAsset[] levelData;
    public LevelDescription[] levels;
    private Levels currentLevel;
    private void Awake()
    {
        // Assurez-vous qu'il n'y a pas déjà une instance du GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Garder cet objet entre les scènes
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Détruire les instances supplémentaires
        }

        // LevelDescription levels = new[] LevelDescription();
        // level1 = XmlHelpers.DeserializeFromXML<LevelDescription>(Level1);

        levels = new LevelDescription[levelData.Length];
        for (int index=0; index < levelData.Length; index++)
        {
            levels[index] = XmlHelpers.DeserializeFromXML<LevelDescription>(levelData[index]);
        }
 
        currentLevel = new Levels();
        currentLevel.Load(levels[0]);
        
        Instantiate(player, playerSpawnPosition);
        player.GetComponent<PlayerAvatar>().uIManager = uIManager;
        InvokeRepeating("EnemyRandomSpawn", 2.0f, 2.0f);


    }

    private void Update(){
        currentLevel.Execute();
    }

    private void EnemyRandomSpawn(){
        randomfloat = Random.Range(Point1.position.y, Point2.position.y);
        enemySpawn = new Vector3(Point1.position.x, randomfloat, Point1.position.z);
        Instantiate(enemy, enemySpawn, Quaternion.identity);
    }
}
