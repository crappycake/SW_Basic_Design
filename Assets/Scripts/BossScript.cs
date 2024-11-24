using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{
    public int health;

    [SerializeField] Slider bossSlider;

    private void Start()
    {
        bossSlider.maxValue = health;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fireball_parried"))
        {
            OnDamaged(1);
        }
    }

    private void FixedUpdate()
    {
        bossSlider.value = health;

    }
    private void OnDamaged(int damage)
    {
        health -= damage;
    }
}