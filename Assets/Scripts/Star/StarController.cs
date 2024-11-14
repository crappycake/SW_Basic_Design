using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Despawn Position") || collider.CompareTag("Player")) 
        {
            Destroy(gameObject);
        }
    }
}
