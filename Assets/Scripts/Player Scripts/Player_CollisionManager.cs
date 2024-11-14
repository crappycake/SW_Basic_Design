using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    PlayerHealthManager healthManager;
    
    void Awake()
    {
        healthManager = GetComponent<PlayerHealthManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fireball"))
        {
            healthManager.TakeDamage();
        }
        else if (collision.gameObject.CompareTag("Star"))
        {
            int currentStar = GameLevelManager.instance.GetCurrentLevelStars();
            GameLevelManager.instance.SetStarsForCurrentLevel(currentStar + 1);
        }
    }
    
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Damage"))
        {
            healthManager.TakeDamage();
        }
        else if (collision.gameObject.CompareTag("Heart"))
        {
            healthManager.RecoverHealth();
        }
    }
}
