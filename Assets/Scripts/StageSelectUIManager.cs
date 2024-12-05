using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;
public class StageSelectUIManager : MonoBehaviour
{
    [SerializeField] GameObject[] stagePanels;
    [SerializeField] GameObject moveLeftButton;
    [SerializeField] GameObject moveRightButton;

    [Header("Boss Stage UIs")]
    [SerializeField] Button stage4Button;
    [SerializeField] GameObject stage4HardPanel;

    private int currentIndex = 0;
    private int maxIndex;

    void Awake()
    {
        currentIndex = 0;
        moveLeftButton.SetActive(false);
        maxIndex = stagePanels.Length - 1;
    }

    public void SelectChapter()
    {
        UpdatePanels();
    }

    public void MoveRight()
    {
        currentIndex++;
        moveLeftButton.SetActive(true);

        if (currentIndex >= maxIndex) 
        {
            currentIndex = maxIndex;
            moveRightButton.SetActive(false);
        }

        UpdatePanels();
    }

    public void MoveLeft()
    {
        currentIndex--;
        moveRightButton.SetActive(true);

        if (currentIndex <= 0) 
        {
            currentIndex = 0;
            moveLeftButton.SetActive(false);
        }

        UpdatePanels();
    }

    private void UpdatePanels()
    {
        stagePanels[currentIndex].SetActive(true);
        for (int i = 0; i < maxIndex + 1; ++i)
        {
            if (i == currentIndex) continue;
            
            stagePanels[i].SetActive(false);
        }
    }
}
