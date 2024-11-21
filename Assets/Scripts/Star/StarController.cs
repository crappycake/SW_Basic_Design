using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    private AudioSource starSoundEffect;

    private void Awake()
    {
        starSoundEffect = GetComponentInChildren<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Despawn Position") || collider.CompareTag("Player")) 
        {
            GameObject tempAudioObject = new GameObject("TempAudio");
            AudioSource tempAudioSource = tempAudioObject.AddComponent<AudioSource>();
            tempAudioSource.clip = starSoundEffect.clip;
            tempAudioSource.volume = starSoundEffect.volume;
            tempAudioSource.pitch = starSoundEffect.pitch;
            tempAudioSource.Play();

            Destroy(gameObject);
        }
    }
}
