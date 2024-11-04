using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSetting : MonoBehaviour
{
    public static SpeedSetting instance;

    [SerializeField] private float rotateSpeed = 150;
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

    public float RotateSpeed()
    {
        return rotateSpeed;
    }
}
