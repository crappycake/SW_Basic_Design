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

    int[][] level1 = new int[4][]
    {
        new int[] //1-1
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 20
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 40
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 60
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 80
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 100
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 120
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 140
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 160
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 180
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 200
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 220
            0, 0, 0, 0, 0, 0 // 226
        },


        new int[] { },
        new int[] { },
        new int[] { },
    };

    int[][] TestLevel = new int[5][]
        {
             new int[]{ 0, 1, 0 ,2 ,0 ,1, 0, 2 ,0 ,1 ,0 ,2 ,5, 2 ,5 ,2 ,1 ,2 ,0 ,7 ,0 ,0 ,6 ,5 ,0 ,0 ,0 ,0 ,0 ,0 ,0,
        0, 0, 7 ,0 ,1 ,0 ,2 ,1 ,2 ,0 ,1,0, 2, 1, 6, 1, 6, 1, 2, 0, 1, 0, 2, 1, 2, 0, 1, 0, 2, 0, 1, 2, 1 ,10
       ,0 ,1 ,0 ,2, 0, 1, 0, 2, 0, 1, 0, 2, 0, 1, 2 ,1, 2, 1 ,0, 2, 0, 1, 0, 2, 0, 1, 0 ,2, 1, 0,  2, 9 ,1 ,0 ,2 ,1 ,2 ,0, 1,
        0, 2, 1, 2, 0, 1, 0, 2 ,0 ,1, 2, 1, 2, 0 ,0, 1, 0, 2 ,1, 2, 1, 0, 0 ,1 ,0 ,0 ,0, 0
       ,2 ,1 ,0, 0, 2, 1 ,0, 0, 2, 1, 0, 0, 2, 1, 0, 0, 2, 1, 0, 0, 2, 1 ,0 ,0 ,2, 0, 1, 0, 0, 0, 0
       ,0 ,2 ,0 ,1 ,0 ,1 ,1 ,1, 0, 1, 0, 1, 0, 1 ,1, 1, 0, 1, 0, 1 ,0 ,1 ,1 ,1 ,0 ,1, 0, 1, 0, 1, 1, 1
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

    public int[] GetArray()
    {
        Debug.Log("Load Beat Map!!");

        string currentLevel = GameLevelManager.instance.GetCurrentLevel();

        if (Enum.TryParse(typeof(ELevel), currentLevel.Replace("-", "_"), out var enumValue) && Enum.IsDefined(typeof(ELevel), enumValue))
        {
            int index = (int)(ELevel)enumValue;
            return level1[index];
        }

        return level1[0];
    }
}
