using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LevelProgressManager : MonoBehaviour
{
    private LevelBeatManager levelBeatManager;
    private PlayerHealthManager playerHealthManager;
    [HideInInspector] public int numberOfStars;

    private BossScript bossScript;

    void Awake()
    {
        levelBeatManager = FindObjectOfType<LevelBeatManager>();
        playerHealthManager = FindObjectOfType<PlayerHealthManager>();

        playerHealthManager.OnGameOver += UpdateLevelProgress;
        levelBeatManager.OnMusicEnded.AddListener(UpdateLevelProgress);
        levelBeatManager.OnMusicEnded.AddListener(UpdateLevelStars);

        bossScript = FindObjectOfType<BossScript>();

        if (bossScript != null ) bossScript.OnBossDead.AddListener(UpdateLevelProgress);
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
