using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Customisation : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject forwardButton;

    [SerializeField] private TMP_Text spriteName;
    [SerializeField] private Sprite[] playerSprites;
    [SerializeField] private Image sprite;


    [SerializeField] private bool[] unlocked;
    [SerializeField] private int[] coinCost;
    [SerializeField] private Sprite[] buttonSprites;
    [SerializeField] private Camera camera;

    private int maxSprite;
    private int currentSprite;
    public void MainMenu()
    {
        camera.transform.position = new Vector3(0, 0, -10);
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
        
    }

    public void BackSprite()
    {
        currentSprite--;
        sprite.sprite = playerSprites[currentSprite];
    }

    public void forwardSprite()
    {
        currentSprite++;
        sprite.sprite = playerSprites[currentSprite];
    }

    public void SelectSprite()
    {
        PlayerPrefs.SetInt("PlayerSprite", currentSprite);
    }
    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.GetInt("PlayerSprite") > playerSprites.Length)
        {
            Debug.Log("Resetting playerSprite");
            PlayerPrefs.SetInt("PlayerSprite", 0);
        }

        maxSprite = playerSprites.Length - 1;
        currentSprite = PlayerPrefs.GetInt("PlayerSprite");
              
    }

    // Update is called once per frame
    void Update()
    {
        sprite.sprite = playerSprites[currentSprite];
        
        spriteName.text = playerSprites[currentSprite].name.ToString();

        if(currentSprite == 0)
        {
            backButton.SetActive(false);
        }

        Debug.Log("Current Sprite " + currentSprite.ToString());
        Debug.Log("Max Sprite " + maxSprite.ToString());

        if (currentSprite == maxSprite)
        {
            Debug.Log("Deactivate butotn");
            forwardButton.SetActive(false);
        }

        if(!backButton.activeInHierarchy && currentSprite != 0)
        {
            backButton.SetActive(true);
        }

        if(!forwardButton.activeInHierarchy && currentSprite != maxSprite)
        {
            forwardButton.SetActive(true);
        }
    }
}
