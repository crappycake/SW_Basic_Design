using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float bpm;
    [SerializeField] protected float parryingSpeedMultiplier;
    [SerializeField] protected GameObject DamageArea;
    [HideInInspector] public Vector3 startPos;
    [HideInInspector] public Vector3 destinationPos;

    protected Vector3 movePos;
    protected bool parryEnabled = false;

    protected PlayerFlipController playerFlipController;
    protected FireballSFXController fireballSFXController;

    protected virtual void Awake()
    {
        playerFlipController = FindObjectOfType<PlayerFlipController>();
        playerFlipController.OnParryingFunctionCalled += Parry;

        fireballSFXController = GetComponent<FireballSFXController>();
    }

    protected virtual void Start()
    {
        startPos = transform.position;
        Vector3 betweenPos = destinationPos - startPos;
        movePos = betweenPos / (6000f / bpm);

        Invoke(nameof(DestroyBall), 10);
    }

    protected virtual void FixedUpdate()
    {
        transform.position += movePos;
    }

    protected virtual void Parry()
    {
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            parryEnabled = true;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            parryEnabled = false;
        }
    }

    protected void DestroyBall()
    {
        Destroy(gameObject);
    }
}