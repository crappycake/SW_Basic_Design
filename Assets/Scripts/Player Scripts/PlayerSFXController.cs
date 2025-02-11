using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class Player_SFXController : MonoBehaviour
{
    //FLIP EFFECTS
    private TrailRenderer trailRenderer;
    private PlayerFlipController flipController;

    [Header("Damage UI SFX")]
    [SerializeField] GameObject brokenHeartSFX;
    [SerializeField] private Vector3[] brokenHeartPositions;

    [Header("Damage SFX")]
    [SerializeField] private CinemachineVirtualCamera mainCamera;
    private CinemachineBasicMultiChannelPerlin cinemachineNoise;
    [SerializeField] private float shakeAmplitude;
    [SerializeField] private float shakeFrequency;
    [SerializeField] private float shakeDuration;
    [SerializeField] private GameObject collisionVFX;
    [SerializeField] private AudioSource collisionSFX;
    private PlayerCollisionManager collisionManager;

    [Header("Damage Blink SFX")]
    [SerializeField] private float blinkDuration;
    [SerializeField] private float initialBlinkInterval; //starting blink interval (per second)
    [SerializeField] private float blinkSpeedIncrease; //how much blinking speeds up over time
    SpriteRenderer spriteRenderer;
    PlayerHealthManager healthManager;

    [Header("Flip SFX")]
    [SerializeField] private GameObject flipVFX;

    [Header("Status SFX")]
    [SerializeField] private GameObject webVFX;
    [Header("Sound Effects")]
    [SerializeField] private AudioSource flipSoundEffect;

    Vector3 originalCamPos;
    float camReturnSpeed = 5f;

    private float remainingShakeTime = 0f;
    private float currentAmplitude = 0f;
    private float currentFrequency = 0f;

    [HideInInspector] public bool canCameraReturn;

    void Awake()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthManager = GetComponent<PlayerHealthManager>();
        flipController = GetComponent<PlayerFlipController>();
        cinemachineNoise = mainCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        collisionManager = GetComponent<PlayerCollisionManager>();

        healthManager.OnDamageTaken += StartDMGCoroutine;
        flipController.OnFlipFunctionCalled += TriggerFlipSound;
        flipController.OnFlipEnded += TriggerFlipVFX;

        collisionManager.OnCollideWithSpike.AddListener(TriggerSpikeCollisionEffects);
        collisionManager.OnCollideWithTrap.AddListener(TriggerWebTrapCollisionEffects);

        canCameraReturn = true;
    }

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        ReturnCameraToOriginalPosition(); //return cam to original pos from shake displacement
        //TriggerFlipTrailRenderer();
    }

    void Initialize()
    {
        cinemachineNoise.m_AmplitudeGain = 0f;
        cinemachineNoise.m_FrequencyGain = 0f;

        originalCamPos = mainCamera.transform.position;
    }

    public void Changeoriginalpos(GameObject obj)
    {
        originalCamPos = obj.GetComponent<Transform>().position;
    }
    #region FLIP EFFECTS
    void TriggerFlipTrailRenderer()
    {
        if (!flipController.canFlip) trailRenderer.emitting = true;
        else trailRenderer.emitting = false;
    }

    void TriggerFlipSound()
    {
        flipSoundEffect.Play();
    }

    void TriggerFlipVFX()
    {
        GameObject spawnedVFX;

        Vector3 spawnPosition;
        if (flipController.isFliped)
        {
            spawnPosition = gameObject.transform.position;
            spawnPosition.y += 0.5f;
        }
        else
        {
            spawnPosition = gameObject.transform.position;
            spawnPosition.y -= 0.5f;
        }

        // Instantiate the VFX
        spawnedVFX = Instantiate(flipVFX, spawnPosition, Quaternion.identity);

        // Adjust the rotation of the particle system
        ParticleSystem.MainModule mainModule = spawnedVFX.GetComponent<ParticleSystem>().main;

        if (flipController.isFliped)
        {
            mainModule.startRotation = 0f; // Upright direction
        }
        else
        {
            mainModule.startRotation = Mathf.PI; // Flipped direction (180 degrees in radians)
        }
    }
    #endregion

    #region DMG EFFECTS
    void ReturnCameraToOriginalPosition()
    {
        if (!canCameraReturn) return;

        float threshold = 0.1f;
        if (Vector3.Distance(mainCamera.transform.position, originalCamPos) > threshold)
        {
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, originalCamPos, camReturnSpeed * Time.unscaledDeltaTime);
            mainCamera.transform.rotation = Quaternion.identity;
        }
    }

    void StartDMGCoroutine()
    {
        if (healthManager.currentHealth <= 0) return; // do not trigger SFX if player is dead

        TriggerBrokenHeartUI();
        StartCoroutine(BlinkAfterTakingDamage());
        StartCoroutine(TriggerCameraShakeAfterDMG());
    }

    void TriggerBrokenHeartUI()
    {
        if (brokenHeartSFX != null)
        {
            Instantiate(brokenHeartSFX, brokenHeartPositions[healthManager.currentHealth], Quaternion.identity);
        }
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
        if (CameraSetting.instance.IsCameraVibrate() == false) yield break;

        CameraSetting.instance.isShakeActive = true;
        remainingShakeTime = shakeDuration;
        currentAmplitude = shakeAmplitude;
        currentFrequency = shakeFrequency;

        cinemachineNoise.m_AmplitudeGain = currentAmplitude;
        cinemachineNoise.m_FrequencyGain = currentFrequency;

        while (remainingShakeTime > 0f)
        {
            if (!CameraSetting.instance.isShakePaused)
            {
                remainingShakeTime -= Time.unscaledDeltaTime;
            }
            yield return null;
        }

        StopShake();
    }

    public void PauseShake()
    {
        if (CameraSetting.instance.isShakeActive && !CameraSetting.instance.isShakePaused)
        {
            CameraSetting.instance.isShakePaused = true;
            cinemachineNoise.m_AmplitudeGain = 0f;
            cinemachineNoise.m_FrequencyGain = 0f;
        }
    }

    public void ResumeShake()
    {
        if (CameraSetting.instance.isShakeActive && CameraSetting.instance.isShakePaused)
        {
            CameraSetting.instance.isShakePaused = false;
            cinemachineNoise.m_AmplitudeGain = currentAmplitude;
            cinemachineNoise.m_FrequencyGain = currentFrequency;
        }
    }
    public void StopShake()
    {
        CameraSetting.instance.isShakeActive = false;
        CameraSetting.instance.isShakePaused = false;
        remainingShakeTime = 0f;

        cinemachineNoise.m_AmplitudeGain = 0f;
        cinemachineNoise.m_FrequencyGain = 0f;
    }


    private void TriggerSpikeCollisionEffects()
    {
        if (!healthManager.canTakeDamage) return;

        collisionSFX.Play();
        Vector3 offsetPos = new Vector3(gameObject.transform.position.x + 0.2f, gameObject.transform.position.y);
        Instantiate(collisionVFX, offsetPos, quaternion.identity);
    }
    #endregion

    public void TriggerWebTrapCollisionEffects()
    {
        StartCoroutine(WebTrapEffect());
    }
    
    IEnumerator WebTrapEffect()
    {
        GameObject VFX = Instantiate(webVFX, gameObject.transform);
        Color c = VFX.GetComponent<SpriteRenderer>().color;
        VFX.transform.localScale = new Vector3(0, 0, 0);
        for(int i = 0; i < 3; i++)
        {
            VFX.transform.localScale += gameObject.transform.localScale * 0.5f;
            yield return new WaitForSeconds(0.1f);
        }

        for(float i = 0; i < 5; i++)
        {
            c.a = 1 - 0.2f * i;
            VFX.GetComponent<SpriteRenderer>().color = c;
            VFX.transform.localScale -= gameObject.transform.localScale * 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(VFX);
    }
}