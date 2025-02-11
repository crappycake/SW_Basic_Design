using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartButtonHandler : MonoBehaviour
{
    public void SetStage(string levelToSet)
    {
        if (!string.IsNullOrEmpty(levelToSet))
        {
            GameLevelManager.instance.SetCurrentLevel(levelToSet);
        }
    }
}
