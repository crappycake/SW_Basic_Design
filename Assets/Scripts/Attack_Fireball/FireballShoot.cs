using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballShoot : MonoBehaviour
{
    public float bpm;
    [SerializeField] private float parryingSpeedMultiplier;

    [HideInInspector] public Vector3 startPos; //출발점 위치
    [HideInInspector] public Vector3 destinationPos; //목적지 위치

    [HideInInspector] public Vector3 betweenPos; //간격
    [HideInInspector] public Vector3 movePos; //움직여야 할 만큼의 거리

    private bool parrying;

    Player_FlipController playerFlipController;
    FireballSFXController fireballSFXController;

    private void Awake()
    {
        playerFlipController = FindObjectOfType<Player_FlipController>(); //패링 키 이벤트
        playerFlipController.OnParryingFunctionCalled += Parry;

        fireballSFXController = GetComponent<FireballSFXController>();
    }

    void Start()
    {
        Debug.Log("파이어볼 슛");
        //startPos = transform.position;
        //destinationPos = playerPos.position;
        
        betweenPos = destinationPos-startPos; //요만큼 이동하는데 60/bpm*4 초가 걸리게 해야한다. 아직 구현 X
        movePos = betweenPos/(60f);

        parrying = false;

        Invoke("DestroyBall", 5);

    }

    void FixedUpdate()
    {
        transform.position += new Vector3(movePos.x, movePos.y, movePos.z);
        if (transform.position == destinationPos)
            Debug.Log("목적지 도달!");
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
            movePos = -(movePos * parryingSpeedMultiplier);
            fireballSFXController.FlipParticleDirectionAfterParry();
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
