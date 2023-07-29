using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchProjectile : MonoBehaviour
{
    public float attack = 5.0f;
    private Player player;
    private float killTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        Physics2D.IgnoreLayerCollision(7, 8);
        Physics2D.IgnoreLayerCollision(7, 7);
    }

    // Update is called once per frame
    void Update()
    {
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

        }

        if (collision.collider.tag == "Boss")
        {
            if (player != null)
            {
                float damage = attack + player.playerDamage;

                //collision.gameObject.GetComponent<Boss>().TakeDamage(damage);
            }

        }
    }
}
