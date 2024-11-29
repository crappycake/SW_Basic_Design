using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public AudioMixer SFXMixer;
    public AudioMixer BGMMixer;

    [SerializeField] private Slider SFXSlider;
    [SerializeField] private Slider BGMSlider;

    private void Start()
    {
        float sfxVolume, bgmVolume;
        SFXMixer.GetFloat("SFXVolume", out sfxVolume);
        BGMMixer.GetFloat("BGMVolume", out bgmVolume);

        SFXSlider.value = Mathf.InverseLerp(0f, 20f, sfxVolume); 
        BGMSlider.value = Mathf.InverseLerp(-80f, 0f, bgmVolume);

        SFXSlider.onValueChanged.AddListener(ChangeSFXVolume);
        BGMSlider.onValueChanged.AddListener(ChangeBGMVolume);
    }

    private void ChangeSFXVolume(float value)
    {
        float dB = Mathf.Lerp(0f, 20f, value); 
        SFXMixer.SetFloat("SFXVolume", dB);
    }

    private void ChangeBGMVolume(float value)
    {
        float dB = Mathf.Lerp(-80f, 0f, value);
        BGMMixer.SetFloat("BGMVolume", dB);
    }
}
