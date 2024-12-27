using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;

public class ChagneNode : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    public int nodeGap;
    static int nodeLength;
    TextMeshProUGUI nodeText;
    Image nodeSprite;
    static SandBoxBeatManager beatManager;

    public static int[] CustomBeatMap;

    private void Awake()
    {
        nodeSprite = transform.GetChild(0).GetComponent<Image>();
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
        if (nodeGap > nodeLength + 4)
        {
            Debug.Log("print�� ����ϰ� �ٽ� ���弼��. �̷��� ���� ���ϴ�;;");
        }
        nodeGap++;
        nextImage();
        nextText();
    }

    public void prevBeat()
    {
        if (nodeGap < -4)
        {
            Debug.Log("print�� ����ϰ� �ٽ� ���弼��. �̷��� ���� ���ϴ�;;");
        }
        nodeGap--;
        nextImage();
        nextText();
    }

    public void GotoBeat(int Beat)
    {
        nodeGap = Beat;
        nextImage();
        nextText();
    }

    public void nextImage()
    {
        if (nodeGap >= 0)
        {
            if (nodeGap >= nodeLength) Debug.Log("null beat");
            else
            {
                int chooseSprite = CustomBeatMap[nodeGap];
                if (sprites[chooseSprite] == null) Debug.Log("null sprites" + chooseSprite);
                else nodeSprite.sprite = sprites[chooseSprite];
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
