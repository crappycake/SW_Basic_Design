using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBoxCamera : MonoBehaviour
{
    Camera cam;
    private void Awake()
    {
        cam = GetComponent<Camera>();
    }
    public void MoveCamera()
    {
        transform.position += new Vector3(2, 0, 0);
    }

    public void MoveCameraBySlider(int bpm)
    {
        transform.position = new Vector3(bpm * 2, 0, 0);
    }
}
