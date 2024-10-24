using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CollisionManager : MonoBehaviour
{
    Player_HealthManager healthManager;
    
    void Awake()
    {
        healthManager = GetComponent<Player_HealthManager>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            healthManager.TakeDamage();
        }
        else if (collision.gameObject.CompareTag("Star"))
        {
            GameStageManager.instance.SetStarsForCurrentStage(3);
        }
    }
}
