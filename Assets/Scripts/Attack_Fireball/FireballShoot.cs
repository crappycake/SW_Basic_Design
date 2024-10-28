using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballShoot : MonoBehaviour
{
    public float bpm;

    public Vector3 nowPos;
    private Vector3 destinationPos;
    private Vector3 betweenPos;
    private Vector3 movePos;

    public Transform playerPos;

    private bool parrying;

    Player_FlipController playerFlipController;


    private void Awake()
    {
        playerPos = GameObject.FindWithTag("Player").transform;
        playerFlipController = FindObjectOfType<Player_FlipController>();

        playerFlipController.OnParryingFunctionCalled += Parry;
    }

    void Start()
    {
        Debug.Log("파이어볼 슛");
        nowPos = transform.position;
        destinationPos = playerPos.position;
        
        betweenPos = destinationPos-nowPos; //요만큼 이동하는데 60/bpm*4 초가 걸린다.
        movePos = betweenPos/(60f);

        parrying = false;

        Invoke("DestroyBall", 5);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(movePos.x, movePos.y, movePos.z);
    }

   

    void Parry()
    {
        if (!parrying) //패링 가능한 상태 X
        { 
            Debug.Log("패링못해!");
            return;
        }
        else //패링 가능한 상태 O
        {
            Debug.Log("패링해!");
            movePos = -movePos;
            parrying = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("패링가능!");
            parrying = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("패링 불가능!");
            parrying = false;
        }
    }

    void DestroyBall()
    {
        Debug.Log("파이어볼삭제");
    }

}
