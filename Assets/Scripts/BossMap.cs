using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMap : MonoBehaviour
{
    public static BossMap instance;

    int[] chapter1 = new int[]
    {
        0, 0, 5, 0
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
