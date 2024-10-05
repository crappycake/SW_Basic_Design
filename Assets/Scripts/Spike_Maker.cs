using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_Maker : MonoBehaviour
{
    int[] spike = new int[330];
    int beat = 0;
    public GameObject spikePrefab;

    private void Awake()
    {
        for (int i = 0; i < spike.Length; i++) { spike[i] = i%2; }
    }
    public void Beat_Renderer()
    {
        switch (spike[beat])
        {
            case 0:
                Summon_Spike(2);
                break;
            case 1:
                Summon_Spike(1);
                break;

        }
        beat++;
    }

    void Summon_Spike(int num)
    {
        GameObject spikeClone = Instantiate(spikePrefab);
        var spikeScript = spikeClone.GetComponent<AttachToCircle>();

        if (num == 1)
        {
            spikeScript.attachedObject = GameObject.Find("Circle");
            spikeClone.transform.SetParent(GameObject.Find("Circle").transform);
        }
        else if (num == 2)
        {
            spikeScript.attachedObject = GameObject.Find("Circle (1)");
            spikeClone.transform.SetParent(GameObject.Find("Circle (1)").transform);
        }
    }
}
