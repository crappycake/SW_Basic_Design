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
            0, 0, 0, 1, 1, 1, 2, 1, 2, 2, 2, 2, 1, 2, 1, 2, 1, 1, 1, 1, 1, // 21
            1, 2, 1, 2, 2, 1, 2, 1, 1, 2, 1, 2, 2, 2, 1, 1, 16, 0, 1, 2, 1, // 42
            2, 1, 1, 2, 1, 2, 1, 1, 2, 1, 2, 1, 1, 2, 1, 2, 1, 1, 2, 1, 2, // 63
            1, 1, 2, 1, 2, 1, 2, 1, 2, 1, 0, 2, 1, 2, 1, 2, 2, 1, 2, 1, 2, // 84
            2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 1, 2, 1, 2, 1, 2, 1, 2, 2, 15, 1, // 105
            2, 2, 1, 1, 2, 2, 1, 1, 2, 2, 1, 2, 1, 2, 1, 1, 2, 2, 1, 1, 2, // 126
            2, 1, 1, 2, 2, 0, 0, 1, 2, 1, 1, 2, 1, 2, 1, 1, 2, 1, 2, 2, 1, // 147
            2, 1, 2, 1, 2, 1, 2, 2, 1, 2, 1, 2, 2, 1, 2, 1, 0, 1, 16, 1, 1, // 168
            2, 1, 2, 1, 1, 2, 1, 2, 1, 2, 1, 2, 2, 1, 2, 1, 2, 1, 1, 2, 1, // 189
            2, 1, 2, 1, 2, 1, 1, 2, 1, 1, 2, 1, 1, 2, 1, 2, 1, 1, 1, 2, 1, // 210
            2, 1, 2, 1, 2, 1, 2, 2, 1, 1, 2, 1, 2, 1, 2, 2, 1, 1, 2, 1, 2, // 231
            1, 1, 2, 2, 1, 1, 2, 2, 1, 1, 2, 2, 1, 2, 1, 2, 2, 1, 1, 2, 1, // 252
            1, 2, 1, 1, 2, 1, 2, 1, 1                                      // 260
        },

         new int[] //1-3
         {
             //1, 1, 2, 2, 1, 9, 0, 0, 2,0, 0,  1, 1, 2, 2, 1, 9, 0, 0, 2,
            //10, 0,1, 2,1, 9, 0, 2, 1, 2,  10, 0,1, 2,1, 9, 0, 2, 1, 2,  10, 0,1, 2,1, 9, 0, 2, 1, 2,
             
             //2, 2, 1, 1, 2,2, 1, 1, 2, 2, 1, 2, 2, 2, 1, 1, 2,2, 1, 1, 2, 2, 1, 2, 2, 2, 1, 1, 2,2, 1, 1, 2, 2, 1, 2,
            7, 0, 0, 0, 8, 0, 0, 0, 9, 0, 0, 0, 10, 0, 0, 0,
            7, 0, 0, 0, 8, 0, 0, 0, 9, 0, 0, 0, 10, 0, 0, 0,
            7, 0, 1,

            2, 1, 1, 2, 2, 1, 1,
            2, 11, 1, 8, 0, 0, 1,
            2, 11, 1, 10, 0, 0, 1,
            2, 11, 1, 8, 0, 0, 1,
            2, 11, 1, 10, 0, 0, 1,
            2, 11, 1, 8, 0, 0, 1,
            2, 11, 1, 10, 0, 0, 1,
            2, 11, 1, 8, 0, 0, 1,
            2, 11, 1, 10, 0, 0, 1,
            2, 11, 1, 8, 0, 0, 1,
            2, 11, 1, 10, 0, 0, 1,
            2, 11, 1, 8, 0, 0, 1,
            2, 11, 1, 10, 0, 0, 1,
            2, 1,
             10, 7,0, 2, 9, 8, 0, 1, 10, 7,0, 2, 9, 8, 0, 1, 10, 7,0, 2, 9, 8, 0, 1,
             10, 7,0, 2, 9, 8, 0, 1, 10, 7,0, 2,

             1, 1, 2, 2, 1,1, 12, 1, 2, 2, 1, 1, 2, 2, 11, 2,
             1, 1, 2, 2, 1,1, 12, 1, 2, 2, 1, 1, 2, 2, 11, 2,
             1, 1, 2, 2, 1,1, 12, 1, 2, 2, 1, 1, 2, 2, 11, 2,
             1, 1, 2, 2, 1, 1, 12, 1, 2, 2, 1, 1, 2, 2, 11, 2,

             1, 2, 1, 2, 11, 2, 11, 2, 1, 2, 1, 2, 1, 12, 1, 12,

            10, 0,1, 2,1, 2, 1, 10, 0,1, 2,1, 2, 1, 10, 0,1, 2,1, 2, 1,
            10, 0,1, 2,1, 2, 1, 10, 0,1, 2,1, 2, 1, 10, 0,1, 2,1, 2, 1,
            10, 0,1, 2,1, 2, 1, 10, 0,1, 2,1, 2, 1, 10, 0,1, 2,1, 2, 1,
            2, 1, 2, 1, 10, 7, 0, 0, 2, 1, 2, 1, 2, 8, 9, 0, 0,
            2, 1, 2, 1, 10, 7, 0, 0, 2, 1, 2, 1, 2, 9, 8, 0, 0, 1, 2, 1, 2, 1, 
             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,

             /*
             8, 0, 0, 0, 9, 0, 0, 0, 10, 0, 0, 0,
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
            7, 0, 0, 0, 8, 0, 0, 0, 9, 0, 0, 0, 10, 0, 0, 0,*/
         }, //1-3

         new int[] //1-3 Fireball
        { //array len 170
            
            0, 0, 0, 0, 1, 2, 0, 1, 0, 0, 1, 2, 2, 1, 1, 2, 0, 1, 1, 1, // 20
            6, 1, 6, 1, 6, 0, 0, 2, 0, 1, 0, 2, 0, 1, 0, 0, 0, 6, 0, 1, // 20
            0, 2, 1, 0, 2, 0, 5, 0, 1, 0, 2, 0, 1, 0, 6, 0, 2, 0, 1,
            0, 2, 2, 5, 5, 5, 0, 1, 0, 2, 0, 1, 0, 6, 0, 2, 0, 1, 0, 2, // 20
            0, 5, 0, 1, 0, 2, 0, 1, 0, 6, 0, 2, 0, 1, 0, 2, 1, 2, 0, 0, // 20
            0, 0, 0, 2, 1, 2, 2, 2, 0, 1, 0, 2, 1, 2, 2, 2, 0, 1, 0, 2, // 20
            1, 2, 2, 2, 0, 0, 0, 1, 2, 0, 0, 0, 0,

            1, 6, 2, 5, 1, 6, 6, 6, 2, 5, 1, 6, 2, 5, 5, 5,
            1, 6, 2, 5, 1, 6, 6, 6, 2, 5, 1, 6, 2, 5, 5, 5,

            1, 1, 6, 6, 6, 0, 2, 2, 2, 2, 5, 5, 5, 0, 1, 1, 1,
            1, 6, 6, 6, 0, 2, 2, 2, 2, 5, 5, 5, 0, 1, 1, 1, 1,

            0, 1, 2, 1, 2, 0, 0, 1, 2, 1, 2, 0,
            1, 1, 2, 2, 1, 1, 2, 2, 1, 1,
            2, 1, 1, 1, 6
        },

        new int[]
        {
         0, 0, 0, 2, 2, 1, 1, 2, 2, 1, 1, 2, 2, 1, 1, 2, 1, 2, 2, 1, 1, 2, 2, 1, 1, 2, 2, 1, 1, 2, 2,
         0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 1, 0, 1, 1, 2, 2, 1, 0, 1, 2, 2, 2, 1, 1, 2, 2, 1, 1, 2, 2, 9, 0, 2, 1,
         2, 1, 0, 0, 0,
         2, 1, 2, 2, 1, 1, 2, 0,
         1, 2, 1, 1, 2, 2, 1, 0,
         2, 1, 2, 2, 1, 1, 2, 0,
         1, 2, 1, 1, 0, 
         2, 2, 1, 1, 2, 2, 1, 1, 2, 2, 1, 1, 2, 1, 2, 1, 1, 2, 2, 1, 1, 2, 2, 1, 1, 2, 2, 1, 1, 2, 2,
         1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1,2, 2, 2, 0, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1,2, 2, 2, 0,0,
         1, 1, 2, 2, 1, 1, 2, 2, 1, 1, 2, 2, 1, 2, 1, 1, 2, 2, 1, 1, 2, 2, 1, 1, 2, 2, 1, 1, 2, 2, 2, 1,
         2, 1, 2, 0, 1, 2, 1, 0, 2, 1, 2, 0, 1, 2, 1, 0, 2, 1, 2, 0, 1, 2, 1, 0, 2, 1, 2, 0, 1, 2, 1, 0,
        0, 0, 10, 0, 1, 2, 7, 0, 2, 1, 8, 0, 1, 2, 9, 1, 2, 0, 10, 0, 1, 2, 7, 0, 2, 1, 8, 0, 1, 2,
        0, 0, 2, 1, 2, 1, 2, 1, 2, 1,2, 1, 2, 1, 2, 1, 2, 1,2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1,
        }
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

    public int[] GetBeatMap()
    {
        string currentLevel = GameLevelManager.instance.GetCurrentLevel();
        string[] split = currentLevel.Split('-');

        if (int.TryParse(split[1], out int index))
        {
            return chapter1[index-1];
        }

        return chapter1[0];
    }
}
