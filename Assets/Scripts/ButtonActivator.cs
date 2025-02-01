using UnityEngine;
using UnityEngine.UI;

public class ButtonActivator : MonoBehaviour
{
    public Button[] buttons;
    public GameObject[] objectsToActivate;
    public GameObject[] objectsToDeactivate; 
    public AudioSource audioSource;
    public AudioClip audioClip;

    void Start()
    {
        if (buttons.Length != objectsToActivate.Length)
        {
            Debug.LogError("버튼 수와 활성화할 오브젝트 수가 다릅니다!");
            return;
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => 
            {
                ActivateObject(index);
                DeactivateObject(index);
                audioSource.PlayOneShot(audioClip);
            });
        }
    }

    void ActivateObject(int index)
    {
        objectsToActivate[index].SetActive(true);
    }
    void DeactivateObject(int index)
    {
        objectsToDeactivate[index].SetActive(false);
    }
}