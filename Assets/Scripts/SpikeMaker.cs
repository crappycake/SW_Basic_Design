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
    bool sameDirection = false; //정방향인지 역방향인지

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

        attackArea = GetComponent<AttackArea>();
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
            case 1: SummonSpike("UP");              break;
            case 2: SummonSpike("DOWN");            break;
            case 3: SummonJumpPad("UP");            break;
            case 4: SummonJumpPad("DOWN");          break;
            case 5: ShootFireBall("UP");            break;
            case 6: ShootFireBall("DOWN");          break;
            case 7: SummonAttackArea("UP");         break;
            case 8: SummonAttackArea("DOWN");       break;
            case 9: TriggerPlatformAttack("UP");    break;
            case 10:TriggerPlatformAttack("DOWN");  break;
            default:                                break;
        }

        beat++;
    }

    #region SUMMON SPIKE FUNCTIONS
    void SummonSpike(string direction)
    {
        if (direction == "UP")
        {
            if (sameDirection == true)
            {
                SummonSpikeUp();
            }
            else
            {
                SummonSpikeDown();
                sameDirection = !sameDirection;
            }
        }
        else if (direction == "DOWN")
        {
            if (sameDirection == true)
            {
                SummonSpikeDown();
            }
            else
            {
                SummonSpikeUp();
                sameDirection = !sameDirection;
            }
        }
    }

    void SummonSpikeUp()
    {
        GameObject spikeClone = ObjectPool.SharedInstance.GetPooledObject();
        spikeClone.SetActive(true);
        var spikeScript = spikeClone.GetComponent<AttachToCircle>();

        //위 스파이크 소환
        spikeClone.transform.position = new Vector3(spawnPosition1.transform.position.x, spawnPosition2.transform.position.y);
        spikeClone.transform.SetParent(circle2.transform, true);
        spikeScript.attachedObject = circle2;
    }

    void SummonSpikeDown()
    {
        GameObject spikeClone = ObjectPool.SharedInstance.GetPooledObject();
        spikeClone.SetActive(true);
        var spikeScript = spikeClone.GetComponent<AttachToCircle>();


        //아래 스파이크 소환
        spikeClone.transform.position = new Vector3(spawnPosition1.transform.position.x, spawnPosition1.transform.position.y);
        spikeClone.transform.SetParent(circle1.transform, true);
        spikeScript.attachedObject = circle1;
    }
    #endregion

    #region SUMMON JUMP PAD FUNCTIONS
    void SummonJumpPad(string direction)
    {

    }
    #endregion

    #region SUMMON FIREBALL FUNCTIONS
    void ShootFireBall(string direction)
    {
        if (direction == "UP")
        {
            if (sameDirection == true)
            {
                ShootFireBallUp();
            }
            else
            {
                ShootFireballDown();
                sameDirection = !sameDirection;
            }
        }
        else if (direction == "DOWN")
        {
            if (sameDirection == true)
            {
                ShootFireballDown();
            }
            else
            {
                ShootFireBallUp();
                sameDirection = !sameDirection;
            }
        }
    }

    void ShootFireBallUp()
    {
        Debug.Log("위 파이어볼 소환");
        fireball.GetComponent<FireballShoot>().destinationPos = upDestination.transform.position;
        InstantiateFireBall();
    }

    void ShootFireballDown()
    {
        Debug.Log("아래 파이어볼 소환");
        fireball.GetComponent<FireballShoot>().destinationPos = downDestination.transform.position;
        InstantiateFireBall();
    }

    void InstantiateFireBall()
    {
        Instantiate(fireball, startDestination.transform.position, startDestination.transform.rotation);
    }
    #endregion

    #region SUMMON ATTACK AREA FUNCTIONS
    void SummonAttackArea(string direction)
    {
        if (direction == "UP")
        {
            if (sameDirection == true)
            {
                //위쪽 생성
                attackArea.SummonSquareArea(spawnPosition2);
            }
            else
            {
                //아래쪽 생성
                attackArea.SummonSquareArea(spawnPosition1);
                sameDirection = !sameDirection;
            }
        }
        else if (direction == "DOWN")
        {
            if (sameDirection == true)
            {
                attackArea.SummonSquareArea(spawnPosition1);
            }
            else
            {
                attackArea.SummonSquareArea(spawnPosition2);
                sameDirection = !sameDirection;
            }
        }
    }
    #endregion

    #region CIRCLE AREA FUNCTIONS
    void TriggerPlatformAttack(string direction)
    {
        if (direction == "UP")
        {
            if (sameDirection == true)
            {
                TriggerPlatformAttackUp();
            }
            else
            {
                TriggerPlatformAttackDown();
                sameDirection = !sameDirection;
            }
        }
        else if (direction == "DOWN")
        {
            if (sameDirection == true)
            {
                TriggerPlatformAttackDown();
            }
            else
            {
                TriggerPlatformAttackUp();
                sameDirection = !sameDirection;
            }
        }
    }

    void TriggerPlatformAttackUp()
    {
        attackArea.CircleArea(circle2);
    }

    void TriggerPlatformAttackDown()
    {
        attackArea.CircleArea(circle1);
    }
    #endregion
}
