using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class ChagneNode : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    public int nodeGap;
    static int currentNode;


    private void Awake()
    {
        currentNode = 0;
    }
    public void nextBeat()
    {
        currentNode++;
        //changeImage();
        //changeText();
    }

    private void Update()
    {
        for (int i = 0; i <= 8; ++i)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                //ModifyInfoWithKey
            }
        }
    }
    private void ModifyInfoWithKey(int key)
    {
        //changeArray
        //changeImage
    }
}
