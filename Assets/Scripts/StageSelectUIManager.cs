using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering.UI;

public class StageSelectUIManager : MonoBehaviour
{
    [SerializeField] GameObject[] stagePanels;
    [SerializeField] GameObject moveLeftButton;
    [SerializeField] GameObject moveRightButton;
    private int currentIndex = 0;
    private int maxIndex;

    void Awake()
    {
        currentIndex = 0;
        maxIndex = stagePanels.Length;
    }

    public void SelectChapter()
    {
        UpdatePanels();
    }

    public void MoveRight()
    {
        currentIndex++;
        if (currentIndex > maxIndex) currentIndex = maxIndex;

        UpdatePanels();
    }

    public void MoveLeft()
    {
        currentIndex--;
        if (currentIndex< 0) currentIndex = 0;

        UpdatePanels();
    }

    private void UpdatePanels()
    {
        Debug.Log(currentIndex);
        stagePanels[currentIndex].SetActive(true);
        for (int i = 0; i < maxIndex; ++i)
        {
            if (i == currentIndex) continue;
            
            stagePanels[i].SetActive(false);
        }
    }
}
