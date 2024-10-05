using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_Maker : MonoBehaviour
{
    int[] spike = new int[330];
    int beat = 0;
    public GameObject spikePrefab;

    [Header("Circle 1")]
    [SerializeField] private GameObject circle1;
    [SerializeField] private GameObject spawnPosition1;

    [Header("Circle 2")]
    [SerializeField] private GameObject circle2;
    [SerializeField] private GameObject spawnPosition2;

    private void Awake()
    {
        for (int i = 0; i < spike.Length; i++) { spike[i] = i % 2; }
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
            spikeClone.transform.position = new Vector3(spawnPosition1.transform.position.x, spawnPosition1.transform.position.y);
            spikeClone.transform.SetParent(circle1.transform);

            spikeScript.attachedObject = circle1;
        }
        else if (num == 2)
        {
            spikeClone.transform.position = new Vector3(spawnPosition1.transform.position.x, spawnPosition2.transform.position.y);
            spikeScript.attachedObject = circle2;
            spikeClone.transform.SetParent(circle2.transform);
        }
    }
}
