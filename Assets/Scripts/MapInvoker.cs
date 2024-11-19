using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MapInvoker : MonoBehaviour
{
    [Header("Obstacle Prefabs")]
    public GameObject fireballPrefab;
    public GameObject starPrefab;

    [Header("Game Positions")]
    public GameObject startDestination;
    public GameObject upDestination;
    public GameObject downDestination;

    [Header("Circle 1")]
    [SerializeField] private GameObject circleDown;
    [SerializeField] private GameObject spikeDownSpawnPosition;
    [SerializeField] private GameObject playerStartPosition;

    [Header("Circle 2")]
    [SerializeField] private GameObject circleUp;
    [SerializeField] private GameObject spikeUpSpawnPosition;
    [SerializeField] private GameObject playerOtherPosition;

    [Header("SFX Prefabs")]
    [SerializeField] private GameObject testSFX;

    [Header("Start Title")]
    [SerializeField] private GameObject Title;

    private AttackArea attackArea;
    private GameObject fireball;

    int[] BeatMap;
    int[] SFXMap;
    int beat = 0;

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

        BeatMap = global::BeatMap.instance.GetBeatMap();
        SFXMap = global::SFXMap.instance.GetSFXMap();
    }

    public void Beat_Renderer()
    {
        if (beat >= BeatMap.Length || beat>= SFXMap.Length) return;

        switch (BeatMap[beat])
        {
           // case -1: FadeIn(); break;
            //case -2: FadeOut(); break;
            

            case 1: SummonSpikeUp(); break;
            case 2: SummonSpikeDown(); break;
            //case 3: SummonJumpPad("UP");                                   break;
            //case 4: SummonJumpPad("DOWN");                                 break;
            case 5: ShootFireBallUp(); break;
            case 6: ShootFireballDown(); break;
            case 7: attackArea.TriggerSquareAreaAttack(playerOtherPosition); break;
            case 8: attackArea.TriggerSquareAreaAttack(playerStartPosition); break;
            case 9: attackArea.TriggerCircleAreaAttack(circleUp); break;
            case 10: attackArea.TriggerCircleAreaAttack(circleDown); break;
            case 11: attackArea.TriggerSquareAreaAttack(playerOtherPosition, 0.5f); break;
            case 12: attackArea.TriggerSquareAreaAttack(playerStartPosition, 0.5f); break;
            case 13: SummonStarUp(); break;
            case 14: SummonStarDown(); break;
            case 15: 
                SummonSpikeUp();
                SummonStarDown();
                break;
            case 16:
                SummonSpikeDown();
                SummonStarUp();
                break;

            default: break;
        }

        switch (SFXMap[beat])
        {
            case 1: TriggerTestSFX(); break;
            case 2:
            case 3:

            default:break;
        }
        beat++;
    }

    /*
    #region TITLE FUNCTION
    void FadeIn()
    {
        if (Title == null) Debug.Log("Title is null");
        StageTitle stageTitle = Title.GetComponent<StageTitle>();
        if (stageTitle != null) Debug.Log("stageTitle is null");
        stageTitle.FadeIn();
    }

    void FadeOut()
    {
        StageTitle stageTitle = Title.GetComponent<StageTitle>();
        stageTitle.FadeOut();
    }

    #endregion
    */

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

    #region SUMMON STAR FUNCTIONS
    void SummonStarUp()
    {
        GameObject newStar = Instantiate(starPrefab, spikeUpSpawnPosition.transform.position, quaternion.identity);
        newStar.transform.SetParent(circleUp.transform, true);

        AttachToCircle attachToCircle = newStar.GetComponent<AttachToCircle>();
        attachToCircle.attachedObject = circleUp;
    }

    void SummonStarDown()
    {
        GameObject newStar = Instantiate(starPrefab, spikeDownSpawnPosition.transform.position, quaternion.identity);
        newStar.transform.SetParent(circleDown.transform, true);

        AttachToCircle attachToCircle = newStar.GetComponent<AttachToCircle>();
        attachToCircle.attachedObject = circleDown;
    }
    #endregion

    #region SFX FUNCTIONS
    void TriggerTestSFX()
    {
        Instantiate(testSFX, Vector3.zero, Quaternion.identity);
    }
    #endregion
}
