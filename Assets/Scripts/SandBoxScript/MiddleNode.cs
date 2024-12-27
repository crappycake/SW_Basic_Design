using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiddleNode : ChangeNode
{
    [SerializeField] RecordManager recordManager;
    private void Update()
    {
        for (int i = 0; i <= 8; ++i)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                if(i > 2) ModifyInfoWithKey(i + 2);
                else ModifyInfoWithKey(i);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))        { recordManager.PressRecord(); }
        if (Input.GetKeyDown(KeyCode.LeftArrow))    { recordManager.PressLMove(); }
        if (Input.GetKeyDown(KeyCode.RightArrow))   { recordManager.PressRMove(); }

        slider.value = nodeGap;
    }
    private void ModifyInfoWithKey(int key)
    {
        CustomBeatMap[nodeGap] = key;
        nextImage();
        //Debug.Log("Map Modified : " + nodeGap + " | " + CustomBeatMap[nodeGap]);
    }
}
