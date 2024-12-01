using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMap : MonoBehaviour
{
    public static BossMap instance;

    int[] chapter1 = new int[]
    {
        22, 22, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0,
        0, 11, 0, 22, 22, 0, 3, 0, 0, 0, 11, 0, 3, 0, 0, 0, 11, 0, 0, 0, 0, 1, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0,
        2, 0, 0, 
        12, 0, 0, 0, 3, 0, 0, 0,
        12, 0, 0, 0, 2, 0, 0, 0,
        12, 0, 0, 0, 3, 0, 0, 0,
        12, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 22, 21, 0, 0, 0, 0, 0, 0, 0, 0, 0,0, 0, 0, 0, 0, 0, 0, 0, 
        0, 0, 0, 0, 0, 0, 0, 21, 0, 0, 0, 0, 0, 0, 0, 21, 0, 0, 0, 0, 0, 0, 0, 21, 0, 0, 0, 0, 0, 0, 0, 21, 0, 0,
         0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        2, 0, 0, 21, 3, 0, 0, 22, 2, 0, 0, 21, 3, 0, 0, 22, 2, 0, 0, 21, 3, 0, 0, 22, 2, 0, 0, 21, 3, 0, 0, 22,
        3, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0,
        1, 0, 0, 0, 0, 21, 0, 0, 0, 21, 0, 0, 0, 21, 22, 21, 22, 21, 0, 0, 0, 21,0, 0, 0, 21,0, 0, 0, 21,22, 21, 22, 21,
        0, 0, 0, 21, 0, 0, 0, 21, 0, 0, 0, 21, 22, 21, 22, 21, 0, 0, 0, 21, 0, 0, 0, 21, 0, 0, 0, 21, 3, 0, 0, 2, 0, 0, 1, 0, 0,

    };

    // Update is called once per frame
    void Update()
    {

    }
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

    public int[] GetBossMap()
    {
        string currentLevel = GameLevelManager.instance.GetCurrentLevel();
        string[] split = currentLevel.Split('-');
        if (int.TryParse(split[1], out int index))
        {
            if (index == 4)
                return chapter1;
        }
        return null;
    }
}
