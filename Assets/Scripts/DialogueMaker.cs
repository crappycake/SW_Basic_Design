using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Dialog
[System.Serializable]
public class Dialogue
{
    [TextArea]
    public string dialugue;
    public string name;
    public Sprite standing;
}

public class DialogueMaker : MonoBehaviour
{
    public GameObject player;

    //Dialogue
    [SerializeField] private Image standing;
    [SerializeField] private Image dialogueBox;
    [SerializeField] private Text name;
    [SerializeField] private Text txt;

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
        count++;
    }

    void Start()
    {
        ShowDialogue();
        gameObject.GetComponent<TutorialMaker>().enabled = false;
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
                    OnOffDialogue(false);
                    player.GetComponent<PlayerFlipController>().enabled = true;
                    gameObject.GetComponent<TutorialMaker>().enabled = true;

                }
            }
        }
    }
}
