using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject FireBall;

    void Start()
    {
        StartCoroutine(SummonFireBall());
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {

    }

    IEnumerator SummonFireBall()
    {
        for (int i=0; i<5; i++)
        {
            Debug.Log("파이어볼 소환");
            Instantiate(FireBall, transform.position, transform.rotation);
            yield return new WaitForSeconds(3f);
        }
        
    }

}
