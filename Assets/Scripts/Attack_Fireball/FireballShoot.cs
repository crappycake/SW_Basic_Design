using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballShoot : MonoBehaviour
{
    public float bpm;
    [SerializeField] private float parryingSpeedMultiplier;

    [HideInInspector] public Vector3 startPos; //����� ��ġ
    [HideInInspector] public Vector3 destinationPos; //������ ��ġ

    [HideInInspector] public Vector3 betweenPos; //����
    [HideInInspector] public Vector3 movePos; //�������� �� ��ŭ�� �Ÿ�

    private bool parrying;

    Player_FlipController playerFlipController;
    FireballSFXController fireballSFXController;

    private void Awake()
    {
        playerFlipController = FindObjectOfType<Player_FlipController>(); //�и� Ű �̺�Ʈ
        playerFlipController.OnParryingFunctionCalled += Parry;

        fireballSFXController = GetComponent<FireballSFXController>();
    }

    void Start()
    {
        Debug.Log("���̾ ��");
        //startPos = transform.position;
        //destinationPos = playerPos.position;
        
        betweenPos = destinationPos-startPos; //�丸ŭ �̵��ϴµ� 60/bpm*4 �ʰ� �ɸ��� �ؾ��Ѵ�. ���� ���� X
        movePos = betweenPos/(60f);

        parrying = false;

        Invoke("DestroyBall", 5);

    }

    void FixedUpdate()
    {
        transform.position += new Vector3(movePos.x, movePos.y, movePos.z);
        if (transform.position == destinationPos)
            Debug.Log("������ ����!");
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
            movePos = -(movePos * parryingSpeedMultiplier);
            fireballSFXController.CallFunctionsAfterParried();
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
