using CartoonFX;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraSetting : MonoBehaviour
{
    public static CameraSetting instance;
    public bool cameraVibrate = true;
    public bool isShakeActive;
    public bool isShakePaused;
    
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

    private void Start()
    {
        isShakeActive = false;
    }

    public void ToggleCameraVibration()
    {
        cameraVibrate = !cameraVibrate;
        CFXR_Effect.GlobalDisableCameraShake = !cameraVibrate;
        Debug.Log(CFXR_Effect.GlobalDisableCameraShake);
    }

    public bool IsCameraVibrate()
    {
        return cameraVibrate;
    }
}
