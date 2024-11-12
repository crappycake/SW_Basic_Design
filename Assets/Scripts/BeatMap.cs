using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Windows;

public class BeatMap : MonoBehaviour
{
    public static BeatMap instance;

    int[][] chapter1 = new int[4][]
    {
        new int[] //1-1
        {
            0, 0, 0, 1, 1, 1, 2, 1, 2, 2, 2, 2, 1, 2, 1, 2, 1, 1, 1, 1, 1, // 21, 7
            1, 2, 1, 2, 2, 1, 2, 1, 1, 2, 1, 2, 2, 2, 1, 1, 2, 0, 1, 2, 1, // 42, 14
            2, 1, 1, 2, 1, 2, 1, 1, 2, 1, 2, 1, 1, 2, 1, 2, 1, 1, 2, 1, 2, // 63, 21
            1, 1, 2, 1, 2, 1, 2, 1, 2, 1, 0, 2, 1, 2, 1, 2, 2, 1, 2, 1, 2, // 84, 28
            2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 1, 2, 1, 2, 1, 2, 1, 2, 0, 1, 1, // 105
            2, 2, 1, 1, 2, 2, 1, 1, 2, 2, 1, 2, 1, 2, 1, 1, 2, 2, 1, 1, 2, // 126
            2, 1, 1, 2, 2, 0, 0, 1, 2, 1, 1, 2, 1, 2, 1, 1, 2, 1, 2, 2, 1, // 147
            2, 1, 2, 1, 2, 1, 2, 2, 1, 2, 1, 2, 2, 1, 2, 1, 0, 1, 2, 1, 1, // 168
            2, 1, 2, 1, 1, 2, 1, 2, 1, 2, 1, 2, 2, 1, 2, 1, 2, 1, 1, 2, 1, // 189
            2, 1, 2, 1, 2, 1, 1, 2, 1, 1, 2, 1, 1, 2, 1, 2, 1, 1, 1, 2, 1, // 210
            2, 1, 2, 1, 2, 1, 2, 2, 1, 1, 2, 1, 2, 1, 2, 2, 1, 1, 2, 1, 2, // 231
            1, 1, 2, 2, 1, 1, 2, 2, 1, 1, 2, 2, 1, 2, 1, 2, 2, 1, 1, 2, 1, // 252
            1, 2, 1, 1, 2, 1, 2, 1, 1                                      // 260
        },


        new int[] //1-2
        { //array len 170
            //0, 0, 0, 0, 1, 2, 0, 1, 0, 0, 1, 2, 2, 1, 1, 2, 0, 1, 1, 1, // 20
            //6, 1, 6, 1, 6, 0, 0, 2, 1, 2, 1, 2, 1, 2, 0, 0, 0, 6, 0, 1, // 20 40
            //0, 2, 0, 1, 0, 2, 0, 5, 0, 1, 0, 2, 0, 1, 0, 6, 0, 2, 0, 1, // 20 60
            //0, 2, 2, 5, 5, 5, 0, 1, 0, 2, 0, 1, 0, 6, 0, 2, 0, 1, 0, 2, // 20 80
            //0, 5, 0, 1, 0, 2, 0, 1, 0, 6, 0, 2, 0, 1, 0, 2, 0, 1, 6, 0, // 20 100
            //0, 0, 0, 2, 1, 2, 2, 2, 0, 1, 0, 2, 1, 2, 2, 2, 0, 1, 0, 2, // 20 120
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            //1, 2, 2, 2, 0, 0, 0, 1, 0, 2, 0, 0, 0, 0, 0, //15 135
            1, 6, 2, 5, 1, 6, 6, 6, 2, 5, 1, 6, 2, 5, 5, 5,
            1, 6, 2, 5, 1, 6, 6, 6, 2, 5, 1, 6, 2, 5, 5, 5, // 32 167
            1, 6, 6, 6, 6, 1, 1, 1, 1, 1, 2, 5, 5, 5, 5, 2, 2, 2, 2, 2, 1 // 10 170
        },

         new int[] //1-3
         {
            0,
            7, 0, 0, 0, 8, 0, 0, 0, 9, 0, 0, 0, 10, 0, 0, 0,
            7, 0, 0, 0, 8, 0, 0, 0, 9, 0, 0, 0, 10, 0, 0, 0,
            7, 0, 0, 0, 8, 0, 0, 0, 9, 0, 0, 0, 10, 0, 0, 0,
            7, 0, 0, 0, 8, 0, 0, 0, 9, 0, 0, 0, 10, 0, 0, 0,
            7, 0, 8, 0, 7, 0, 8, 0, 7, 0, 8, 0, 7, 0, 8, 0, 7, 0, 8, 0, 7, 0, 8, 0, 7, 0, 8, 0, 7, 0, 8, 0,
            7, 0, 8, 0, 7, 0, 8, 0, 7, 0, 8, 0, 7, 0, 8, 0, 7, 0, 8, 0, 7, 0, 8, 0, 7, 0, 8, 0, 7, 0, 8, 0,
            7, 0 , 0, 0,
            7, 0, 0, 0, 8, 0, 0, 0, 9, 0, 0, 10, 7,0,  0, 0, 7, 0, 0, 0, 8, 0, 0, 0, 9, 0, 0, 10, 7, 0, 0,
            10, 7,0, 0, 8, 9, 0, 0, 10, 7,0, 0, 8, 9, 0, 0, 10, 7,0, 0, 8, 9, 0, 0, 10, 7,0, 0, 8, 9, 0, 0,
            10, 7,0, 0, 8, 9, 0, 0, 10, 7,0, 0, 8, 9,
            7, 9, 0, 0, 8, 10, 0, 0, 7, 9, 0, 0, 8, 10, 0, 0, 7, 9, 0, 0, 8, 10, 0, 0, 7, 9, 0, 0, 8, 10, 0, 0, 7, 9, 0,
            7, 0, 8, 0, 7, 0, 8, 0, 7, 0, 8, 0, 7, 0, 8, 0, 7, 0, 8, 0, 7, 0, 8, 0, 7, 0, 8, 0, 7, 0, 8, 0,
            7, 0, 8, 0, 7, 0, 8, 0, 7, 0, 8, 0, 7, 0, 8, 0, 7, 0, 8, 0, 7, 0, 8, 0, 7, 0, 8, 0, 0, 0,
            7, 0, 0, 0, 8, 0, 0, 0, 9, 0, 0, 0, 10, 0, 0, 0,
            7, 0, 0, 0, 8, 0, 0, 0, 9, 0, 0, 0, 10, 0, 0, 0,}, //1-3
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
        string[] split = currentLevel.Split('-');

        if (int.TryParse(split[1], out int index))
        {
            return chapter1[index-1];
        }

        return chapter1[0];
    }
}
