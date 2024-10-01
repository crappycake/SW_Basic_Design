using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.U2D;

public class Player_SFXController : MonoBehaviour
{

    [Header("Flip SFX")]
    private TrailRenderer trailRenderer;
    private Player_FlipController flipController;

    [Header("Damage Shake SFX")]
    [SerializeField] private CinemachineVirtualCamera mainCamera;
    private CinemachineBasicMultiChannelPerlin cinemachineNoise;
    [SerializeField] private float shakeAmplitude;
    [SerializeField] private float shakeFrequency;
    [SerializeField] private float shakeDuration;

    [Header("Damage Blink SFX")]
    [SerializeField] private float blinkDuration;
    [SerializeField] private float initialBlinkInterval; //starting blink interval (per second)
    [SerializeField] private float blinkSpeedIncrease; //how much blinking speeds up over time

    SpriteRenderer spriteRenderer;
    Player_HealthManager healthManager;

    void Awake()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthManager = GetComponent<Player_HealthManager>();
        flipController = GetComponent<Player_FlipController>();
        cinemachineNoise = mainCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        healthManager.OnDamageTaken += StartDMGCoroutine;
    }

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        TriggerFlipTrailRenderer();
    }

    void Initialize()
    {
        cinemachineNoise.m_AmplitudeGain = 0f;
        cinemachineNoise.m_FrequencyGain = 0f;
    }

    void TriggerFlipTrailRenderer()
    {
        if(!flipController.canFlip) trailRenderer.emitting = true;
        else trailRenderer.emitting = false;
    }

    void StartDMGCoroutine()
    {
        if (healthManager.currentHealth <= 0) return; // do not trigger SFX if player is dead
        StartCoroutine(BlinkAfterTakingDamage());
        StartCoroutine(TriggerCameraShakeAfterDMG());
    }

    IEnumerator BlinkAfterTakingDamage()
    {
        float currentBlinkInterval = initialBlinkInterval;
        float endTime = Time.time + blinkDuration;

        //start blinking
        while (Time.time < endTime)
        {
            SetSpriteAlpha(0f); //visible
            yield return new WaitForSeconds(currentBlinkInterval);
            SetSpriteAlpha(1f); // invisible
            yield return new WaitForSeconds(currentBlinkInterval);

            // reduce blinking interval
            currentBlinkInterval = Mathf.Max(0.05f, currentBlinkInterval - blinkSpeedIncrease);
        }
        SetSpriteAlpha(1f);
    }

    void SetSpriteAlpha(float alpha)
    {
        Color color = spriteRenderer.color;
        color.a = alpha;
        spriteRenderer.color = color;
    }

    IEnumerator TriggerCameraShakeAfterDMG()
    {
        cinemachineNoise.m_AmplitudeGain = 5f;
        cinemachineNoise.m_FrequencyGain = 5f;

        yield return new WaitForSeconds(shakeDuration);

        cinemachineNoise.m_AmplitudeGain = 0f;
        cinemachineNoise.m_FrequencyGain = 0f;
    }
}
