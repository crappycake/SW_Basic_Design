using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class StageTitle : MonoBehaviour
{
    TextMeshProUGUI title;
    Text subTitle;
    Image background;

    bool fadeOut = false;
    float test;
    int back;

    //시작 설정
    void Awake()
    {
        gameObject.SetActive(true);

        background = gameObject.transform.GetChild(0).GetComponent<Image>();
        title = gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        subTitle = gameObject.transform.GetChild(2).GetComponent<Text>();

        background.color = new Color(56 / 255f, 56 / 255f, 56 / 255f, 243 / 255f);
        title.color = new Color(1, 1, 1, 1);
        subTitle.color = new Color(1, 1, 1, 1);

        back = 243;
    }

    //fade out 효과
    void FixedUpdate()
    {
        test += Time.deltaTime;

        if (test > 1)
        {
            back -= 2;

            if (back <= 0) gameObject.SetActive(false);

            background.color = new Color(56 / 255f, 56 / 255f, 56 / 255f, back / 255f);
            title.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, (back + 12) / 255f);
            subTitle.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, (back + 12) / 255f);
        }
    }
}