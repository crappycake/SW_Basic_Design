using CartoonFX;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraSetting : MonoBehaviour
{
    public static CameraSetting instance;
    public static bool cameraVibrate = true;
    public TextMeshProUGUI cameraTMP;
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


    public void VibrateOnOff()
    {
        cameraVibrate = !cameraVibrate;
        if (cameraVibrate)
        {
            cameraTMP.text = "on";
            CFXR_Effect.GlobalDisableCameraShake = false;
        }
        else
        {
            cameraTMP.text = "off";
            CFXR_Effect.GlobalDisableCameraShake = true;
        }
    }

    public bool IsCameraVibrate()
    {
        return cameraVibrate;
    }
}
