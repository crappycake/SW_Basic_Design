using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LevelProgressManager : MonoBehaviour
{
    private LevelBeatManager levelBeatManager;
    private PlayerHealthManager playerHealthManager;

    void Awake()
    {
        levelBeatManager = FindObjectOfType<LevelBeatManager>();
        playerHealthManager = FindObjectOfType<PlayerHealthManager>();

        playerHealthManager.OnGameOver += UpdateLevelProgress;

    }

    void UpdateLevelProgress()
    {
        int progress = levelBeatManager.GetAudioSourceProgress();
        Debug.Log(progress);
        GameLevelManager.instance.SetCurrentLevelProgress(progress);
    }

}
