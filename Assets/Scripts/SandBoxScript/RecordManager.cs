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


}
