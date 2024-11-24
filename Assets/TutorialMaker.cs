using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Tutorial
{
    [TextArea]
    public string dialogue;
}

public class TutorialMaker : MonoBehaviour
{
    #region ATTACK VARIABLE
    [SerializeField] private Text Tutorial;

    [Header("Obstacle Prefabs")]
    public GameObject fireballPrefab;
    //public GameObject starPrefab;

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

    //[Header("SFX Prefabs")]
    //[SerializeField] private GameObject testSFX;

    [Header("Start Title")]
    [SerializeField] private GameObject Title;

    private AttackArea attackArea;
    private GameObject fireball;

    //int[] BeatMap;
    //int[] SFXMap;
    //int beat = 0;
    //***---***
    #endregion

    //***Tutorial***
    public int SceneNum;
    private int tutorialCnt;


    [SerializeField] private Tutorial[] Tutorzip;

    //coroutine
    private bool isShow;
    [HideInInspector] public bool isDamage;

    void Start()
    {
        //Tutorial
        isShow = false;
        isDamage = false;

        Tutorial.gameObject.SetActive(true);
        tutorialCnt = 0;

        //Attack
        fireball = fireballPrefab;
        fireball.GetComponent<FireballShoot>().startPos = startDestination.transform.position;

        attackArea = GetComponent<AttackArea>();
    }

    private void Awake()
    {
        //Attack
        attackArea = gameObject.GetComponent<AttackArea>();
        //beat = 0;
        //BeatMap = global::BeatMap.instance.GetBeatMap();
        //SFXMap = global::SFXMap.instance.GetSFXMap();
    }


    void Update()
    {
        Debug.Log("tutoralcnt:" + tutorialCnt);

        /*
        //Get Key, And Next
        if (tutorialCnt == 0)
        {
            if (!isShow)
                JustShowTutor();

            DoTutor(KeyCode.Space);
        }*/

        //Auto Next
        if (tutorialCnt == 0 || tutorialCnt == 4 || tutorialCnt == 5)
        {
            if (SceneNum == 4)
                SceneManager.LoadScene("1-4");

            if (!isShow)
            {
                isShow = true;
                StartCoroutine(ShowTutor());
            }
        }

        //Not Damage, Next
        else if (tutorialCnt == 1 || tutorialCnt == 2 || tutorialCnt == 3)
        {
            if (!isShow)
            {
                JustShowTutor();
                StartCoroutine(Attack());
            }
        }
        else
        {
            switch (SceneNum)
            {
                case 1:
                    SceneManager.LoadScene("1-1");
                    break;
                case 2:
                    SceneManager.LoadScene("1-2");
                    break;
                case 3:
                    SceneManager.LoadScene("1-3");
                    break;
                default: break;
            }
        }
    }

    IEnumerator Attack()
    {
        switch (SceneNum)
        {
            case 1:
                AttackSwitch(2);
                break;
            case 2:
                if (tutorialCnt == 1)
                    AttackSwitch(7);
                else if (tutorialCnt == 2)
                    AttackSwitch(9);
                else
                    AttackSwitch(7);
                break;
            case 3:
                AttackSwitch(6);
                break;
            default: break;
        }

        yield return new WaitForSeconds(2.5f);
        if (isDamage == true)
        {
            Debug.Log("You Damage!");
        }
        else
        {
            tutorialCnt++;
        }
        isDamage = false;
        isShow = false;

    }

    private void AttackSwitch(int attackNum)
    {
        switch (attackNum)
        {
            case 1: SummonSpikeUp(); break;
            case 2: SummonSpikeDown(); break;
            case 5: ShootFireBallUp(); break;
            case 6: ShootFireballDown(); break;
            case 7: attackArea.TriggerSquareAreaAttack(playerOtherPosition); break;
            case 8: attackArea.TriggerSquareAreaAttack(playerStartPosition); break;
            case 9: attackArea.TriggerCircleAreaAttack(circleUp); break;
            case 10: attackArea.TriggerCircleAreaAttack(circleDown); break;
            case 11: attackArea.TriggerSquareAreaAttack(playerOtherPosition, 0.5f); break;
            case 12: attackArea.TriggerSquareAreaAttack(playerStartPosition, 0.5f); break;

            default: break;
        }

        isShow = true;
    }

    //***Tutorial***
    IEnumerator ShowTutor()
    {
        Tutorial.text = Tutorzip[tutorialCnt].dialogue;
        yield return new WaitForSeconds(2f);
        tutorialCnt++;
        isShow = false;
    }

    public void JustShowTutor()
    {
        Tutorial.text = Tutorzip[tutorialCnt].dialogue;
        isShow = true;
    }

    public void DoTutor(KeyCode flag)
    {
        if (Input.GetKeyDown(flag))
        {
            tutorialCnt++;
            isShow = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Damage" || collision.gameObject.tag == "Fireball")
            isDamage = true;
    }


    #region SUMMON SPIKE FUNCTION
    void SummonSpikeUp()
    {
        GameObject spikeClone = ObjectPool.SharedInstance.GetPooledObject();
        spikeClone.SetActive(true);
        var spikeScript = spikeClone.GetComponent<AttachToCircle>();

        spikeClone.transform.position = new Vector3(spikeDownSpawnPosition.transform.position.x, spikeUpSpawnPosition.transform.position.y);
        spikeClone.transform.SetParent(circleUp.transform, true);
        spikeScript.attachedObject = circleUp;
    }

    void SummonSpikeDown()
    {
        Debug.Log("Splike");
        GameObject spikeClone = ObjectPool.SharedInstance.GetPooledObject();
        spikeClone.SetActive(true);
        var spikeScript = spikeClone.GetComponent<AttachToCircle>();

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
