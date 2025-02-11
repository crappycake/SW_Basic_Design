using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelManager : MonoBehaviour
{
    public static GameLevelManager instance;

    private Dictionary<string, int> levelStars = new Dictionary<string, int>
    {
        {"1-1", 0},
        {"1-2", 0},
        {"1-3", 0},
        {"1-4", 0},
        {"1-4H", 0},
        {"Test", 0}
    };

    private Dictionary<string, int> levelProgress = new Dictionary<string, int>
    {
        {"1-1", 0},
        {"1-2", 0},
        {"1-3", 0},
        {"1-4", 0},
        {"1-4H", 0}
    };

    private Dictionary<string, bool> perfectClear = new Dictionary<string, bool>
    {
        {"1-1", false},
        {"1-2", false},
        {"1-3", false},
        {"1-4", false},
        {"1-4H", false}
    };

    private string currentLevel;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadGameData(); 
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

    public int GetSelectedLevelStars(string level)
    {
        if (levelStars.ContainsKey(level))
        {
            return levelStars[level];
        }

        return 0;
    }

    public void SetCurrentLevelStars(int numberOfStars)
    {
        if (numberOfStars < 0 || numberOfStars > 3)
        {
            Debug.LogError("Incorrect amount of number of stars delivered to GameStageManager");
            return;
        }

        if (numberOfStars <= levelStars[currentLevel]) return;

        levelStars[currentLevel] = numberOfStars;
        SaveGameData();  
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
        if (_progress < 0) Debug.LogError("Current progress value is given wrong at GameLevelManager!");
        else if (_progress > 100) _progress = 100;

        if (_progress <= levelProgress[currentLevel]) return;
        levelProgress[currentLevel] = _progress;
        SaveGameData();  
    }
    #endregion

    #region LEVEL PERFECT CLEAR
    public void SetCurrentLevelPrefectClear()
    {
        perfectClear[currentLevel] = true;
        SaveGameData();  
    }

    public bool IsCurrentLevelPerfectClear()
    {
        return perfectClear[currentLevel];
    }

    public bool IsSelectedLevelPerfectClear(string selected)
    {
        return perfectClear[selected];
    }
    #endregion

    #region BOSS STAGE CHECKERS

    public bool CanEnterStage4()
    {
        int stars = levelStars["1-1"] + levelStars["1-2"] + levelStars["1-3"];

        if (stars == 9) return true;
        else return false;
    }

    public bool CanEnterStage4Hard()
    {
        if (levelProgress["1-4"] == 100) return true;
        return false;
    }
    #endregion

#if UNITY_EDITOR
    public void Test1()
    {
        levelStars["1-1"] = 3;
        levelStars["1-2"] = 3;
        levelStars["1-3"] = 3;
    }

    public void Test2()
    {
        levelProgress["1-4"] = 100;
    }
#endif

    #region GAME DATA FUNCTIONS
    private void SaveGameData()
    {
        foreach (var level in levelStars.Keys)
        {
            PlayerPrefs.SetInt(level + "_Stars", levelStars[level]);
            PlayerPrefs.SetInt(level + "_Progress", levelProgress[level]);
            PlayerPrefs.SetInt(level + "_PerfectClear", perfectClear[level] ? 1 : 0);
        }
        PlayerPrefs.SetString("CurrentLevel", currentLevel);
        PlayerPrefs.Save();
    }

    private void LoadGameData()
    {
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            currentLevel = PlayerPrefs.GetString("CurrentLevel");
        }

        List<string> levelKeys = new List<string>(levelStars.Keys);

        foreach (var level in levelKeys)
        {
            if (PlayerPrefs.HasKey(level + "_Stars"))
            {
                levelStars[level] = PlayerPrefs.GetInt(level + "_Stars");
            }

            if (PlayerPrefs.HasKey(level + "_Progress"))
            {
                levelProgress[level] = PlayerPrefs.GetInt(level + "_Progress");
            }

            if (PlayerPrefs.HasKey(level + "_PerfectClear"))
            {
                perfectClear[level] = PlayerPrefs.GetInt(level + "_PerfectClear") == 1;
            }
        }
    }


    #endregion
}
