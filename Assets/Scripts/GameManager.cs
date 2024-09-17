using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using UnityEngine.SceneManagement;

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

    [SerializeField] TextAsset[] levelData;
    public LevelDescription[] levels;
    private Levels currentLevel;

    private int levelIndex;


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



    private void Awake()
    {
        levelIndex = 0;
        // Assurez-vous qu'il n'y a pas déjà une instance du GameManager
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject); // Garder cet objet entre les scènes
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
        currentLevel.Load(levels[levelIndex]);

        Instantiate(player, playerSpawnPosition);
        player.GetComponent<PlayerAvatar>().uIManager = uIManager;
        //InvokeRepeating("EnemyRandomSpawn", 2.0f, 2.0f);


    }

    private void Update()
    {
        currentLevel.Execute();

        if (currentLevel.IsFinished())
        {
            if (levelIndex >= levels.Length)
                SceneManager.LoadScene(0); // Get back to menu
            NextLevel();
        }
    }

    private void NextLevel()
    {
        Debug.Log("next level!");
        levelIndex += 1;
        currentLevel.Unload();
        currentLevel.Load(levels[levelIndex]);
    }

    private void EnemyRandomSpawn(){
        randomfloat = Random.Range(Point1.position.y, Point2.position.y);
        enemySpawn = new Vector3(Point1.position.x, randomfloat, Point1.position.z);
        Instantiate(enemy, enemySpawn, Quaternion.identity);
    }
}
