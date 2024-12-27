using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordButton : MonoBehaviour
{
    bool RecordButtonOn = false;

    public Sprite[] image = new Sprite[2];
    private Image currentImage;
    [SerializeField] private SandBoxBeatManager beatManager;
    [SerializeField] private GameObject nodes;
    private void Awake()
    {
        currentImage = gameObject.GetComponent<Image>();
    }

    public void PressRecord()
    {
        if (RecordButtonOn) //Play > Pause
        {
            currentImage.sprite = image[1];
            beatManager.musicStop();
        }
        else //Pause > Play
        {
            currentImage.sprite = image[0];
            beatManager.musicStart();
        }

        RecordButtonOn = !RecordButtonOn;
    }
     
    public void PressLMove()
    {
        for (int i = 0; i <= 8; ++i)
        {
            ChagneNode nowNode = nodes.transform.GetChild(i).GetComponent<ChagneNode>();
            nowNode.prevBeat();
        }
        beatManager.Lmove();
    }

    public void PressRMove()
    {
        for (int i = 0; i <= 8; ++i)
        {
            ChagneNode nowNode = nodes.transform.GetChild(i).GetComponent<ChagneNode>();
            nowNode.nextBeat();
        }
        beatManager.Rmove();
    }

    public void PressGotoStart()
    {
        for (int i = -4; i <= 4; ++i)
        {
            ChagneNode nowNode = nodes.transform.GetChild(i + 4).GetComponent<ChagneNode>();
            nowNode.GotoBeat(i);
        }
        beatManager.GotoBeat(0);
    }
}
