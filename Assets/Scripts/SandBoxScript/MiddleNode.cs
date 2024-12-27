using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleNode : ChagneNode
{
    [SerializeField] RecordManager recordManager;
    //getBeatMap : ChangeNode
    private void Update()
    {
        for (int i = 0; i <= 8; ++i)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                ModifyInfoWithKey(i);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))        { recordManager.PressRecord(); }
        if (Input.GetKeyDown(KeyCode.LeftArrow))    { recordManager.PressLMove(); }
        if (Input.GetKeyDown(KeyCode.RightArrow))   { recordManager.PressRMove(); }
    }
    private void ModifyInfoWithKey(int key)
    {
        CustomBeatMap[nodeGap] = key;
        nextImage();
        //Debug.Log("Map Modified : " + nodeGap + " | " + CustomBeatMap[nodeGap]);
    }
}
