using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player")) gameObject.SetActive(false);
        if (!collider.CompareTag("Despawn Position")) return;
        gameObject.SetActive(false);
    }
}
