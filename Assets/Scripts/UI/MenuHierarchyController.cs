using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class MenuHierarchyController : MonoBehaviour
{
    Stack<GameObject> menuStack = new Stack<GameObject>();
    public GameObject topMenu;
    [SerializeField] private GameObject previousTopMenu;
    [SerializeField] private bool isOnMainMenu;
    [SerializeField] PlayerInput playerInput;

    private AudioSource buttonClickSound;

    public UnityEvent OnPauseToggled;

    private GeneralButtonHandler generalButtonHandler;
    private Player_SFXController player_SFXController;
    private void Awake()
    {
        buttonClickSound = GetComponent<AudioSource>();
        generalButtonHandler = GetComponent<GeneralButtonHandler>();
        player_SFXController = FindAnyObjectByType<Player_SFXController>();
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    public void TogglePause()
    {
        buttonClickSound.Play();

        //player is in-game or in menu
        if (menuStack.Count == 0)
        {
            menuStack.Push(topMenu);
            menuStack.Peek().SetActive(true);
            OnPauseToggled.Invoke();
            player_SFXController.PauseShake();

            if (!isOnMainMenu)
            {

                Time.timeScale = 0f;
            }
        }
        else
        {
            //turn off current menu
            menuStack.Peek().SetActive(false);
            menuStack.Pop();

            //turn on the parent menu if there is any
            if (menuStack.Count > 0) menuStack.Peek().SetActive(true);
            else if (menuStack.Count == 0 && !isOnMainMenu)
            {
                Time.timeScale = 1f;
                OnPauseToggled.Invoke();
                player_SFXController.ResumeShake();
            }
            if (menuStack.Count == 1 && isOnMainMenu)
            {
                menuStack.Clear();
                topMenu = previousTopMenu;
            }
        }

        Debug.Log(menuStack.Count);
    }

    public void AddToStack(GameObject obj)
    {
        menuStack.Push(obj);
        Debug.Log(menuStack.Count);
    }

    public void SetTopMenu(GameObject obj)
    {
        previousTopMenu = topMenu;
        topMenu = obj;
        ClearStack();
        AddToStack(obj);
    }

    //when leaving submenu by clicking on button
    public void PopStack()
    {
        menuStack.Pop();
        if (menuStack.Count == 1 && isOnMainMenu)
        {
            menuStack.Clear();
            topMenu = previousTopMenu;
        }

        if (menuStack.Count == 0 && !isOnMainMenu)
        {
            Time.timeScale = 1f;
            OnPauseToggled.Invoke();
        }
        Debug.Log(menuStack.Count);
    }

    //menu stack needs to be cleared when leaving menu by clicking on button
    public void ClearStack()
    {
        menuStack.Clear();
    }
}