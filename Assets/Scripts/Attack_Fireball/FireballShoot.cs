using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballShoot : MonoBehaviour
{
    public float bpm;


    public Vector3 NowPos;
    private Vector3 DestinationPos;
    private Vector3 BetweenPos;
    private Vector3 MovePos;

    public Transform PlayerPos;


    private bool Parring;

    private void Awake()
    {
        PlayerPos = GameObject.FindWithTag("Player").transform;
    }

    void Start()
    {
        Debug.Log(transform.position);
        Debug.Log("파이어볼슈우우웃");
        NowPos = transform.position;
        DestinationPos = PlayerPos.position;
        
        BetweenPos = DestinationPos-NowPos; //요만큼 이동하는데 60/bpm*4 초가 걸린다.
        MovePos = BetweenPos/(60f);

        Parring = false;

        Invoke("DestroyBall", 5);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(NowPos, DestinationPos, 0);
        Debug.Log("now pos: " + NowPos + ", destination: " + DestinationPos);
        //transform.position += new Vector3(MovePos.x, MovePos.y, MovePos.z);
    }

   

    void OnFlip()
    {
        if (!Parring) //패링 키 X
            return;
        else //패링 키O
        {
            MovePos = -MovePos;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("패링가능!");
        Parring = true;
    }

    void DestroyBall()
    {
        Debug.Log("파이어볼삭제에에");
        Destroy(gameObject);
    }

}
