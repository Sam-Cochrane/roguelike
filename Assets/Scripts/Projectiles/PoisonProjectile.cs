using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonProjectile : MonoBehaviour
{
    public float attack = 5.0f;
    private Player player;
    public float killTime = 1.0f;
    private int collisionCounter;
    private bool KillTimer;
    [SerializeField] private Sprite poison;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        Physics2D.IgnoreLayerCollision(7, 8);
        Physics2D.IgnoreLayerCollision(7, 7);

        collisionCounter = 0;
        KillTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(KillTimer)
        {
            killTime -= Time.deltaTime;
        }

        if (killTime <= 0)
        {
            Debug.Log("Here");
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collisionCounter < 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = poison;
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            gameObject.transform.position.Set(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            collisionCounter++;
            KillTimer = true;
        }
        else
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
}
