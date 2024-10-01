using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class Player_HealthManager : MonoBehaviour
{
    public int currentHealth;
    [SerializeField] private int maxHealth;
    public bool canTakeDamage = true;

    public event Action OnDamageTaken;
    public event Action OnGameOver;
    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        if (!canTakeDamage) return; //this is controlled in the SFXController script.

        currentHealth -= 1;
        OnDamageTaken?.Invoke();
        if (currentHealth <= 0) GameOver();
    }

    private void GameOver()
    {
        OnGameOver?.Invoke();
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
