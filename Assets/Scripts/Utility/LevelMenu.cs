using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] private GameObject lockedMenu;
    // Start is called before the first frame update
    void Start()
    {
        lockedMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Level1");
    }
    //public void LoadLevel(string level)
    //{

    //    if(PlayerPrefs.GetInt(level) == 1)
    //    {
    //        SceneManager.LoadScene(level);
    //    }
    //    else
    //    {
    //        lockedMenu.SetActive(true);
    //    }
    //}

    public void LoadLevel(int levelNum)
    {
        int prevLevel = levelNum - 1;

        if(PlayerPrefs.GetInt("Level" + prevLevel.ToString()) == 1)
        {
            SceneManager.LoadScene("Level" + levelNum.ToString());
        }
        else
        {
            lockedMenu.SetActive(true);
        }
    }

    public void CloseLockedMenu()
    {
        lockedMenu.SetActive(false);
    }
}
