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


    //getBeatMap

    private void Awake()
    {
        currentNode = 0;
    }
    public void nextBeat()
    {
        currentNode++;
        nextImage();
        nextText();
    }

    void nextImage()
    {
        //Array[currentNode + nodeGap]
    }
    void nextText()
    {
        //currentNode + nodeGap
        //if currentNode + nodeGap > nodeLength : text = endNode
    }
}
