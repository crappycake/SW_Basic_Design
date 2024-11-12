using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralButtonHandler : MonoBehaviour
{
    public void LoadSelectedScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void LoadTestScene(string _sceneName)
    {
        GameLevelManager.instance.SetCurrentLevel(_sceneName);
        Debug.Log(_sceneName);
        SceneManager.LoadScene(_sceneName);
    }
}
