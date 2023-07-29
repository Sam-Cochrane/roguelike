using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject custom;
    [SerializeField] private GameObject upgrade;
    [SerializeField] private TMP_Text coins;

    [SerializeField] private Sprite[] playerSprites;

    [SerializeField] private Image menuSprite;

    [SerializeField] private GameObject resetMenu;

    [SerializeField] private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        custom.SetActive(false);
        upgrade.SetActive(false);

        Debug.Log("Player sprite is " + PlayerPrefs.GetInt("PlayerSprite").ToString());
    }

    // Update is called once per frame
    void Update()
    {
        coins.text = "Coins: " + PlayerPrefs.GetInt("Coins").ToString();

        menuSprite.sprite = playerSprites[PlayerPrefs.GetInt("PlayerSprite")];
    }

    public void CloseReset()
    {
        if(resetMenu.activeInHierarchy == true)
        {
            resetMenu.SetActive(false);
        }
        else
        {
            resetMenu.SetActive(true);
        }
       
    }
    public void ResetGame()
    {
        PlayerPrefs.SetInt("Coins", 0);

        PlayerPrefs.SetInt("HealthLevel", 0);

        PlayerPrefs.SetInt("DamageLevel", 0);

        PlayerPrefs.SetInt("SpeedLevel", 0);

        PlayerPrefs.SetInt("CoinLevel", 0);

        PlayerPrefs.SetInt("XPLevel", 0);

        PlayerPrefs.SetInt("RegenLevel", 0);
    }
    public void UpgradeMenu()
    {
        camera.transform.position = new Vector3(-6, 0, -10);
        upgrade.SetActive(true);
        gameObject.SetActive(false);
    }

    public void CustomMenu()
    {
        camera.transform.position = new Vector3(6, 0, -10);
        custom.SetActive(true);
        gameObject.SetActive(false);
    }

    public void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void exitPressed()
    {
        Application.Quit();
    }
}
