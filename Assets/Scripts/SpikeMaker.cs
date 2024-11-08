using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMaker : MonoBehaviour
{
    //���̾
    public GameObject fireballPrefab; //���̾ ������!!
    GameObject fireball; //GetComponent�� ���� ��ũ��Ʈ ������ �ѹ� �� ����
    public GameObject startDestination;
    public GameObject upDestination;
    public GameObject downDestination;

    int[] spike;
    int beat = 0;
    bool sameDirection = false; //���������� ����������

    [Header("Circle 1")]
    [SerializeField] private GameObject circleDown;
    [SerializeField] private GameObject spikeDownSpawnPosition;
    [SerializeField] private GameObject playerStartPosition;
    [Header("Circle 2")]
    [SerializeField] private GameObject circleUp;
    [SerializeField] private GameObject spikeUpSpawnPosition;
    [SerializeField] private GameObject playerOtherPosition;

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
        //1-1 �� ���� ���ڷ� �����ϰų� "-" ���ڰ� ���Ե� ���, enum���� ������ �Ұ���. ���� �ʿ�
    }
    public void Beat_Renderer()
    {
        switch (spike[beat])
        {
            case 1: SummonSpikeUp();                break;
            case 2: SummonSpikeDown();              break;
            //case 3: SummonJumpPad("UP");            break;
            //case 4: SummonJumpPad("DOWN");          break;
            case 5: ShootFireBallUp();              break;
            case 6: ShootFireballDown();            break;
            case 7: attackArea.TriggerSquareAreaAttack(playerOtherPosition); break;
            case 8: attackArea.TriggerSquareAreaAttack(playerStartPosition); break;
            case 9: attackArea.TriggerCircleAreaAttack(circleUp);            break;
            case 10:attackArea.TriggerCircleAreaAttack(circleDown);          break;
            default:                                break;
        }

        beat++;
    }


    /*
     
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
     */

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

        //�� ������ũ ��ȯ
        spikeClone.transform.position = new Vector3(spikeDownSpawnPosition.transform.position.x, spikeUpSpawnPosition.transform.position.y);
        spikeClone.transform.SetParent(circleUp.transform, true);
        spikeScript.attachedObject = circleUp;
    }

    void SummonSpikeDown()
    {
        GameObject spikeClone = ObjectPool.SharedInstance.GetPooledObject();
        spikeClone.SetActive(true);
        var spikeScript = spikeClone.GetComponent<AttachToCircle>();


        //�Ʒ� ������ũ ��ȯ
        spikeClone.transform.position = new Vector3(spikeDownSpawnPosition.transform.position.x, spikeDownSpawnPosition.transform.position.y);
        spikeClone.transform.SetParent(circleDown.transform, true);
        spikeScript.attachedObject = circleDown;
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
        fireball.GetComponent<FireballShoot>().destinationPos = upDestination.transform.position;
        InstantiateFireBall();
    }

    void ShootFireballDown()
    {
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
            Debug.Log("1");
            if (sameDirection == true)
            {  
                //���� ����
                Debug.Log("2");
                attackArea.TriggerSquareAreaAttack(playerOtherPosition);
            }
            else
            {
                //�Ʒ��� ����
                Debug.Log("3");
                attackArea.TriggerSquareAreaAttack(playerStartPosition);
                sameDirection = !sameDirection;
            }
        }
        else if (direction == "DOWN")
        {
            if (sameDirection == true)
            {
                attackArea.TriggerSquareAreaAttack(playerStartPosition);
            }
            else
            {
                attackArea.TriggerSquareAreaAttack(playerOtherPosition);
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
        attackArea.TriggerCircleAreaAttack(circleUp);
    }

    void TriggerPlatformAttackDown()
    {
        attackArea.TriggerCircleAreaAttack(circleDown);
    }
    #endregion
}
