using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisionManager : MonoBehaviour
{
    private PlayerHealthManager healthManager;
    private LevelProgressManager levelProgressManager;
    
    public UnityEvent OnCollideWithSpike;
    public UnityEvent OnGetStar;
    
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
            OnGetStar.Invoke();
        }
    }
    
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Damage"))
        {
            OnCollideWithSpike.Invoke();
            healthManager.TakeDamage();
        }
        else if (collision.gameObject.CompareTag("Heart"))
        {
            healthManager.RecoverHealth();
        }
    }
}
