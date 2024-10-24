using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameLevelManager : MonoBehaviour
{
    public static GameLevelManager instance;

    //Dictionary that keeps track of number of stars for each stage
    private Dictionary<string, int> levelStars = new Dictionary<string, int> 
    {
        {"1-1", 0},
        {"1-2", 0},
        {"1-3", 0}
    };

    //current stage player is in. ex) 1-1, 1-2
    private string currentLevel; 

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
    public string GetCurrentLevel()
    {
        return currentLevel;
    }

     /// <summary>
    /// Stage info should be given as a string. For example, stage 1-1 would equal to "1-1". Number of stars for each stage can simply be used directly as an int.
    /// </summary>
    public void SetCurrentLevel(string level) 
    {
        if (levelStars.ContainsKey(level))
        {
            currentLevel = level;
        }
        else
        {
            Debug.LogError("level " + level + " not found for GameStarManager!");
        }
    }
    #endregion

    #region STAGE STARS GETTER & SETTER
    public int GetStarsForCurrentLevel()
    {
        return levelStars[currentLevel];
    }

    //return number of stars of given "stage"
    public int GetStarsForGivenLevel(string level)
    {
        if (levelStars.ContainsKey(level))
        {
            return levelStars[level];
        }

        return 0;
    }

    //return number of stars of the current stage that the player is in.
    public void SetStarsForCurrentLevel(int numberOfStars)
    {
        if (numberOfStars < 0 || numberOfStars > 3)
        {
            Debug.LogError("Incorrect amount of number of stars delivered to GameStageManager");
            return;
        }
        levelStars[currentLevel] = numberOfStars;
    }

    #endregion
}
