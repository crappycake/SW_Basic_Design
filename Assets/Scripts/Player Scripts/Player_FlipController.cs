using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Player_FlipController : MonoBehaviour
{
    public GameObject startingPosition;
    public GameObject otherPosition;
    private bool isFliped = false;
    private bool canFlip = true;

    private TrailRenderer trailRenderer;

    [SerializeField] float flipSpeed;

    void Awake()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        transform.position = startingPosition.transform.position;
    }

    void Update()
    {
        CheckAndFlipPlayer();
    }

    void OnFlip()
    {
        if (!canFlip) return;

        isFliped = !isFliped;
        
    }

    void CheckAndFlipPlayer()
    {
        if (isFliped)
        {
            MoveTowardsPosition(startingPosition.transform.position);
        }
        else
        {
            MoveTowardsPosition(otherPosition.transform.position);
        }
    }
    
    void MoveTowardsPosition(Vector3 targetPos)
    {
        trailRenderer.emitting = true;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, flipSpeed * Time.deltaTime);

        //can flip again if flipping has finished
        if (Vector2.Distance(transform.position, targetPos) < 0.01f)
        {
            trailRenderer.emitting = false;
            canFlip = true; 
        }
        else
        {
            canFlip = false; 
        }
    }
}
