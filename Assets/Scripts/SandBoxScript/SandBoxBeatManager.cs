using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

public class SandBoxBeatManager : MonoBehaviour
{
    [SerializeField] private int bpm;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Intervals[] intervals;

    bool musicStarted = false;
    void Awake()
    {
        musicStarted = false;
        audioSource.time = (60 / (float)bpm) * 8;
    }

    public void musicStart()
    {
        musicStarted = true;
        audioSource.Play();
    }

    public void musicStop()
    {
        audioSource.Pause();
        musicStarted = false;
    }

    public int musicLength()
    {
        Debug.Log("audioClipLength : " + audioSource.clip.length);
        Debug.Log("BPM : " + bpm);
        return (int)(audioSource.clip.length * bpm / 60);
    }

    public void Rmove()
    {
        float newTime = audioSource.time + (60 / (float)bpm);
        audioSource.time = Mathf.Max(newTime, 0);
        audioSource.time = Mathf.Min(newTime, audioSource.clip.length);
    }

    public void Lmove()
    {
        float newTime = audioSource.time - (60 / (float)bpm);
        audioSource.time = Mathf.Max(newTime, 0);
        audioSource.time = Mathf.Min(newTime, audioSource.clip.length);
    }

    public void GotoBeat(int beat)
    {
        audioSource.time = (60 / (float)bpm) * (beat + 8);
    }
    private void Update()
    {
        if (musicStarted)
        {
            if (!audioSource.isPlaying && audioSource.time >= audioSource.clip.length)
            {
                musicStarted = false;
                audioSource.Pause();
            }

            foreach (Intervals interval in intervals)
            {
                float sampledTime = audioSource.timeSamples / (audioSource.clip.frequency * interval.GetIntervalLength(bpm));
                interval.CheckForNewInterval(sampledTime);
            }
        }
    }

    public int GetAudioSourceProgress()
    {
        if (audioSource.clip == null)
        {
            Debug.LogError("Audio clip is not assigned!");
            return 0;
        }

        float progress = audioSource.time / audioSource.clip.length;
        return (int)(progress * 100);
    }
}