using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] Image[] playerHealthImages;
    [SerializeField] Image[] playerStarImages;
    [SerializeField] GameObject gameClearPanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject perfectClearText;
    [SerializeField] TextMeshProUGUI gameProgressText;

    PlayerHealthManager playerHealthManager;
    PlayerCollisionManager playerCollisionManager;
    LevelBeatManager levelBeatManager;
    LevelProgressManager levelProgressManager;

    void Awake()
    {
        playerHealthManager = GetComponent<PlayerHealthManager>();
        playerCollisionManager = GetComponent<PlayerCollisionManager>();
        levelBeatManager = FindObjectOfType<LevelBeatManager>();
        levelProgressManager = FindObjectOfType<LevelProgressManager>();

        playerHealthManager.OnDamageTaken += UpdateHealthUI;
        playerCollisionManager.OnGetStar.AddListener(UpdateStarUI);

        playerHealthManager.OnGameOver += GameOver;

        levelBeatManager.OnMusicEnded.AddListener(GameClear);

        Time.timeScale = 1f;
    }

    void UpdateHealthUI()
    {
        int currentHealth = playerHealthManager.currentHealth;
        for (int i = 0; i < playerHealthImages.Length; ++i)
        {
                playerHealthImages[i].enabled = i < currentHealth;
        }
    }

    void UpdateStarUI()
    {
        int currentStar = levelProgressManager.numberOfStars;

        for (int i = 0; i < playerStarImages.Length; ++i)
        {
            if (i < currentStar)
            {
                playerStarImages[i].enabled = true;
                StartCoroutine(AnimateStar(playerStarImages[i].rectTransform));
            }
            else
            {
                playerStarImages[i].enabled = false;
            }
        }
    }

    private IEnumerator AnimateStar(RectTransform starRectTransform)
    {
        float duration = 0.5f; 
        float elapsed = 0f;
        Vector3 originalScale = Vector3.one;
        Vector3 startScale = Vector3.zero;

        starRectTransform.localScale = startScale; 

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            starRectTransform.localScale = Vector3.Lerp(startScale, originalScale, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }

        starRectTransform.localScale = originalScale;
    }

    void GameClear()
    {
        Time.timeScale = 0f;
        gameClearPanel.SetActive(true);
        
        if (GameLevelManager.instance.IsCurrentLevelPerfectClear())
        {
            perfectClearText.SetActive(true);
        }
    }

    void GameOver()
    {
        int progress = levelBeatManager.GetAudioSourceProgress();
        Debug.Log("progress: " + progress);

        CinemachineVirtualCamera virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        if (virtualCamera != null)
        {
            virtualCamera.Follow = transform;
            virtualCamera.LookAt = transform;
        }

        Time.timeScale = 0f;
        StartCoroutine(GameOverCoroutine(progress, virtualCamera));
    }

    IEnumerator GameOverCoroutine(int _progress, CinemachineVirtualCamera virtualCamera)
    {
        Debug.Log("Coroutine called!");
        float zoomDuration = 1.5f;
        float elapsed = 0f;

        if (virtualCamera != null && virtualCamera.m_Lens.Orthographic)
        {
            float initialSize = virtualCamera.m_Lens.OrthographicSize;
            float targetSize = 3f; 

            while (elapsed < zoomDuration)
            {
                elapsed += Time.unscaledDeltaTime;
                float t = elapsed / zoomDuration;

                virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(initialSize, targetSize, Mathf.SmoothStep(0f, 1f, t));
                yield return null;
            }

            virtualCamera.m_Lens.OrthographicSize = targetSize;
        }

        yield return new WaitForSecondsRealtime(1.5f);

        gameOverPanel.SetActive(true);
        gameProgressText.text = $"ÁøÇàµµ: {_progress}%";
    }
}
