using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireballSFXController : MonoBehaviour
{
    public ParticleSystem particleSystem;
    private Fireball fireballShoot;

    [SerializeField] private GameObject parrySFX;
    [SerializeField] private AudioSource parrySound;
    [SerializeField] private GameObject destroySFX;
    [SerializeField] private AudioSource destroySound;

    public float parrySFXOffset;

    Vector3 direction;

    void Awake()
    {
        fireballShoot = GetComponent<Fireball>();
    }

    void Start()
    {
        UpdateParticleDirection();
    }

    private void UpdateParticleDirection()
    {
        var velocityModule = particleSystem.velocityOverLifetime;
        direction = fireballShoot.startPos - fireballShoot.destinationPos;

        velocityModule.enabled = true;
        velocityModule.x = new ParticleSystem.MinMaxCurve(direction.x);
        velocityModule.y = new ParticleSystem.MinMaxCurve(direction.y);
    }

    public void CallFunctionsAfterParried()
    {
        TriggerParrySFX();
        FlipParticleDirectionAfterParry();
    }

    private void TriggerParrySFX()
    {
        parrySound.Play();
        Vector3 initPosition = new Vector3(transform.position.x - parrySFXOffset, transform.position.y);
        Instantiate(parrySFX, initPosition, transform.rotation);
    }

    private void FlipParticleDirectionAfterParry()
    {
        var velocityModule = particleSystem.velocityOverLifetime;
        direction = -direction;

        velocityModule.enabled = true;
        velocityModule.x = new ParticleSystem.MinMaxCurve(direction.x);
        velocityModule.y = new ParticleSystem.MinMaxCurve(direction.y);
    }

    public void TriggerDestorySFX()
    {
        Instantiate(destroySFX, transform.position, Quaternion.identity);

        GameObject tempAudioObject = new GameObject("TempAudio");
        AudioSource tempAudioSource = tempAudioObject.AddComponent<AudioSource>();
        tempAudioSource.clip = destroySound.clip;
        tempAudioSource.volume = destroySound.volume;
        tempAudioSource.pitch = destroySound.pitch;
        tempAudioSource.Play();

        Destroy(gameObject);
    }

}