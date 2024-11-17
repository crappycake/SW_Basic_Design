using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.CompareTag("Despawn Position")) return;

        gameObject.SetActive(false);
    }
}
