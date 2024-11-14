using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CollisionManager : MonoBehaviour
{
    private PlayerHealthManager healthManager;
    private LevelProgressManager levelProgressManager;
    
    void Awake()
    {
        healthManager = GetComponent<PlayerHealthManager>();
        levelProgressManager = FindObjectOfType<LevelProgressManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fireball"))
        {
            healthManager.TakeDamage();
        }

        if (collision.gameObject.CompareTag("Star"))
        {
            levelProgressManager.AddStars();
            Debug.Log("STAR!");
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
