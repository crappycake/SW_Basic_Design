using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] Image[] playerHealthImages;
    [SerializeField] GameObject gameOverPanel;
    PlayerHealthManager playerHealthManager;

    void Awake()
    {
        playerHealthManager = GetComponent<PlayerHealthManager>();
        Time.timeScale = 1f;
    }
    void Start()
    {
        //if number of lives != number of UI shown, throw an error
        if (playerHealthManager.GetPlayerMaxHealth() != playerHealthImages.Length)
        {
            Debug.LogError("Number of health UI icons and max health does not match!");
        }
        playerHealthManager.OnDamageTaken += UpdateHealthUI;
        playerHealthManager.OnGameOver += TriggerGameOver;
    }

    void UpdateHealthUI()
    {
        int currentHealth = playerHealthManager.GetPlayerCurrentHealth();
        for (int i = 0; i < playerHealthImages.Length; ++i)
        {
            playerHealthImages[i].enabled = i < currentHealth;
        }
    }

    void TriggerGameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }
}
