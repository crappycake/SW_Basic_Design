using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class ChagneNode : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    public int nodeGap;
    static int nodeLength;
    TextMeshProUGUI nodeText;
    Sprite nodeSprite;
    static SandBoxBeatManager beatManager;

    static int[] CustomBeatMap;

    private void Awake()
    {
        nodeSprite = transform.GetChild(0).GetComponent<Sprite>();
        nodeText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        beatManager = GameObject.Find("Beat Manager").GetComponent<SandBoxBeatManager>();
    }

    public static void LoadBPM()
    {
        nodeLength = beatManager.musicLength();
        if (nodeLength <= 0)
        {
            Debug.Log("nodeLength ERROR");
        }
        else
        {
            CustomBeatMap = new int[nodeLength];
        }
    }
    public void nextBeat()
    {
        nodeGap++;
        nextImage();
        nextText();
    }

    void nextImage()
    {
        if (nodeGap >= 0)
        {
            if (nodeGap >= nodeLength) Debug.Log("null beat");
            else
            {
                int chooseSprite = CustomBeatMap[nodeGap];
                if (sprites[chooseSprite] == null) Debug.Log("null sprites" + chooseSprite);
                else nodeSprite = sprites[chooseSprite];
            }
        }
    }
    void nextText()
    {
        int thisNode = nodeGap;
        if (thisNode < 0 || thisNode > nodeLength) nodeText.text = "";
        else nodeText.text = (nodeGap).ToString();
    }
}
