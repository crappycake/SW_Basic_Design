using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject FireBall;

    void Start()
    {
        Debug.Log("���̾ ��ȯ");
        Instantiate(FireBall, transform.position, transform.rotation);
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
    }
}
