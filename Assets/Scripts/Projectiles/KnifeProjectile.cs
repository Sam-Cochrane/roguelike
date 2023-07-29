using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeProjectile : MonoBehaviour
{
    private float attack = 5.0f;
    private Player player;
    private float killTime = 5.0f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Projectile start");

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rb = gameObject.GetComponent<Rigidbody2D>();

        Physics2D.IgnoreLayerCollision(7, 8);
        Physics2D.IgnoreLayerCollision(7, 7);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update Projectile");

        if (player == null)
        {
            Debug.Log("No player");
        }

        //rb.MovePosition((Vector2)transform.position + ((Vector2)transform.forward * projectileSpeed * Time.deltaTime));

        killTime -= Time.deltaTime;
        if (killTime <= 0)
        {
            Debug.Log("Here");
            Destroy(gameObject);
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Enemy" && player != null)
        {
            Debug.Log("Hit");

            float damage = attack + player.playerDamage;

            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);

            Destroy(gameObject);
        }

        if (collision.collider.tag == "Boss")
        {
            if (player != null)
            {
                float damage = attack + player.playerDamage;

                //collision.gameObject.GetComponent<Boss>().TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
