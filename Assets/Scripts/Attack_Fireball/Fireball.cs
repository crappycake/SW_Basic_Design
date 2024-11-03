using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject fireballPrefab; //파이어볼 프리팹!!
    GameObject fireball; //GetComponent를 위해 스크립트 내에서 한번 더 선언
    public GameObject startDestination;
    public GameObject upDestination;
    public GameObject downDestination;

    void Start()
    {
        fireball = fireballPrefab;
        fireball.GetComponent<FireballShoot>().startPos = startDestination.transform.position;
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
            fireball.GetComponent<FireballShoot>().destinationPos = downDestination.transform.position;
            Instantiate(fireball, transform.position, transform.rotation);
            yield return new WaitForSeconds(3f);
        }
        
    }

}
