using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject fireballPrefab; //���̾ ������!!
    GameObject fireball; //GetComponent�� ���� ��ũ��Ʈ ������ �ѹ� �� ����
    public GameObject startDestination;
    public GameObject upDestination;
    public GameObject downDestination;

    void Start()
    {
        fireball = fireballPrefab;
        fireball.GetComponent<FireballShoot>().startPos = startDestination.transform.position;
        StartCoroutine(SummonFireBall());
    }

    IEnumerator SummonFireBall()
    {
        for (int i=0; i<5; i++)
        {
            Debug.Log("���̾ ��ȯ");
            fireball.GetComponent<FireballShoot>().destinationPos = downDestination.transform.position;
            Instantiate(fireball, startDestination.transform.position, startDestination.transform.rotation);
            yield return new WaitForSeconds(3f);
        }
        
    }

}
