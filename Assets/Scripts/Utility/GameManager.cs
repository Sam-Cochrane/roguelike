using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameStates { Win, Lose, Active };

    public GameObject[] enemyPrefabs;

    public GameStates status;

    [SerializeField] SpawnEnemy[] spawners;

    [SerializeField] GameObject[] attackAbilities;

    public GameObject[] enemyDrops;

    [SerializeField] private GameObject bossPrefab;

    public int LevelNum;

    private Player player;
    public float timeBetweenSpawns = 1.0f;
    public float timeElapsed = 0.0f;
    private float gameStage = 1;
    private Boss boss;

    // Start is called before the first frame update
    void Start()
    {
        if(Time.timeScale == 0.0f)
        {
            Time.timeScale = 1.0f;
        }

        status = GameStates.Active;
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (timeBetweenSpawns <= 0)
        {
            SpawnEnemies();
            timeBetweenSpawns = 1.0f;
        }
        else
        {
            timeBetweenSpawns -= Time.deltaTime;
        }

        CheckGameStage();

        CheckGameState();
    }

    void CheckGameState()
    {
        if(player.isDead && boss != null && boss.isDead)
        {
            status = GameStates.Win;
        }
        else if(player.isDead)
        {
            status = GameStates.Lose;
        }
        else
        {
            status = GameStates.Active;
        }
    }
    void CheckGameStage()
    {
        if(timeElapsed > 900)
        {
            gameStage = 4;
            GameObject spawnBoss = Instantiate(bossPrefab);
            boss = spawnBoss.GetComponent<Boss>();
        }
        else if(timeElapsed >= 600)
        {
            gameStage = 3;
        }
        else if(timeElapsed >= 300)
        {
            gameStage = 2;
        }
    }
    public GameObject GenerateAbility()
    {
         int j = Random.Range(0, attackAbilities.Length);

         return attackAbilities[j];

    }

    public GameObject GenerateAttackAbility()
    {
        int a = Random.Range(0, attackAbilities.Length);

        if (attackAbilities[a])
        {
            return attackAbilities[a];
        }
        else
        {
            return null;
        }
    }

    public GameObject GenerateEnemyDrop()
    {
        int i = Random.Range(0, enemyDrops.Length);

        if (enemyDrops[i])
        {
            return enemyDrops[i];
        }
        else
        {
            Debug.Log("No Object");
            return null;
        }

    }

    public GameObject GenerateEnemy()
    {
        int i = Random.Range(0, enemyPrefabs.Length);

        if (enemyPrefabs[i])
        {
            return enemyPrefabs[i];
        }
        else
        {
            Debug.Log("No Object");
            return null;
        }
    }

    void SpawnEnemies()
    {
        switch (gameStage)
        {
            case (1):

                if (timeBetweenSpawns <= 0)
                {
                    int i = Random.Range(0, spawners.Length);
                    int j = Random.Range(0, enemyPrefabs.Length);

                    spawners[i].Spawn(enemyPrefabs[j]);
                }
                

                break;

            case (2):

                if (timeBetweenSpawns <= 0)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        int j = Random.Range(0, spawners.Length);
                        int k = Random.Range(0, enemyPrefabs.Length);

                        spawners[j].Spawn(enemyPrefabs[k]);
                    }
                }
               

                break;

            case (3):

                if (timeBetweenSpawns <= 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        int j = Random.Range(0, spawners.Length);
                        int k = Random.Range(0, enemyPrefabs.Length);

                        spawners[j].Spawn(enemyPrefabs[k]);
                    }
                }
                

                break;

            case (4):

                if (timeBetweenSpawns <= 0)
                {
                    for (int i = 0; i < spawners.Length; i++)
                    {
                        int j = Random.Range(0, enemyPrefabs.Length);
                        spawners[i].Spawn(enemyPrefabs[j]);
                    }
                    timeBetweenSpawns = 1;
                }
                else
                {
                    timeBetweenSpawns -= Time.deltaTime;
                }

                break;
        }
    }
}
