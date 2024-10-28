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
        Debug.Log("���̾ ��");
        nowPos = transform.position;
        destinationPos = playerPos.position;
        
        betweenPos = destinationPos-nowPos; //�丸ŭ �̵��ϴµ� 60/bpm*4 �ʰ� �ɸ���.
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
        if (!parrying) //�и� ������ ���� X
        { 
            Debug.Log("�и�����!");
            return;
        }
        else //�и� ������ ���� O
        {
            Debug.Log("�и���!");
            movePos = -movePos;
            parrying = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("�и�����!");
            parrying = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("�и� �Ұ���!");
            parrying = false;
        }
    }

    void DestroyBall()
    {
        Debug.Log("���̾����");
    }

}
