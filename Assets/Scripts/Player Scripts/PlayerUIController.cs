using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] Image[] playerHealthImages;
    [SerializeField] GameObject gameClearPanel;
    [SerializeField] GameObject gameOverPanel;

    PlayerHealthManager playerHealthManager;
    LevelBeatManager levelBeatManager;

    void Awake()
    {
        playerHealthManager = GetComponent<PlayerHealthManager>();
        levelBeatManager = FindObjectOfType<LevelBeatManager>();
        Time.timeScale = 1f;
    }
    void Start()
    {
        //if number of lives != number of UI shown, throw an error
        if (playerHealthManager.maxHealth != playerHealthImages.Length)
        {
            Debug.LogError("Number of health UI icons and max health does not match!");
        }

        playerHealthManager.OnDamageTaken += UpdateHealthUI;
        playerHealthManager.OnGameOver += GameOver;

        levelBeatManager.OnMusicEnded.AddListener(GameClear);
    }

    void UpdateHealthUI()
    {
        int currentHealth = playerHealthManager.currentHealth;
        for (int i = 0; i < playerHealthImages.Length; ++i)
        {
                playerHealthImages[i].enabled = i < currentHealth;
        }
    }

    void GameClear()
    {
        Time.timeScale = 0f;
        gameClearPanel.SetActive(true);
    }

    void GameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }
}
