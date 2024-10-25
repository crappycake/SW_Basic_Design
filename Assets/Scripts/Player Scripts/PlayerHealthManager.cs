using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class PlayerHealthManager : MonoBehaviour
{
    public int currentHealth;
    [SerializeField] private int maxHealth;
    public bool canTakeDamage = true;

    public event Action OnDamageTaken;
    //subscribed by: PlayerUIController, PlayerSFXController

    public event Action OnGameOver;
    //subscribed by: PlayerUIController, LevelProgressManager

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage()
    {
        if (!canTakeDamage) return; //this is controlled in the SFXController script.

        currentHealth -= 1;
        OnDamageTaken?.Invoke(); //Trigger effects such as camera shaking
        if (currentHealth <= 0) GameOver();
    }

    private void GameOver()
    {
        OnGameOver?.Invoke(); //Trigger game over panel
        //Add logic for game over here...
    }

    public int GetPlayerMaxHealth()
    {
        return maxHealth;
    }

    public int GetPlayerCurrentHealth()
    {
        return currentHealth;
    }
}
