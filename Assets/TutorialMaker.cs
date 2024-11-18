using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Tutorial
{
    [TextArea]
    public string dialogue;
}

public class TutorialMaker : MonoBehaviour
{
    [SerializeField] private Text Tutorial;

    public int count;
    //0~9 : stage 1
    //10~19 : stage 2
    //20~29 : stage 3

    [SerializeField] private Tutorial[] Tutorzip;

    //coroutine
    private bool iscor;

    void Start()
    {
        iscor = false;

        Tutorial.gameObject.SetActive(true);
        count = 0;
    }

    void Update()
    {
        if (!iscor)
        {
            Debug.Log(count);

            if (count == 0)
            {
                JustShowTutor();
                DoTutor(KeyCode.Space);
            }

            else
            {
                iscor = true;
                StartCoroutine(ShowTutor());
            }
        }
    }

    IEnumerator ShowTutor()
    {
        Tutorial.text = Tutorzip[count].dialogue;
        yield return new WaitForSeconds(2f);
        count++;
        iscor = false;
    }

    public void JustShowTutor()
    {
        Tutorial.text = Tutorzip[count].dialogue;
    }

    public void DoTutor(KeyCode flag)
    {
        if (Input.GetKeyDown(flag))
        {
            count++;
            iscor = false;
        }
    }
}
