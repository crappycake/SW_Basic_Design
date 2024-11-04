using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireballSFXController : MonoBehaviour
{
    public ParticleSystem particleSystem;
    private FireballShoot fireballShoot;
    Vector3 direction;

    void Awake()
    {
        fireballShoot = GetComponent<FireballShoot>();
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

    public void FlipParticleDirectionAfterParry()
    {
        var velocityModule = particleSystem.velocityOverLifetime;
        direction = -direction;

        velocityModule.enabled = true;
        velocityModule.x = new ParticleSystem.MinMaxCurve(direction.x);
        velocityModule.y = new ParticleSystem.MinMaxCurve(direction.y);
    }
}