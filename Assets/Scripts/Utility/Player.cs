using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Joysticks
    [SerializeField] Joystick moveStick;

    public Sprite[] playerSprites;

    public List<GameObject> offensiveAbilities;

    Vector2 movement;

    private float baseHealth = 100;
    public float MaxHealth;
    public float currentHealth;
    public float XPMultiplier = 1;

    private float coolDown = 1.0f;

    public float playerLevel;

    public int coins = 0;
   
    private float playerXP = 0;
    public float XPUntilNextLevel = 10;

    public float moveSpeed = 10.0f;

    public Rigidbody2D playerBod;
    public AudioSource DamageSound;

    public float playerDamage;
    public float kills;

    private float healTime;

    private float viewRadius = 2.5f;
    private GameObject target;
    [SerializeField] GameObject firePoint;

    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = playerSprites[PlayerPrefs.GetInt("PlayerSprite")];

        if(PlayerPrefs.GetInt("HealthLevel") > 0)
        {
            baseHealth = baseHealth * (PlayerPrefs.GetInt("HealthLevel") * 0.2f);
        }

        currentHealth = baseHealth;
        MaxHealth = baseHealth;

        //offset.z = 90.0f;
        Physics2D.IgnoreLayerCollision(6, 8);

        offensiveAbilities[0].GetComponent<BaseAttack>().abilityStart();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = moveStick.Horizontal;
        movement.y = moveStick.Vertical;

        Debug.Log("X Joystick pos " + movement.x);

        Debug.Log("Y Joystick pos " + movement.y);

        if(movement.x < 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (PlayerPrefs.GetInt("RegenLevel") > 0 && healTime <= 0)
        {
            currentHealth += PlayerPrefs.GetInt("RegenLevel");
            healTime = 1;
        }
        else
        {
            healTime -= Time.deltaTime;
        }
           
        transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, -9, 9), Mathf.Clamp(gameObject.transform.position.y, -9, 7),0);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage; //Used to damage player when hit

        if (currentHealth <= 0)
        {
            //Destroy(gameObject);
            isDead = true;
            //gameObject.SetActive(false);
        }
    }

    public void InAttackRange()
    {
        Collider2D[] view = Physics2D.OverlapCircleAll(transform.position, viewRadius);

        for(int i = 0; i < view.Length; i++)
        {
            GameObject targetSpotted = view[i].gameObject;

            if(targetSpotted.tag == "Enemy")
            {
                target = view[i].gameObject;
            }
        }
        
    }

    private void FixedUpdate()
    {
        playerBod.MovePosition(playerBod.position + movement * moveSpeed * Time.fixedDeltaTime);

        InAttackRange();

        if(target)
        {
            for (int i = 0; i < offensiveAbilities.Count; i++)
            {
                if(offensiveAbilities[i] != null)
                {
                    //offensiveAbilities[i].GetComponent<BaseAttack>().pos = firePoint.transform.position;
                    firePoint.transform.rotation = Quaternion.LookRotation(Vector3.forward, target.transform.position - firePoint.transform.position);
                    offensiveAbilities[i].GetComponent<BaseAttack>().spawn = firePoint.transform;
                    offensiveAbilities[i].GetComponent<BaseAttack>().abilityUpdate();
                }
               
            }
        }

        
    }
    public void gainExperience(float experience)
    {
        playerXP += experience * XPMultiplier;

        if (playerXP >= XPUntilNextLevel)
        {
            playerLevel++;
            playerXP = 0;
            XPUntilNextLevel = XPUntilNextLevel * 1.2f;
            Debug.Log(XPUntilNextLevel);
        }

    }

    public void GainCoins(int coinValue)
    {
        coins += coinValue;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.0f, 1.0f, 0.0f, 0.2f);
        Gizmos.DrawSphere(transform.position, viewRadius);

        if(target != null)
        {
            Gizmos.DrawLine(firePoint.transform.position, target.transform.position);
        }      
    }
}
