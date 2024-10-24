using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageStarUIManager : MonoBehaviour
{
    public int stage;

    //array of stage names
    string[] stage1 = {"1-1", "1-2", "1-3"};
    string[] stage2 = {"2-1", "2-2", "2-3"};
 
    [SerializeField] Image[] stage1StarImages;
    [SerializeField] Image[] stage2StarImages;
    [SerializeField] Image[] stage3StarImages;

    void Awake()
    {
        ShowNumberOfStarsForSelectedStage();
    }
    //select which string array and image array to use depending on given "stage"
    //Gets the number of stars of the given "stage" and sets the amount of stars for the given "stage"
    //The chapter information is not used... 1 chapter should have 1 of this script.
    private void ShowNumberOfStarsForSelectedStage()
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
