using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStarUIManager : MonoBehaviour
{
    public int chapter, stage;

    //array of stage names
    string[] chapter1Stages = { "1-1", "1-2", "1-3" };
    string[] chapter2Stages = { "2-1", "2-2", "2-3" };

    [SerializeField] Image[] stage1StarImages = new Image[3];
    [SerializeField] Image[] stage2StarImages = new Image[3];
    [SerializeField] Image[] stage3StarImages = new Image[3];
    [SerializeField] Image[] stage4StarImages = new Image[3];

    void Awake()
    {
        ShowNumberOfStarsForSelectedStage();
    }

    //select which string array and image array to use depending on given "stage"
    //Gets the number of stars of the given "stage" and sets the amount of stars for the given "stage"
    //1 stage should have 1 of this script.
    private void ShowNumberOfStarsForSelectedStage()
    {
        string[] currentChapter = chapter1Stages;
        Image[] images = stage1StarImages;

        switch (chapter)
        {
            case 1:
                currentChapter = chapter1Stages;
                break;
            case 2:
                currentChapter = chapter2Stages;
                break;
        }

        switch (stage)
        {
            case 1:
                images = stage1StarImages;
                break;
            case 2:
                images = stage2StarImages;
                break;
        }

        for (int i = 0; i < 3; ++i)
        {
            int numberOfStars = GameLevelManager.instance.GetStarsForGivenLevel(currentChapter[i]);
            for (int j = 0; j < numberOfStars; ++j)
            {
                images[j].enabled = true;
            }
        }

    }
}
