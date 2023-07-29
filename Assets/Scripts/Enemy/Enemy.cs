using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rb; //Rigidbody of the enemy
    private Vector2 movement; //Vector to keep track of movement of the enemy
    //public float moveSpeed = 5f; //Speed the enemy moves by

    [SerializeField] float moveSpeed;
    [SerializeField] float enemyMaxHealth;
    private float enemyHealth;
    [SerializeField] float enemyDamage;
    [SerializeField] float enemyXPValue;
    private bool notVisible;
    private float killTimer = 5.0f;

   // private GameObject player;
    private GameManager enemy;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        enemy = GameObject.FindGameObjectWithTag("Manage").GetComponent<GameManager>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        enemyHealth = enemyMaxHealth;
        LevelUp();
    }

    private void OnBecameInvisible()
    {
        notVisible = true;
    }

    private void OnBecameVisible()
    {
        notVisible = false;
        killTimer = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(notVisible)
        {
            killTimer -= Time.deltaTime;
        }

        if(killTimer <= 0)
        {
            Destroy(gameObject);
        }

        Vector3 direction = player.position - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        //rb.rotation = angle;
        direction.Normalize();
        movement = direction;
       
    }

    void moveEnemy(Vector2 direction)
    {
        //Moves the enemy
        rb.MovePosition((Vector2)transform.position + (moveSpeed * Time.deltaTime * direction));
    }

    private void FixedUpdate()
    {
        moveEnemy(movement);
    }

    //Called on collision
    public void OnCollisionEnter2D(Collision2D collision)
    {

        //Checks to see what it collided with to see if it should be destroyed
        //if (collision.collider.tag == "Bullet")
        //{
        //    //Destroys the object
        //    enemyHealth -= collision.gameObject.GetComponent<Player>().playerDamage;

        //}

        if (collision.collider.tag == "Player")
        {
            Debug.Log("Collided with player");
            collision.gameObject.GetComponent<Player>().TakeDamage(enemyDamage);
        }

    }

    public void TakeDamage(float damage)
    {
          enemyHealth = enemyHealth - damage;

          CheckAlive();
       

    }

    public void CheckAlive()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            player.GetComponent<Player>().gainExperience(enemyXPValue);
            player.GetComponent<Player>().kills++;
            player.GetComponent<Player>().coins++;

            //int i = Random.Range(0, 5);

            //if (i >= 4)
            //{
            //    Instantiate(enemy.GenerateEnemyDrop(), gameObject.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
            //}
        }
    }

    public void LevelUp()
    {
        enemyMaxHealth *= 1 + (player.GetComponent<Player>().playerLevel / 10) + (enemy.LevelNum / 2);

        enemyDamage *= 1 + (player.GetComponent<Player>().playerLevel / 10) + (enemy.LevelNum / 2);

        enemyXPValue *= 1 + (player.GetComponent<Player>().playerLevel / 10) + (enemy.LevelNum / 2);
    }
}
