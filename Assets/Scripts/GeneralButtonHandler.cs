using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralButtonHandler : MonoBehaviour
{
    private AudioSource clickAudio;

    private void Awake()
    {
        clickAudio = GetComponent<AudioSource>();
    }
    public void RestartScene()
    {
        StartCoroutine(WaitForClickSound(GameLevelManager.instance.GetCurrentLevel()));
    }

    public void LoadSelectedScene(string _sceneName)
    {
        StartCoroutine(WaitForClickSound(_sceneName));
    }

    public void LoadStageScene(string _sceneName)
    {
        int progress = GameLevelManager.instance.GetSelectedLevelProgress(_sceneName);

        if (progress == 0)
        {
            _sceneName += "T";
        }

        StartCoroutine(WaitForClickSound(_sceneName));
    }

    IEnumerator WaitForClickSound(string _sceneName)
    {
        yield return new WaitForSecondsRealtime(clickAudio.clip.length);

        SceneManager.LoadScene(_sceneName);
    }

    public void LoadTestScene(string _sceneName)
    {
        GameLevelManager.instance.SetCurrentLevel(_sceneName);
        Debug.Log(_sceneName);
        SceneManager.LoadScene(_sceneName);
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

#if UNITY_EDITOR

    public void Test1()
    {
        GameLevelManager.instance.Test1();
    }

    public void Test2()
    {
        GameLevelManager.instance.Test2();
    }
#endif
}
