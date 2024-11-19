using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Windows;
public class SFXMap : MonoBehaviour
{
    public static SFXMap instance;

    int[][] chapter1 = new int[4][]
    {
        new int[] //1-1
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 21
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, // 42
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 63
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 84
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 105
            1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 126
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 147
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, // 168
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 189
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 210
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 231
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 252
            0, 0, 0, 0, 0                                      // 260
        },


        new int[] //1-2
        { //array len 170
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 20
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 20
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 20
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 20
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, // 20
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,

            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,

            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,

            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0
        },


         new int[] //1-3
         {
             //1, 1, 2, 2, 1, 9, 0, 0, 2,0, 0,  1, 1, 2, 2, 1, 9, 0, 0, 2,
            //10, 0,1, 2,1, 9, 0, 2, 1, 2,  10, 0,1, 2,1, 9, 0, 2, 1, 2,  10, 0,1, 2,1, 9, 0, 2, 1, 2,
             
             //2, 2, 1, 1, 2,2, 1, 1, 2, 2, 1, 2, 2, 2, 1, 1, 2,2, 1, 1, 2, 2, 1, 2, 2, 2, 1, 1, 2,2, 1, 1, 2, 2, 1, 2,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 8, 0, 0, 0, 9, 0, 0, 0, 10, 0, 0, 0,
            0, 0, 0,

            0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0,
            0, 0,
             0, 0, 0, 0, 0, 8, 0, 0, 10, 7,0, 2, 9, 8, 0, 0, 10, 7,0, 2, 9, 8, 0, 0,
             10, 7,0, 2, 9, 8, 0, 0, 10, 7,0, 2,

             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,

             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,

             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
             0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
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
        new int[] { 0, 0, 0, 0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0,},
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

    public int[] GetSFXMap()
    {
        Debug.Log("Load Beat Map!!");

        string currentLevel = GameLevelManager.instance.GetCurrentLevel();
        string[] split = currentLevel.Split('-');

        if (int.TryParse(split[1], out int index))
        {
            return chapter1[index - 1];
        }

        return chapter1[0];
    }
}
