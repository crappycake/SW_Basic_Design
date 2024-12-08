using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
//Dialog
[System.Serializable]
public class Dialogue
{
    [TextArea]
    public string dialugue;
    public string name;
    public Sprite standing;

    public UnityEvent Effect;
}

public class DialogueMaker : MonoBehaviour
{
    public GameObject player;
    public GameObject tutorial;

    //Dialogue
    [SerializeField] private Image standing;
    [SerializeField] private Image dialogueBox;
    [SerializeField] private Text name;
    [SerializeField] private Text txt;
    [SerializeField] private bool istutorial;
    private bool isDialogue = false;

    private int count = 0;

    [SerializeField] private Dialogue[] dialoguezip;

    //Dialog Show First
    public void ShowDialogue()
    {
        player.GetComponent<PlayerFlipController>().enabled = false;
        OnOffDialogue(true);
        count = 0;
        NextDialogue();
    }

    //Dialog ON/OFF
    private void OnOffDialogue(bool flag)
    {
        standing.gameObject.SetActive(flag);
        dialogueBox.gameObject.SetActive(flag);
        txt.gameObject.SetActive(flag);
        name.gameObject.SetActive(flag);

        isDialogue = flag;
    }

    //Diolog Next
    private void NextDialogue()
    {
        txt.text = dialoguezip[count].dialugue;
        name.text = dialoguezip[count].name;
        standing.sprite = dialoguezip[count].standing;

        dialoguezip[count].Effect.Invoke();
        count++;
    }

    void Start()
    {
        ShowDialogue();
        
        gameObject.GetComponent<TutorialMaker>().enabled = false;
        tutorial.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDialogue)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (count < dialoguezip.Length)
                    NextDialogue();
                else
                {
                    if (istutorial)
                    {
                        OnOffDialogue(false);
                        player.GetComponent<PlayerFlipController>().enabled = true;
                        gameObject.GetComponent<TutorialMaker>().enabled = true;
                    }
                    else
                    {
                        SceneManager.LoadScene("MainMenu");
                    }

                }
            }
        }
    }
}
