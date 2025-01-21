using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fireball : MonoBehaviour
{
    public float bpm;
    [SerializeField] private float parryingSpeedMultiplier;
    [SerializeField] private GameObject DamageArea;
    [HideInInspector] public Vector3 startPos;
    [HideInInspector] public Vector3 destinationPos;

    [HideInInspector] public Vector3 betweenPos;
    [HideInInspector] public Vector3 movePos;

    private bool parryEnabled;

    PlayerFlipController playerFlipController;
    FireballSFXController fireballSFXController;

    private void Awake()
    {
        playerFlipController = FindObjectOfType<PlayerFlipController>();
        playerFlipController.OnParryingFunctionCalled += Parry;

        fireballSFXController = GetComponent<FireballSFXController>();
    }

    void Start()
    {
        startPos = transform.position;
        //destinationPos = playerPos.position;
        
        betweenPos = destinationPos-startPos;
        movePos = betweenPos/(40f);

        parryEnabled = false;

        Invoke("DestroyBall", 10);
    }

    void FixedUpdate()
    {
        transform.position += movePos;
    }

   

    void Parry()
    {
        if (!parryEnabled)
        { 
            return;
        }
        else
        {
            DamageArea.tag = "Fireball_parried";

            if (GameLevelManager.instance.GetCurrentLevel() == "1-4H" || GameLevelManager.instance.GetCurrentLevel() == "1-4HT")
            {
                Vector3 temp = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position);
                movePos = temp.normalized;
            }
            else movePos = -(movePos * parryingSpeedMultiplier);

            Debug.Log("MovePos : " + movePos);
            Debug.Log("TransformPos : " + transform.position);
            Debug.Log("MousePos : " + Camera.main.ScreenToWorldPoint(Input.mousePosition));
            


            Vector3 currentScale = transform.localScale;
            currentScale.x *= -1;
            transform.localScale = currentScale;

            fireballSFXController.CallFunctionsAfterParried();
            parryEnabled = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            parryEnabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            parryEnabled = false;
        }
    }

    void DestroyBall()
    {
        Destroy(gameObject);
    }
}
