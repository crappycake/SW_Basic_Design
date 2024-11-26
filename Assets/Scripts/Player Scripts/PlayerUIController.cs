using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

        Time.timeScale = 1f;
    }

    void Start()
    {

        playerHealthManager.OnDamageTaken += UpdateHealthUI;
        playerCollisionManager.OnGetStar.AddListener(UpdateStarUI);

        playerHealthManager.OnGameOver += GameOver;

        levelBeatManager.OnMusicEnded.AddListener(GameClear);
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
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        int progress = levelBeatManager.GetAudioSourceProgress();
        gameProgressText.text = $"ÁøÇàµµ: {(int)progress}%"; ;
    }
}
