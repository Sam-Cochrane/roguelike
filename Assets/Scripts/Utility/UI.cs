using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    private Player player;
    private GameManager manager;

    [SerializeField] TMP_Text playerLevel;
    [SerializeField] TMP_Text kills;
    [SerializeField] TMP_Text coins;
    [SerializeField] TMP_Text timeElapsed;

    [SerializeField] Slider healthBar;

    private float playerLev;

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject levelUpMenu;
    [SerializeField] GameObject startingAbilityMenu;
    [SerializeField] GameObject gameOverMenu;

    [SerializeField] GameObject[] abilityButtons;
    [SerializeField] GameObject[] generatedAbilities;
    [SerializeField] List<Image> abilityIcons;

    [SerializeField] TMP_Text[] abilityNames;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        manager = GameObject.FindGameObjectWithTag("Manage").GetComponent<GameManager>();

        playerLev = player.playerLevel;

        levelUpMenu.SetActive(false);
        pauseMenu.SetActive(false);


        SetMaxHealth(player.MaxHealth);
        SetHealth(player.currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        playerLevel.text = "Level " + player.playerLevel.ToString();
        kills.text = "Kills " + player.kills.ToString();
        coins.text = "Coins " + player.coins.ToString();

        if (playerLev != player.playerLevel)
        {
            LevelUp();
        }

        if(timeElapsed.text != manager.timeElapsed.ToString())
        {
            timeElapsed.text = manager.timeElapsed.ToString();
        }

        if (manager.status == GameManager.GameStates.Lose || manager.status == GameManager.GameStates.Win)
        {
            Time.timeScale = 0.0f;
            gameOverMenu.SetActive(true);           
        }

        SetMaxHealth(player.MaxHealth);
        SetHealth(player.currentHealth);
    }

    void LevelUp()
    {
        Time.timeScale = 0.0f;

        levelUpMenu.SetActive(true);

        for (int i = 0; i < abilityButtons.Length; i++)
        {
            generatedAbilities[i] = manager.GenerateAttackAbility();

            if(generatedAbilities[i].GetComponent<BaseAttack>() != null)
            {
                abilityButtons[i].GetComponent<Image>().sprite = generatedAbilities[i].GetComponent<BaseAttack>().icon;
            }

            bool nameAdded = false;

            for(int j = 0; j < player.offensiveAbilities.Count; j++)
            {
                if(player.offensiveAbilities[j] != null)
                {
                    if (player.offensiveAbilities[j].GetComponent<BaseAttack>().name == generatedAbilities[i].GetComponent<BaseAttack>().name)
                    {
                        float nextLevel = player.offensiveAbilities[j].GetComponent<BaseAttack>().level;

                        nextLevel++;

                        abilityNames[i].text = generatedAbilities[i].name.ToString() + " Lv" + nextLevel.ToString();

                        nameAdded = true;
                    }
                }
            }

            if(nameAdded == false)
            {
                abilityNames[i].text = generatedAbilities[i].name.ToString() + " Lv 1";
            }
            
        }

        playerLev = player.playerLevel;

        player.MaxHealth = player.MaxHealth * 1.2f;
        player.currentHealth = player.currentHealth * 1.2f;

        if (PlayerPrefs.GetInt("HealthLevel") > 0)
        {
            player.MaxHealth = player.MaxHealth * (PlayerPrefs.GetInt("HealthLevel") * 0.2f);
            player.currentHealth = player.currentHealth * (PlayerPrefs.GetInt("HealthLevel") * 0.2f);
        }

        player.playerDamage = player.playerDamage * 1.2f;

        if (PlayerPrefs.GetInt("DamageLevel") > 0)
        {
            player.playerDamage = player.playerDamage * (PlayerPrefs.GetInt("DamageLevel") * 0.2f);
        }

        //player.moveSpeed = player.moveSpeed * 1.2f;

        if (PlayerPrefs.GetInt("SpeedLevel") > 0)
        {
            player.moveSpeed = player.moveSpeed * (PlayerPrefs.GetInt("SpeedLevel") * 0.2f);
        }

       
    }

    public void AddAbility(int button)
    {

        bool alreadyHasAbility = false;
        switch (button)
        {
            case 1:

                if(generatedAbilities[0].GetComponent<BaseAttack>() != null)
                {
                    for(int i = 0; i < player.GetComponent<Player>().offensiveAbilities.Count; i++)
                    {
                        if (player.offensiveAbilities[i] != null)
                        {
                            if (generatedAbilities[0].GetComponent<BaseAttack>().name == player.GetComponent<Player>().offensiveAbilities[i].name)
                            {
                                player.GetComponent<Player>().offensiveAbilities[i].GetComponent<BaseAttack>().level++;
                                alreadyHasAbility = true;
                                break;
                            }
                        }
                       
                    }

                    if (alreadyHasAbility == false)
                    {
                        generatedAbilities[0].GetComponent<BaseAttack>().abilityStart();
                        player.GetComponent<Player>().offensiveAbilities.Add(generatedAbilities[0]);
                    }
                }

                break;

            case 2:

                if (generatedAbilities[1].GetComponent<BaseAttack>() != null)
                {
                    for (int i = 0; i < player.GetComponent<Player>().offensiveAbilities.Count; i++)
                    {
                        if(player.offensiveAbilities[i] != null)
                        {
                            if (generatedAbilities[1].GetComponent<BaseAttack>().name == player.GetComponent<Player>().offensiveAbilities[i].name)
                            {
                                player.GetComponent<Player>().offensiveAbilities[i].GetComponent<BaseAttack>().level++;
                                alreadyHasAbility = true;
                                break;
                            }
                        }

                    }

                    if (alreadyHasAbility == false)
                    {
                        generatedAbilities[0].GetComponent<BaseAttack>().abilityStart();
                        player.GetComponent<Player>().offensiveAbilities.Add(generatedAbilities[1]);
                    }
                }

                break;

            case 3:

                if (generatedAbilities[2].GetComponent<BaseAttack>() != null)
                {
                    for (int i = 0; i < player.GetComponent<Player>().offensiveAbilities.Count; i++)
                    {
                        if(player.offensiveAbilities[i] != null)
                        {
                            if (generatedAbilities[2].GetComponent<BaseAttack>().name == player.GetComponent<Player>().offensiveAbilities[i].name)
                            {
                                player.GetComponent<Player>().offensiveAbilities[i].GetComponent<BaseAttack>().level++;
                                alreadyHasAbility = true;
                                break;
                            }
                        }
                        
                    }

                    if (alreadyHasAbility == false)
                    {
                        generatedAbilities[2].GetComponent<BaseAttack>().abilityStart();
                        player.GetComponent<Player>().offensiveAbilities.Add(generatedAbilities[2]);
                    }
                }

                break;
        }

        if(levelUpMenu.activeInHierarchy)
        {
            levelUpMenu.SetActive(false);

            Time.timeScale = 1.0f;
        }      
    }

    public void Pause()
    {
        if(pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0.0f;
        }      
    }

    public void SetMaxHealth(float Health)
    {
        healthBar.maxValue = Health;
    }

    public void SetHealth(float Health)
    {
        healthBar.value = Health;
    }


}
