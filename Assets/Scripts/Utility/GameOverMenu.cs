using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    private Player player;
    private GameManager manager;

    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private TMP_Text restartText;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manage").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    
    public void LevelSelect()
    {
        if(manager.status == GameManager.GameStates.Win)
        {
            string level = "Level" + manager.LevelNum.ToString();
            PlayerPrefs.SetInt(level, 1);
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + player.coins);
            PlayerPrefs.Save();
        }

        SceneManager.LoadScene("LevelMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Update is called once per frame
    void Update()
    {
        if(manager.status == GameManager.GameStates.Win)
        {
            gameOverText.text = "Level Complete!";
            restartText.text = "Play Again";
        }
        else
        {
            gameOverText.text = "Game Over";
            restartText.text = "Try Again";
        }

        
    }
}
