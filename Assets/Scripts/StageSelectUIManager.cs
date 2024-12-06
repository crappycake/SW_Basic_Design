using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StageSelectUIManager : MonoBehaviour
{
    [SerializeField] GameObject[] stagePanels;
    [SerializeField] GameObject moveLeftButton;
    [SerializeField] GameObject moveRightButton;

    [SerializeField] GameObject stage4HardPanel;

    private int currentIndex = 0;
    private int maxIndex;

    void Awake()
    {
        currentIndex = 0;
        moveLeftButton.SetActive(false);
        maxIndex = 3;
        CheckStage4();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
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
   
        for (int i = 0; i <= maxIndex; ++i)
        {
            if (i == currentIndex) continue;
            if (stagePanels[i] == null) continue;

            stagePanels[i].SetActive(false);
        }
    }

    private void CheckStage4()
    {
        if (!GameLevelManager.instance.CanEnterStage4Hard())
        {
            maxIndex = 3;
            return;
        }

        stagePanels[stagePanels.Length - 1] = stage4HardPanel;
        if (maxIndex < 4) maxIndex++;
    }
}
