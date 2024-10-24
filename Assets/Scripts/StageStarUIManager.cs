using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageStarUIManager : MonoBehaviour
{
    string[] stage1 = {"1-1", "1-2", "1-3"};
    string[] stage2 = {"2-1", "2-2", "2-3"};
 
    [SerializeField] Image[] stage1StarImages;
    [SerializeField] Image[] stage2StarImages;
    [SerializeField] Image[] stage3StarImages;

    public void ShowNumberOfStars(int stage)
    {
        string[] currentStage = stage1;
        Image[] images = stage1StarImages;

        switch (stage)
        {
            case 1: 
                currentStage = stage1;
                images = stage1StarImages;
                break;
            case 2:
                currentStage = stage2;
                images = stage2StarImages;
                break;
        }

        for (int i = 0; i < 3; ++i)
        {
            int numberOfStars = GameStageManager.instance.GetStarsForGivenStage(currentStage[i]);
            for (int j = 0; j < numberOfStars; ++j)
            {
                images[j].enabled = true;
            }
        }
        
    }
}
