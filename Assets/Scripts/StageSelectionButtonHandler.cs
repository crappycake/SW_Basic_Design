using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectionButtonHandler : MonoBehaviour
{
    public void SetStage(string stageToSet)
    {
        if (!string.IsNullOrEmpty(stageToSet))
        {
            GameStageManager.instance.SetCurrentStage(stageToSet);
        }
    }
}
