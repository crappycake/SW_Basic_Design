using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerFlipController : MonoBehaviour
{
    public GameObject startingPosition;
    public GameObject otherPosition;
    private bool isFliped = false;
    [HideInInspector] public bool canFlip = true;
    [SerializeField] float flipSpeed;

    public event Action OnFlipFunctionCalled;
    //Subscribed by:
    //1. PlayerSFXController - trigger flip sound   

    public event Action OnParryingFunctionCalled;
    //Subscried by:
    //1. FireballShoot

    void Update()
    {
        CheckAndFlipPlayer();
    }

    void OnFlip()
    {
        if (!canFlip) return;

        isFliped = !isFliped;
        OnFlipFunctionCalled?.Invoke();
    }

    void OnParrying()
    {
        OnParryingFunctionCalled?.Invoke();
    }

    void CheckAndFlipPlayer()
    {
        if (isFliped)
        {
            MoveTowardsPosition(otherPosition.transform.position);
        }
        else
        {
            MoveTowardsPosition(startingPosition.transform.position);
        }
    }
    
    void MoveTowardsPosition(Vector3 targetPos)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, flipSpeed * Time.deltaTime);

        //can flip again if flipping has finished
        if (Vector2.Distance(transform.position, targetPos) < 0.01f)
        {
            canFlip = true; 
        }
        else
        {
            canFlip = false; 
        }
    }
}
