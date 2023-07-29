using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float enemyMaxHealth;
    private float enemyHealth;
    [SerializeField] float enemyDamage;
    [SerializeField] float enemyXPValue;
    private float timeBetweenAttacks = 1.0f;
    private float damageCooldown = 0.5f;
    [SerializeField] int coinValue;

    private GameObject player;
    private GameManager enemy;

    // Start is called before the first frame update
    void Start()
    {

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player");
        }

        enemy = GameObject.FindGameObjectWithTag("Manage").GetComponent<GameManager>();

        enemyHealth = enemyMaxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {

        //Checks to see what it collided with to see if it should be destroyed
        if (collision.collider.tag == "Attack")
        {

            //Damages the enemy's health
           

            //Check if dead and if so adds experience points to the player

        }

        if (collision.collider.tag == "Player")
        {
            Debug.Log("Collided with player");
            collision.gameObject.GetComponent<Player>().TakeDamage(enemyDamage);
        }


    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Player" && timeBetweenAttacks <= 0.0f)
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(enemyDamage);
            timeBetweenAttacks = 1.0f;
        }
        else if (collision.collider.tag == "Player")
        {
            timeBetweenAttacks -= Time.deltaTime;
        }
    }

    public void TakeDamage(float damage)
    {

        if (damageCooldown <= 0)
        {
            enemyHealth = enemyHealth - damage;
            damageCooldown = 0.5f;
        }

    }

    public void CheckAlive()
    {
        if (enemyHealth <= 0)
        {           
            Destroy(gameObject);
            player.GetComponent<Player>().gainExperience(enemyXPValue);
            player.GetComponent<Player>().kills++;
            int i = Random.Range(0, 5);

            if (i >= 4)
            {
                Instantiate(enemy.GenerateEnemyDrop(), gameObject.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
            }
        }
    }

    public void LevelUp()
    {
        enemyMaxHealth *= 1 + player.GetComponent<Player>().playerLevel / 10;

        enemyDamage *= player.GetComponent<Player>().playerLevel / 10;

        enemyXPValue *= player.GetComponent<Player>().playerLevel / 10;
    }

}
