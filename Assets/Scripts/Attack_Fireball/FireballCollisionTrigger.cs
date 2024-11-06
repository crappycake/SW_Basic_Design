using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCollisionTrigger : MonoBehaviour
{
    private FireballSFXController fireballSFXController;

    void Awake()
    {
        fireballSFXController = GetComponentInParent<FireballSFXController>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            fireballSFXController.TriggerDestorySFX();
        }
    }
}
