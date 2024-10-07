using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_Maker : MonoBehaviour
{
    int[] spike = new int[]
    { 0, 1, 0 ,1 ,0 ,1, 0, 1 ,0 ,1 ,0 ,1 ,0, 1 ,1 ,1 ,0 ,1 ,0 ,1 ,0 ,1 ,0 ,1 ,0 ,1 ,0 ,1 ,1 ,1 ,1,
0, 0, 1 ,0 ,1 ,0 ,1 ,1 ,1 ,0 ,1,0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1 ,1
,0 ,1 ,0 ,1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1 ,0 ,0 ,1 ,0, 1, 0, 1, 0, 1, 0, 1, 0 ,1, 1, 0,  1, 0 ,1 ,0 ,1 ,1 ,1 ,0, 1,
0, 1, 1, 1, 0, 1, 0, 1 ,0 ,1 ,1, 1, 1 ,0 ,0, 1, 0, 1 ,1, 1, 1, 0, 0 ,1 ,0 ,0 ,0, 0
,1 ,1 ,0, 0, 1, 1 ,0, 0, 1, 1, 0, 0, 1,1 ,0 ,0 ,1 ,1, 0, 0, 1, 1 ,0 ,0 ,1, 0, 1, 0, 0, 0, 0
,0 ,1 ,0 ,1 ,0 ,1 ,1 ,1,0 ,1 ,0 ,1 ,0, 1 ,1, 1, 0, 1, 0, 1 ,0 ,1 ,1 ,1 ,0 ,1, 0, 1, 0, 1, 1, 1
,1 ,0 ,1, 0, 1, 1, 1,  0, 0, 1 ,0 ,1 ,0 ,1 ,1 ,1, 0 ,1 ,0, 1 ,0 ,1 ,1, 1, 0 ,1 ,0 ,1, 0, 1, 0 ,0
,0, 1, 0 ,0 ,0, 1 ,0, 0, 0, 1, 0, 0 ,0, 1 ,0, 0, 0, 1,0 ,0 ,0,1 ,0 ,0 ,0 ,1 ,0, 0, 1, 1, 1,1
,0, 1, 0, 1 ,0 ,1 ,1 ,1, 0 ,1 ,0 ,1 ,0, 1, 1, 1,0 ,1 ,0 ,1 ,0 ,1 ,1, 1 ,0, 1, 1 ,1, 0, 1, 1 ,0,
0, 1 ,0, 1 ,0 ,1 ,1 ,1 ,0 ,1 ,1, 1,0 ,1, 1,1 ,0, 1, 0, 1 ,0 ,1 ,1 ,1, 0, 1 ,1 ,0, 1, 0, 1, 1, 0,0 ,0, 0 ,1
 };


    //{ 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 1, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0 };
    int beat = 0;
    bool flag = false;

    [Header("Circle 1")]
    [SerializeField] private GameObject circle1;
    [SerializeField] private GameObject spawnPosition1;

    [Header("Circle 2")]
    [SerializeField] private GameObject circle2;
    [SerializeField] private GameObject spawnPosition2;

    private void Awake()
    {
        //for (int i = 0; i < spike.Length; i++) { spike[i] = i % 2; }
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
                Summon_Spike();
                break;

        }
        beat++;
    }

    void Summon_Spike()
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

        /*
        if (num == 1 && flag == false || num == 2 && flag == true)
        {
            spikeClone.transform.position = new Vector3(spawnPosition1.transform.position.x, spawnPosition1.transform.position.y);
            spikeClone.transform.SetParent(circle1.transform, true);
            spikeScript.attachedObject = circle1;
            flag = flag != true;
        }
        else if (num == 2 && flag == false || num == 1 && flag == true)
        {
            spikeClone.transform.position = new Vector3(spawnPosition1.transform.position.x, spawnPosition2.transform.position.y);
            spikeClone.transform.SetParent(circle2.transform, true);
            spikeScript.attachedObject = circle2;
            flag = flag != true;
        }
        */
    }
}
