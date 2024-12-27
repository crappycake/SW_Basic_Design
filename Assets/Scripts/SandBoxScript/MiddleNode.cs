using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleNode : ChagneNode
{
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
    }
    private void ModifyInfoWithKey(int key)
    {
        //array[currentNode] = key
        //changeImage
    }
}
