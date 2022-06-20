using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float respawnDelay;
    public PlayerController gamePlayer;
    public int coins;
    public Text coinText;
    public Text WinText;

    // Start is called before the first frame update
    void Start()
    {
        gamePlayer = FindObjectOfType<PlayerController>();
        coinText.text = "Spaghettis collected: " + coins + "/7";
        WinText.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Respawn()
    {
        gamePlayer.gameObject.SetActive(false);
        gamePlayer.transform.position = gamePlayer.respawnPoint;
        gamePlayer.gameObject.SetActive(true);
    }
    public void AddCoins(int numberOfCoins) 
    {
        coins += numberOfCoins;
        gamePlayer = FindObjectOfType<PlayerController>();
        coinText.text = "Spaghettis collected: " + coins + "/7";
        if (coins == 7)
        {
            WinText.text = "You Win! :D";
            Time.timeScale = 0;
        }

    }
}


