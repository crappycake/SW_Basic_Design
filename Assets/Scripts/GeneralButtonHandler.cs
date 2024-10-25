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
}
