using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    private PlayerHealthManager healthManager;
    private LevelProgressManager levelProgressManager;
    
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
            levelProgressManager.AddStars();
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
