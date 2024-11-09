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
            0, 0, 0, 0, 0, 0, 2, 1, 2, 0, 0, 0, 1, 2, 1, 2, 1, 0, 0, 0, 0, // 21
            0, 2, 1, 2, 0, 1, 2, 1, 0, 1, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 42
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 63
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 84
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 105
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 126
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 147
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 168
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 189
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 210
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 231
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 252
            0, 0, 0, 0, 0, 0, 0, 0, 0                                      // 260
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
