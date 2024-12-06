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
    
    public UnityEvent OnMusicEnded;
    bool musicEnded = false;

    private PlayerHealthManager playerHealthManager;
    private MenuHierarchyController menuHierarchyController;

    void Awake()
    {
        musicEnded = false;

        playerHealthManager = FindObjectOfType<PlayerHealthManager>();
        playerHealthManager.OnGameOver += StopMusic;

        menuHierarchyController = FindObjectOfType<MenuHierarchyController>();
        menuHierarchyController.OnPauseToggled.AddListener(PauseMusic);
    }

    private void Update()
    {
        if (musicEnded) return;

        if (!audioSource.isPlaying && audioSource.time >= audioSource.clip.length)
        {
            musicEnded = true;
            OnMusicEnded.Invoke();
        }

        foreach (Intervals interval in intervals)
        {
            float sampledTime = audioSource.timeSamples / (audioSource.clip.frequency * interval.GetIntervalLength(bpm));
            interval.CheckForNewInterval(sampledTime);
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

    private void PauseMusic()
    {
        if (audioSource.isPlaying) audioSource.Pause();
        else audioSource.UnPause();
    }
    private void StopMusic()
    {
        musicEnded = true;
        audioSource.Pause();
    }

    public float Bpm()
    {
        return bpm;
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
