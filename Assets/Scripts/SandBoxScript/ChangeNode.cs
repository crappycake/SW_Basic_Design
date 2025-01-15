using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;

public class ChangeNode : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    public static Slider slider;
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
        slider = GameObject.Find("Music Slider").GetComponent<Slider>();
    }

    public static void MakeBeatMap()
    {
        nodeLength = beatManager.musicLength();
        CustomBeatMap = BeatMap.LoadTestMap();
        if (nodeLength <= 0)
        {
            Debug.Log("nodeLength ERROR");
        }
        else
        {
            CustomBeatMap = new int[nodeLength];
            slider.minValue = 0;
            slider.maxValue = nodeLength;
        }
    }
    public static void LoadBeatMap()
    {
        nodeLength = PlayerPrefs.GetInt("TestMapLength", 0); // 기본값 0
        if (nodeLength == 0) Debug.Log("비어있는 배열입니다.");
        else if (nodeLength != beatManager.musicLength()) Debug.Log("다른 노래의 배열로 사용 중입니다.");
        else
        {
            CustomBeatMap = new int[nodeLength];
            for (int i = 0; i < nodeLength; i++)
            {
                CustomBeatMap[i] = PlayerPrefs.GetInt($"TestMap_{i}", 0); // 기본값 0
            }
            Debug.Log("TestMap loaded!");

            slider.minValue = 0;
            slider.maxValue = nodeLength;
        }
    }

    public static void SaveBeatMap()
    {
        for (int i = 0; i < CustomBeatMap.Length; i++)
        {
            PlayerPrefs.SetInt($"TestMap_{i}", CustomBeatMap[i]);
        }
        PlayerPrefs.SetInt("TestMapLength", CustomBeatMap.Length);
        PlayerPrefs.Save();
        Debug.Log("TestMap saved!");
    }
    public static void PrintBeatMap()
    {
        string str = string.Join(",", CustomBeatMap);
        Debug.Log(str);
    }
    public void nextBeat()
    {
        if (nodeGap > nodeLength + 4)
        {
            beatManager.musicStop();
        }
        nodeGap++;
        nextImage();
        nextText();
    }

    public void prevBeat()
    {
        if (nodeGap < -4)
        {
            beatManager.musicStop();
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

                if (chooseSprite > 2)
                {
                    if (sprites[chooseSprite - 2] == null) Debug.Log("null sprites" + (chooseSprite - 2));
                    else nodeSprite.sprite = sprites[chooseSprite - 2];
                }
                else
                {
                    if (sprites[chooseSprite] == null) Debug.Log("null sprites" + chooseSprite);
                    else nodeSprite.sprite = sprites[chooseSprite];
                }
            }
        }
    }

    void nextText()
    {
        int thisNode = nodeGap;
        if (thisNode < 0 || thisNode > nodeLength) nodeText.text = "";
        else nodeText.text = (nodeGap).ToString();
    }

    public static int readNodeLength()
    {
        return nodeLength;
    }
}
