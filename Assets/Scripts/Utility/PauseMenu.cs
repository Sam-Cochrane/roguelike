using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private List<Image> abilityIcons;
    [SerializeField] private List<TMP_Text> abilityText;

    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        for(int i = 0; i < abilityIcons.Count; i++)
        {
            if(player.offensiveAbilities[i] != null)
            {
                abilityIcons[i].gameObject.SetActive(true);
                abilityText[i].gameObject.SetActive(true);
                abilityIcons[i].sprite = player.offensiveAbilities[i].GetComponent<BaseAttack>().icon;
                abilityText[i].text = player.offensiveAbilities[i].GetComponent<BaseAttack>().name.ToString();
            }

            if(player.offensiveAbilities[i] == null)
            {
                abilityIcons[i].gameObject.SetActive(false);
                abilityText[i].gameObject.SetActive(false);
            }

        }
    }

    public void LevelMenu()
    {
        Time.timeScale = 1.0f;
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + player.coins);
        SceneManager.LoadScene("LevelMenu");
    }

    public void Restart()
    {
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + player.coins);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
