using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class Player_HealthManager : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;

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
