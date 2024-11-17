using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralButtonHandler : MonoBehaviour
{
    public AudioSource clickAudio;

    public void LoadSelectedScene(string _sceneName)
    {
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
}
