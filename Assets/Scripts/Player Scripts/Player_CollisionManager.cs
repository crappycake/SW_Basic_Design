using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CollisionManager : MonoBehaviour
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
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Damage"))
        {
            healthManager.TakeDamage();
        }
        else if (collision.gameObject.CompareTag("Star"))
        {
            GameLevelManager.instance.SetStarsForCurrentLevel(3);
        }
        else if (collision.gameObject.CompareTag("Heart"))
        {
            healthManager.RecoverHealth();
        }
    }
}
