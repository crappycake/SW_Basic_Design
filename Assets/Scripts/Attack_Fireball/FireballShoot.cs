using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballShoot : MonoBehaviour
{
    public float bpm;
    [SerializeField] private float parryingSpeedMultiplier;

    [HideInInspector] public Vector3 startPos; //????? ???
    [HideInInspector] public Vector3 destinationPos; //?????? ???

    [HideInInspector] public Vector3 betweenPos; //????
    [HideInInspector] public Vector3 movePos; //???????? ?? ????? ???

    private bool parrying;

    PlayerFlipController playerFlipController;
    FireballSFXController fireballSFXController;

    private void Awake()
    {
        playerFlipController = FindObjectOfType<PlayerFlipController>(); //?��? ? ????
        playerFlipController.OnParryingFunctionCalled += Parry;

        fireballSFXController = GetComponent<FireballSFXController>();
    }

    void Start()
    {
        Debug.Log("????? ??");
        //startPos = transform.position;
        //destinationPos = playerPos.position;
        
        betweenPos = destinationPos-startPos; //?��? ??????? 60/bpm*4 ??? ????? ??????. ???? ???? X
        movePos = betweenPos/(60f);

        parrying = false;

        Invoke("DestroyBall", 5);

    }

    void FixedUpdate()
    {
        transform.position += new Vector3(movePos.x, movePos.y, movePos.z);
    }

   

    void Parry()
    {
        if (!parrying) //?��? ?????? ???? X
        { 
            return;
        }
        else //?��? ?????? ???? O
        {
            movePos = -(movePos * parryingSpeedMultiplier);
            fireballSFXController.CallFunctionsAfterParried();
            parrying = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            parrying = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            parrying = false;
        }
    }

    void DestroyBall()
    {
        Destroy(gameObject);
    }
}
