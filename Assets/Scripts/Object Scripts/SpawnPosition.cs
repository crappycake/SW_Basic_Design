using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    [SerializeField] private int circle;
    Vector3 position;
    void Awake()
    {
        float speed = SpeedSetting.instance.RotateSpeed();
        float theta = (90 - speed) * Mathf.Deg2Rad;
        float circleSize = 5.0f;
        if(circle == 1)
        {
            position = new Vector3(circleSize*Mathf.Cos(theta), -5 + circleSize*Mathf.Sin(theta), 0);
        }
        else
        {
            position = new Vector3(circleSize * Mathf.Cos(theta), 8 - circleSize * Mathf.Sin(theta), 0);
        }

        Debug.Log(Mathf.Cos(theta));
        Debug.Log(Mathf.Sin(theta));

        gameObject.transform.position = position;
    }
}
