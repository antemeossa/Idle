using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private GameObject enemyToSpawn;

    public Transform spawnPoint;

    public GameObject scene;
    
    public bool enemySpawned;
    public bool enemyDefeated;

    public static EnemySpawner instance;
    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;//Avoid doing anything else
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }


    void Start()
    {
        enemyToSpawn = enemy;
        enemySpawned = false;
        enemyDefeated = false;
        spawnEnemy();
        GameManager.instance.enemy = enemy.GetComponent<Enemy>();
    }

    private void Update()
    {
        if (enemyDefeated)
        {
            spawnEnemy();
        }
    }

    public void spawnEnemy()
    {
        if (!enemySpawned)
        {
            GameObject e = Instantiate(enemyToSpawn, spawnPoint);
            enemy = e;
            enemy.transform.parent = scene.transform;
            enemySpawned = true;
            enemyDefeated = false;
        }
    }
}
