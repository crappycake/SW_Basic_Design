using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInvoker : MonoBehaviour
{
    public GameObject fireballPrefab;
    GameObject fireball;
    public GameObject startDestination;
    public GameObject upDestination;
    public GameObject downDestination;

    int[] BeatMap;
    int[] SFXMap;
    int beat = 0;

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

        BeatMap = global::BeatMap.instance.GetBeatMap();
        SFXMap = global::SFXMap.instance.GetSFXMap();
    }

    public void Beat_Renderer()
    {
        if (beat >= BeatMap.Length) return;
        
        switch (BeatMap[beat])
        {
            case 1: SummonSpikeUp();                                         break;
            case 2: SummonSpikeDown();                                       break;
            //case 3: SummonJumpPad("UP");                                   break;
            //case 4: SummonJumpPad("DOWN");                                 break;
            case 5: ShootFireBallUp();                                       break;
            case 6: ShootFireballDown();                                     break;
            case 7: attackArea.TriggerSquareAreaAttack(playerOtherPosition); break;
            case 8: attackArea.TriggerSquareAreaAttack(playerStartPosition); break;
            case 9: attackArea.TriggerCircleAreaAttack(circleUp);            break;
            case 10:attackArea.TriggerCircleAreaAttack(circleDown);          break;
            case 11: attackArea.TriggerSquareAreaAttack(playerOtherPosition, (float)0.5); break;
            case 12: attackArea.TriggerSquareAreaAttack(playerStartPosition, (float)0.5); break;

            default:                                                         break;
        }

        /*
        switch (SFXMap[beat])
        {
            case 1:
            case 2:
            case 3:

            default:break;
        }
        */
        beat++;
    }

    #region SUMMON SPIKE FUNCTION
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
}
