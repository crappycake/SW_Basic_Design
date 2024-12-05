using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [Header("Sound")]
    public AudioMixer SFXMixer;
    public AudioMixer BGMMixer;

    [SerializeField] private Slider SFXSlider;
    [SerializeField] private Slider BGMSlider;

    [Header("Speed")]
    public TextMeshProUGUI speedButton;

    [Header("Camera")]
    public TextMeshProUGUI cameraTMP;

    private void Start()
    {
        float sfxVolume, bgmVolume;
        SFXMixer.GetFloat("SFXVolume", out sfxVolume);
        BGMMixer.GetFloat("BGMVolume", out bgmVolume);

        SFXSlider.value = Mathf.InverseLerp(-10f, 10f, sfxVolume);
        BGMSlider.value = Mathf.InverseLerp(-20f, 10f, bgmVolume);

        SFXSlider.onValueChanged.AddListener(UpdateSFXVolumeUI);
        BGMSlider.onValueChanged.AddListener(UpdateBGMVolumeUI);
    }

    public void UpdateSpeedSettingUI()
    {
        SpeedSetting.instance.ChangeSpeedMultipler();
        string text = "X" + SpeedSetting.instance.multiplerUIText;
        speedButton.SetText(text);
    }

    public void UpdateSFXVolumeUI(float value)
    {
        float dB = Mathf.Lerp(-10f, 10f, value);
        SFXMixer.SetFloat("SFXVolume", dB);

    }

    public void UpdateBGMVolumeUI(float value)
    {
        float dB = Mathf.Lerp(-20f, 10f, value);
        BGMMixer.SetFloat("BGMVolume", dB);
    }

    public void UpdateCameraSettingUI()
    {
        CameraSetting.instance.ToggleCameraVibration();

        if (CameraSetting.instance.cameraVibrate) cameraTMP.text = "on";
        else cameraTMP.text = "off";
    }
}
