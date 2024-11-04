using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMaker : MonoBehaviour
{
    //파이어볼
    public GameObject fireballPrefab; //파이어볼 프리팹!!
    GameObject fireball; //GetComponent를 위해 스크립트 내에서 한번 더 선언
    public GameObject startDestination;
    public GameObject upDestination;
    public GameObject downDestination;

    int[] spike;
    int beat = 0;
    bool flag = false;

    [Header("Circle 1")]
    [SerializeField] private GameObject circle1;
    [SerializeField] private GameObject spawnPosition1;
    [SerializeField] private GameObject startPosition;
    [Header("Circle 2")]
    [SerializeField] private GameObject circle2;
    [SerializeField] private GameObject spawnPosition2;
    [SerializeField] private GameObject otherPosition;

    private AttackArea attackArea;

    private void Start()
    {
        fireball = fireballPrefab;
        fireball.GetComponent<FireballShoot>().startPos = startDestination.transform.position;
    }

    private void Awake()
    {
        attackArea = gameObject.GetComponent<AttackArea>();
        beat = 0;
        Debug.Log(GameLevelManager.instance.GetCurrentLevel());

        spike = BeatMap.instance.GetArray("Test");
        //spike = BeatMap.instance.GetArray(GameLevelManager.instance.GetCurrentLevel());
        //1-1 과 같은 숫자로 시작하거나 "-" 문자가 포함된 경우, enum으로 설정이 불가함. 수정 필요
    }
    public void Beat_Renderer()
    {
        switch (spike[beat])
        {
            case 0:
                Debug.Log("non");
                break;
            case 1:
                Debug.Log("yeh");
                SummonSpike();
                break;
            case 2:
                attackArea.SquareArea(startPosition);
                break;
            case 3:
                attackArea.CircleArea(circle2);
                break;
            case 5:
                shootFireballUp();
                break;
            case 6:
                shootFireballDown();
                break;

        }
        beat++;
    }

    void SummonSpike()
    {
        GameObject spikeClone = ObjectPool.SharedInstance.GetPooledObject();
        spikeClone.SetActive(true);
        var spikeScript = spikeClone.GetComponent<AttachToCircle>();

        if (flag == false)
        {
            spikeClone.transform.position = new Vector3(spawnPosition1.transform.position.x, spawnPosition1.transform.position.y);
            spikeClone.transform.SetParent(circle1.transform, true);
            spikeScript.attachedObject = circle1;
            flag = flag != true;
        }
        else if (flag == true)
        {
            spikeClone.transform.position = new Vector3(spawnPosition1.transform.position.x, spawnPosition2.transform.position.y);
            spikeClone.transform.SetParent(circle2.transform, true);
            spikeScript.attachedObject = circle2;
            flag = flag != true;
        }
    }

    void shootFireballUp()
    {
        Debug.Log("위 파이어볼 소환");
        fireball.GetComponent<FireballShoot>().destinationPos = upDestination.transform.position;
        Instantiate(fireball, startDestination.transform.position, startDestination.transform.rotation);
    }

    void shootFireballDown()
    {
        Debug.Log("아래 파이어볼 소환");
        fireball.GetComponent<FireballShoot>().destinationPos = downDestination.transform.position;
        Instantiate(fireball, startDestination.transform.position, startDestination.transform.rotation);
    }

}
