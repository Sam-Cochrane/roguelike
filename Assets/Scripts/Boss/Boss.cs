using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public bool isDead;

    private Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;

    [SerializeField] float moveSpeed;
    [SerializeField] float enemyMaxHealth;
    private float enemyHealth;
    [SerializeField] float enemyDamage;
    [SerializeField] float enemyXPValue;
    private GameManager manage;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        manage = GameObject.FindWithTag("Manage").GetComponent<GameManager>();

        LevelUp();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = player.position - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        //rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        moveEnemy(movement);
    }
    void moveEnemy(Vector2 direction)
    {
        //Moves the enemy
        rb.MovePosition((Vector2)transform.position + (moveSpeed * Time.deltaTime * direction));
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

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
            //int i = Random.Range(0, 5);

            //if (i >= 4)
            //{
            //    Instantiate(enemy.GenerateEnemyDrop(), gameObject.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
            //}
        }
    }

    void LevelUp()
    {
        enemyMaxHealth *= enemyMaxHealth * (manage.LevelNum / 2);
    }
}
