using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIManager : MonoBehaviour
{
    public int chapter;

    // Array of stage names by chapter
    string[] chapter1Stages = { "1-1", "1-2", "1-3", "1-4" };

    #region UI REFERENCES
    [Header("Stage 1")]
    [SerializeField] Image[] stage1StarImages = new Image[3];
    [SerializeField] TextMeshProUGUI stage1ProgressText;
    [SerializeField] Slider stage1ProgressBar;
    [SerializeField] TextMeshProUGUI stage1PerfectClearText;

    [Header("Stage 2")]
    [SerializeField] Image[] stage2StarImages = new Image[3];
    [SerializeField] TextMeshProUGUI stage2ProgressText;
    [SerializeField] Slider stage2ProgressBar;
    [SerializeField] TextMeshProUGUI stage2PerfectClearText;

    [Header("Stage 3")]
    [SerializeField] Image[] stage3StarImages = new Image[3];
    [SerializeField] TextMeshProUGUI stage3ProgressText;
    [SerializeField] Slider stage3ProgressBar;
    [SerializeField] TextMeshProUGUI stage3PerfectClearText;

    [Header("Stage 4")]
    [SerializeField] Image[] stage4StarImages = new Image[3];
    [SerializeField] TextMeshProUGUI stage4ProgressText;
    [SerializeField] Slider stage4ProgressBar;
    [SerializeField] TextMeshProUGUI stage4PerfectClearText;

    #endregion

    void Awake()
    {
        UpdateUIForSelectedChapter();
    }

    // Updates the UI for all stages in the selected chapter
    private void UpdateUIForSelectedChapter()
    {
        Image[][] starImages = { stage1StarImages, stage2StarImages, stage3StarImages, stage4StarImages };
        TextMeshProUGUI[] progressTexts = { stage1ProgressText, stage2ProgressText, stage3ProgressText, stage4ProgressText };
        Slider[] progressBars = { stage1ProgressBar, stage2ProgressBar, stage3ProgressBar, stage4ProgressBar };
        TextMeshProUGUI[] perfectClearTexts = {stage1PerfectClearText, stage2PerfectClearText, stage3PerfectClearText, stage4PerfectClearText};
        for (int i = 0; i < 4; i++)
        {
            int numberOfStars = GameLevelManager.instance.GetSelectedLevelStars(chapter1Stages[i]);
            // Update stars
            for (int j = 0; j < starImages[i].Length; j++)
            {
                starImages[i][j].enabled = j < numberOfStars;
            }

            // Update progress text and progress bar
            float progress = GameLevelManager.instance.GetSelectedLevelProgress(chapter1Stages[i]);
            progressTexts[i].text = $"진행도: {(int)progress}%";
            progressBars[i].value = (float)(progress / 100);
            perfectClearTexts[i].enabled = GameLevelManager.instance.IsSelectedLevelPerfectClear(chapter1Stages[i]);
        }
    }
}
