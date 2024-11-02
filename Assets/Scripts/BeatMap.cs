using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Windows;

public class BeatMap : MonoBehaviour
{
    public static BeatMap instance;

    public enum ELevel
    {
        Test,
        Level1_1,
        Level1_2,
        Level1_3
    }


    int[][] TestLevel = new int[5][]
        {
            new int[]{ 0, 1, 0 ,1 ,0 ,1, 0, 1 ,0 ,1 ,0 ,1 ,1, 1 ,2 ,1 ,0 ,0 ,0 ,0 ,0 ,0 ,1 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0,
        0, 0, 1 ,0 ,1 ,0 ,1 ,1 ,1 ,0 ,1,0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1 ,1
       ,0 ,1 ,0 ,1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1 ,0 ,0 ,1 ,0, 1, 0, 1, 0, 1, 0, 1, 0 ,1, 1, 0,  1, 0 ,1 ,0 ,1 ,1 ,1 ,0, 1,
        0, 1, 1, 1, 0, 1, 0, 1 ,0 ,1 ,1, 1, 1 ,0 ,0, 1, 0, 1 ,1, 1, 1, 0, 0 ,1 ,0 ,0 ,0, 0
       ,1 ,1 ,0, 0, 1, 1 ,0, 0, 1, 1, 0, 0, 1,1 ,0 ,0 ,1 ,1, 0, 0, 1, 1 ,0 ,0 ,1, 0, 1, 0, 0, 0, 0
       ,0 ,1 ,0 ,1 ,0 ,1 ,1 ,1,0 ,1 ,0 ,1 ,0, 1 ,1, 1, 0, 1, 0, 1 ,0 ,1 ,1 ,1 ,0 ,1, 0, 1, 0, 1, 1, 1
       ,1 ,0 ,1, 0, 1, 1, 1,  0, 0, 1 ,0 ,1 ,0 ,1 ,1 ,1, 0 ,1 ,0, 1 ,0 ,1 ,1, 1, 0 ,1 ,0 ,1, 0, 1, 0 ,0
       ,0, 1, 0 ,0 ,0, 1 ,0, 0, 0, 1, 0, 0 ,0, 1 ,0, 0, 0, 1,0 ,0 ,0,1 ,0 ,0 ,0 ,1 ,0, 0, 1, 1, 1,1
       ,0, 1, 0, 1 ,0 ,1 ,1 ,1, 0 ,1 ,0 ,1 ,0, 1, 1, 1,0 ,1 ,0 ,1 ,0 ,1 ,1, 1 ,0, 1, 1 ,1, 0, 1, 1 ,0,
        0, 1 ,0, 1 ,0 ,1 ,1 ,1 ,0 ,1 ,1, 1,0 ,1, 1,1 ,0, 1, 0, 1 ,0 ,1 ,1 ,1, 0, 1 ,1 ,0, 1, 0, 1, 1, 0, 0 ,0, 0 ,1 } ,
            new int[]{ } ,new int[]{ },new int[]{ },new int[]{ }
        };
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public int[] GetArray(string input)
    {
        Debug.Log("Load Beat Map!!");
        if (Enum.TryParse(typeof(ELevel), input, out var enumValue) && Enum.IsDefined(typeof(ELevel), enumValue))
        {
            int index = (int)(ELevel)enumValue;
            return TestLevel[index];
        }
        return TestLevel[0];
    }
}
