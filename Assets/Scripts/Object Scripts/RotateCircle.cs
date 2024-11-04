using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCircle : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float circle;


    void Awake()
    {
        Debug.Log(rotationSpeed);
        rotationSpeed = SpeedSetting.instance.RotateSpeed();
        if (circle % 2 == 0) rotationSpeed *= -1; 
    }

    void FixedUpdate()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.fixedDeltaTime);
    }
}
