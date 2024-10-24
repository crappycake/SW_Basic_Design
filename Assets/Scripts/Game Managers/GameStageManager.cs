using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameStageManager : MonoBehaviour
{
    public static GameStageManager instance;

    private Dictionary<string, int> stageStars = new Dictionary<string, int>
    {
        {"1-1", 0},
        {"1-2", 0},
        {"1-3", 0}
    };

    private string currentStage;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #region CURRENT STAGE GETTER & SETTER
    public string GetCurrentStage()
    {
        return currentStage;
    }

     /// <summary>
    /// Stage info should be given as a string. For example, stage 1-1 would equal to "1-1". Number of stars for each stage can simply be used directly as an int.
    /// </summary>
    public void SetCurrentStage(string stage)
    {
        if (stageStars.ContainsKey(stage))
        {
            currentStage = stage;
        }
        else
        {
            Debug.LogError("Stage " + stage + " not found for GameStarManager!");
        }
    }
    #endregion

    #region STAGE STARS GETTER & SETTER
    public int GetStarsForCurrentStage()
    {
        return stageStars[currentStage];
    }

    public int GetStarsForGivenStage(string stage)
    {
        if (stageStars.ContainsKey(stage))
        {
            return stageStars[stage];
        }

        return 0;
    }

    public void SetStarsForCurrentStage(int numberOfStars)
    {
        if (numberOfStars < 0 || numberOfStars > 3)
        {
            Debug.LogError("Incorrect amount of number of stars delivered to GameStageManager");
            return;
        }
        stageStars[currentStage] = numberOfStars;
    }

    #endregion
}
