using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LevelProgressManager : MonoBehaviour
{
    private LevelBeatManager levelBeatManager;
    private PlayerHealthManager playerHealthManager;
    [HideInInspector] public int numberOfStars;

    void Awake()
    {
        levelBeatManager = FindObjectOfType<LevelBeatManager>();
        playerHealthManager = FindObjectOfType<PlayerHealthManager>();

        playerHealthManager.OnGameOver += UpdateLevelProgress;
        levelBeatManager.OnMusicEnded.AddListener(UpdateLevelProgress);
        levelBeatManager.OnMusicEnded.AddListener(UpdateLevelStars);
    }

    void Start()
    {
        numberOfStars = 0;
    }

    void UpdateLevelProgress()
    {
        int progress = levelBeatManager.GetAudioSourceProgress();
        GameLevelManager.instance.SetCurrentLevelProgress(progress);
    }

    public void AddStars()
    {
        numberOfStars += 1;
    }

    void UpdateLevelStars()
    {
        GameLevelManager.instance.SetCurrentLevelStars(numberOfStars);

        if (playerHealthManager.currentHealth == playerHealthManager.maxHealth) GameLevelManager.instance.SetCurrentLevelPrefectClear();
    }

}
