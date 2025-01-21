using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInvoker : MonoBehaviour
{
    int[] BossMap;
    [SerializeField] GameObject boss;
    [SerializeField] GameObject[] movePositions = new GameObject[4];

    public GameObject upDestination;
    public GameObject downDestination;
    int beat = 0;
    int q = 0;
    float bpm;
    Vector3 vel = Vector3.zero;

    public GameObject fireballPrefab;
    AttackArea attackArea;
    GameObject fireball;
    void Start()
    {
        fireball = fireballPrefab;
        bpm = GameObject.Find("Beat Manager").GetComponent<LevelBeatManager>().Bpm();
    }

    void Awake()
    {
        attackArea = GetComponent<AttackArea>();
        boss = Instantiate(boss);
        boss.transform.localPosition = movePositions[0].transform.position;
        BossMap = global::BossMap.instance.GetBossMap();
        beat = 0;
    } 

    public void Beat_Renderer()
    {
        if (beat >= BossMap.Length) return;
        if(BossMap[beat] != 0) {
            switch (BossMap[beat] / 10)
            {
                case 0:
                    switch (BossMap[beat] % 10)
                    {
                        case 1: StartCoroutine(MoveBoss(boss, movePositions[0], 1f)); break;
                        case 2: StartCoroutine(MoveBoss(boss, movePositions[1], 1f)); break;
                        case 3: StartCoroutine(MoveBoss(boss, movePositions[2], 1f)); break;
                        case 4: StartCoroutine(MoveBoss(boss, movePositions[3], 1f)); break;
                        case 5: StartCoroutine(MoveBoss(boss, movePositions[4], 1f)); break;
                        case 6: StartCoroutine(MoveBoss(boss, movePositions[5], 1f)); break;
                        case 7: StartCoroutine(MoveBoss(boss, movePositions[6], 1f)); break;
                        case 8: StartCoroutine(MoveBoss(boss, movePositions[7], 1f)); break;
                        case 9: StartCoroutine(MoveBoss(boss, movePositions[8], 1f)); break;
                        default: break;
                    }
                    break;

                case 1:
                    switch (BossMap[beat] % 10)
                    {
                        case 1: attackArea.TriggerSquareAreaAttack(boss); break;
                        case 2: attackArea.TriggerSquareAreaAttack(boss, (float)0.5); break;
                        default: break;
                    }
                    break;
                case 2:
                    switch (BossMap[beat] % 10)
                    {
                        case 1: InstantiateFireBall(boss, upDestination); break;
                        case 2: InstantiateFireBall(boss, downDestination); break;
                        default: break;
                    }
                    break;
                default: break;
            }
         }

        beat++;
    }


    IEnumerator MoveBoss(GameObject boss, GameObject pos, float k)
    {
        while (Vector3.Distance(boss.transform.position, pos.transform.position) > 0.01f)
        {
            boss.transform.position = Vector3.SmoothDamp(boss.transform.position, pos.transform.position, ref vel, GetBeat(bpm) * k);
            yield return new WaitForEndOfFrame();
        }
    }
    void InstantiateFireBall(GameObject boss, GameObject pos)
    {
        fireball.GetComponent<Fireball>().destinationPos = pos.transform.position;
        Vector3 temp = fireball.GetComponent<Fireball>().startPos;
        fireball.GetComponent<Fireball>().startPos = boss.transform.position;

        Instantiate(fireball, boss.transform.position, boss.transform.rotation);
        fireball.GetComponent<Fireball>().startPos = temp;
    }
    private float GetBeat(float bpm)
    {
        return 60f / (bpm); //how many seconds in a beat
    }
}
