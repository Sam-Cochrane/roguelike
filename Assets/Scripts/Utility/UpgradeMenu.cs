using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    private int baseHealthCost = 500;
    private int healthUpgradeCost;
    private int maxHealthLevel = 5;

    private int baseDamageCost = 500;
    private int damgeUpgradeCost;
    private int maxDamageLevel = 5;

    private int baseSpeedCost = 500;
    private int speedUpgradeCost;
    private int maxSpeedLevel = 5;

    private int baseCoinCost = 500;
    private int coinUpgradeCost;
    private int maxCoinLevel = 5;

    private int baseXPCost = 500;
    private int XPUpgradeCost;
    private int maxXPLevel = 5;

    private int baseRegenCost = 1000;
    private int regenUpgradeCost;
    private int maxRegenLevel = 5;

    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text damageText;
    [SerializeField] private TMP_Text speedText;
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private TMP_Text xpText;
    [SerializeField] private TMP_Text regenText;

    [SerializeField] private Camera camera;

    [SerializeField] private GameObject mainMenu;

    public void Update()
    {
        CalculateCosts();

        healthText.text = "Level: " + PlayerPrefs.GetInt("HealthLevel").ToString() + "\n" + "Cost: " + healthUpgradeCost + "\n" + "Effect: Increase Max Health";

        damageText.text = "Level: " + PlayerPrefs.GetInt("DamageLevel").ToString() + "\n" + "Cost: " + damgeUpgradeCost + "\n" + "Effect: Increase Damage";

        speedText.text = "Level: " + PlayerPrefs.GetInt("SpeedLevel").ToString() + "\n" + "Cost: " + speedUpgradeCost + "\n" + "Effect: Increase Move Speed";

        coinText.text = "Level: " + PlayerPrefs.GetInt("CoinLevel").ToString() + "\n" + "Cost: " + coinUpgradeCost + "\n" + "Effect: Increase Coin Gain";

        xpText.text = "Level: " + PlayerPrefs.GetInt("XPLevel").ToString() + "\n" + "Cost: " + XPUpgradeCost + "\n" + "Effect: Increase XP Gain";

        regenText.text = "Level: " + PlayerPrefs.GetInt("RegenLevel").ToString() + "\n" + "Cost: " + regenUpgradeCost + "\n" + "Effect: Gain Health Regen";
    }
    public void MainMenu()
    {
        camera.transform.position = new Vector3(0, 0, -10);
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    void CalculateCosts()
    {
        if (PlayerPrefs.GetInt("HealthLevel") > 0)
        {
            healthUpgradeCost = PlayerPrefs.GetInt("HealthLevel") * baseHealthCost;
        }
        else
        {
            healthUpgradeCost = baseHealthCost;
        }

        if (PlayerPrefs.GetInt("DamageLevel") > 0)
        {
            damgeUpgradeCost = PlayerPrefs.GetInt("DamageLevel") * baseDamageCost;
        }
        else
        {
            damgeUpgradeCost = baseDamageCost;
        }

        if (PlayerPrefs.GetInt("SpeedLevel") > 0)
        {
            speedUpgradeCost = PlayerPrefs.GetInt("SpeedLevel") * baseSpeedCost;
        }
        else
        {
            speedUpgradeCost = baseSpeedCost;
        }

        if (PlayerPrefs.GetInt("CoinLevel") > 0)
        {
            coinUpgradeCost = PlayerPrefs.GetInt("CoinLevel") * baseCoinCost;
        }
        else
        {
            coinUpgradeCost = baseCoinCost;
        }

        if (PlayerPrefs.GetInt("XPLevel") > 0)
        {
            XPUpgradeCost = PlayerPrefs.GetInt("XPLevel") * baseXPCost;
        }
        else
        {
            XPUpgradeCost = baseCoinCost;
        }

        if (PlayerPrefs.GetInt("RegenLevel") > 0)
        {
            regenUpgradeCost = PlayerPrefs.GetInt("RegenLevel") * baseRegenCost;
        }
        else
        {
            regenUpgradeCost = baseRegenCost;
        }
    }

    public void LevelUpHealth()
    {
        //if(PlayerPrefs.GetInt("HealthLevel") > 0)
        //{
        //    healthUpgradeCost = PlayerPrefs.GetInt("HealthLevel") * baseHealthCost;
        //}
        //else
        //{
        //    healthUpgradeCost = baseHealthCost;
        //}

        if (PlayerPrefs.GetInt("Coins") >= healthUpgradeCost && PlayerPrefs.GetInt("HealthLevel") < maxHealthLevel)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - healthUpgradeCost);
            PlayerPrefs.SetInt("HealthLevel", PlayerPrefs.GetInt("HealthLevel") + 1);
            PlayerPrefs.Save();
        }
    }

    public void LevelUpDamage()
    {
        //if (PlayerPrefs.GetInt("DamageLevel") > 0)
        //{
        //    damgeUpgradeCost = PlayerPrefs.GetInt("DamageLevel") * baseDamageCost;
        //}
        //else
        //{
        //    damgeUpgradeCost = baseDamageCost;
        //}

        if (PlayerPrefs.GetInt("Coins") >= damgeUpgradeCost && PlayerPrefs.GetInt("DamageLevel") < maxDamageLevel)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - damgeUpgradeCost);
            PlayerPrefs.SetInt("DamageLevel", PlayerPrefs.GetInt("DamageLevel") + 1);
            PlayerPrefs.Save();
        }
    }

    public void LevelUpSpeed()
    {
        //if (PlayerPrefs.GetInt("SpeedLevel") > 0)
        //{
        //    speedUpgradeCost = PlayerPrefs.GetInt("SpeedLevel") * baseSpeedCost;
        //}
        //else
        //{
        //    speedUpgradeCost = baseSpeedCost;
        //}

        if (PlayerPrefs.GetInt("Coins") >= speedUpgradeCost && PlayerPrefs.GetInt("SpeedLevel") < maxSpeedLevel)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - speedUpgradeCost);
            PlayerPrefs.SetInt("SpeedLevel", PlayerPrefs.GetInt("SpeedLevel") + 1);
            PlayerPrefs.Save();
        }
    }

    public void LevelUpCoin()
    {
        //if (PlayerPrefs.GetInt("CoinLevel") > 0)
        //{
        //    coinUpgradeCost = PlayerPrefs.GetInt("CoinLevel") * baseCoinCost;
        //}
        //else
        //{
        //    coinUpgradeCost = baseCoinCost;
        //}

        if (PlayerPrefs.GetInt("Coins") >= coinUpgradeCost && PlayerPrefs.GetInt("CoinLevel") < maxCoinLevel)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - coinUpgradeCost);
            PlayerPrefs.SetInt("CoinLevel", PlayerPrefs.GetInt("CoinLevel") + 1);
            PlayerPrefs.Save();
        }
    }

    public void LevelUpXP()
    {
        //if (PlayerPrefs.GetInt("XPLevel") > 0)
        //{
        //    XPUpgradeCost = PlayerPrefs.GetInt("XPLevel") * baseXPCost;
        //}
        //else
        //{
        //    XPUpgradeCost = baseCoinCost;
        //}

        if (PlayerPrefs.GetInt("Coins") >= XPUpgradeCost && PlayerPrefs.GetInt("XPLevel") < maxXPLevel)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - XPUpgradeCost);
            PlayerPrefs.SetInt("XPLevel", PlayerPrefs.GetInt("XPLevel") + 1);
            PlayerPrefs.Save();
        }
    }
    public void LevelUpRegen()
    {
        //if (PlayerPrefs.GetInt("RegenLevel") > 0)
        //{
        //    regenUpgradeCost = PlayerPrefs.GetInt("RegenLevel") * baseRegenCost;
        //}
        //else
        //{
        //    regenUpgradeCost = baseRegenCost;
        //}

        if (PlayerPrefs.GetInt("Coins") >= regenUpgradeCost && PlayerPrefs.GetInt("RegenLevel") < maxRegenLevel)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - regenUpgradeCost);
            PlayerPrefs.SetInt("RegenLevel", PlayerPrefs.GetInt("RegenLevel") + 1);
            PlayerPrefs.Save();
        }
    }

}
