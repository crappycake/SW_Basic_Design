using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    [SerializeField] bool isBreakable;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (isBreakable) {
            if (collider.CompareTag("Player")) gameObject.SetActive(false);
        }
        if (!collider.CompareTag("Despawn Position")) return;
        gameObject.SetActive(false);
    }
}
