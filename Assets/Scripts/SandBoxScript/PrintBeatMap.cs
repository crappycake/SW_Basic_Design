using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintBeatMap : MonoBehaviour
{
    public void PrintBeat()
    {
        string str = string.Join(",", ChangeNode.CustomBeatMap);
        Debug.Log(str);
    }
}
