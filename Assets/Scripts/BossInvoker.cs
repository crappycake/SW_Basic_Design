using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInvoker : MonoBehaviour
{
    int[] BossMap;
    [SerializeField] GameObject boss;
    [SerializeField] GameObject[] movePositions = new GameObject[4];

    int beat = 0;
    void Start()
    {
        
    }

    void Awake()
    {
        BossMap = global::BossMap.instance.GetBossMap();
        beat = 0;
    } 

    public void Beat_Renderer()
    {
        if (beat >= BossMap.Length) return;


        switch(BossMap[beat])
        {
            case 1: break;
            default: break;
        }
        beat++;
    }
}
