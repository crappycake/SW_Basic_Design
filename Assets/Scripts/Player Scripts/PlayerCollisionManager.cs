using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisionManager : MonoBehaviour
{
    private PlayerHealthManager healthManager;
    private PlayerFlipController flipController;
    private LevelProgressManager levelProgressManager;
    
    public UnityEvent OnCollideWithSpike;
    public UnityEvent OnCollideWithTrap;
    public UnityEvent OnGetStar;
    
    void Awake()
    {
        healthManager = GetComponent<PlayerHealthManager>();
        flipController = GetComponent<PlayerFlipController>();
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
        if (collision.gameObject.CompareTag("Trap"))
        {
            OnCollideWithTrap.Invoke();
            flipController.TriggerFlipDebuff(1f);
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
