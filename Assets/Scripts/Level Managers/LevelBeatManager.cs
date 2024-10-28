using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

public class LevelBeatManager : MonoBehaviour
{
    [SerializeField] private float bpm;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Intervals[] intervals;

    private void Update()
    {
        foreach (Intervals interval in intervals)
        {
            float sampledTime = audioSource.timeSamples / (audioSource.clip.frequency * interval.GetIntervalLength(bpm));
            interval.CheckForNewInterval(sampledTime);
        }
    }

    public int GetAudioSourceProgress()
    {
        float progress = audioSource.time / audioSource.clip.length;
        return (int) (progress * 100);
    }
}

[System.Serializable]
public class Intervals
{
    [SerializeField] private float steps;
    [SerializeField] private UnityEvent trigger;
    private int lastInterval;

    public float GetIntervalLength(float bpm)
    {
        return 60f / (bpm * steps); //how many seconds in a beat
    }

    public void CheckForNewInterval(float interval)
    {
        if (Mathf.FloorToInt(interval) != lastInterval)
        {
            lastInterval = Mathf.FloorToInt(interval);
            trigger.Invoke();
        }
    
    }
}
