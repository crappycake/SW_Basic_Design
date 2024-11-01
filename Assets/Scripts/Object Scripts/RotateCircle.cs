using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCircle : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    void Awake()
    {
        Debug.Log(rotationSpeed);

    }

    void FixedUpdate()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.fixedDeltaTime);
    }
}
