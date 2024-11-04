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
    public float invincibilityTime;

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

        StartCoroutine(ToggleInvincibility());
        currentHealth -= 1;
        OnDamageTaken?.Invoke(); //Trigger effects such as camera shaking
        if (currentHealth <= 0) GameOver();
    }

    IEnumerator ToggleInvincibility()
    {
        canTakeDamage = false;
        
        yield return new WaitForSeconds(invincibilityTime);

        canTakeDamage = true;
    }

    public void RecoverHealth()
    {
        if (currentHealth > maxHealth) return;
        currentHealth++;
    }
    
    private void GameOver()
    {
        OnGameOver?.Invoke(); //Trigger game over panel
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
