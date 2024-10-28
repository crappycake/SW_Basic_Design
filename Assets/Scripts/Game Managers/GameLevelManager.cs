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

    private Dictionary<string, int> levelProgress = new Dictionary<string, int>
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

    #region CURRENT LEVEL GETTER & SETTER
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

    #region LEVEL STARS GETTER & SETTER
    public int GetCurrentLevelStars()
    {
        return levelStars[currentLevel];
    }

    //return number of stars of given "stage"
    public int GetSelectedLevelStars(string level)
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

    #region LEVEL PROGRESS GETTER & SETTER
    public int GetCurrentLevelProgress()
    {
        return levelProgress[currentLevel];
    }

    public int GetSelectedLevelProgress(string _level)
    {
        if (levelProgress.ContainsKey(_level))
        {
            return levelProgress[_level];
        }

        return 0;
    }

    public void SetCurrentLevelProgress(int _progress)
    {
        if (_progress < 0)          Debug.LogError("Current progress value is given wrong at GameLevelManager!");
        else if ( _progress > 100) _progress = 100;

        levelProgress[currentLevel] = _progress;
    }
    #endregion
}
