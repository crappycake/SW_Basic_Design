using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToCircle : MonoBehaviour
{
    public GameObject circleObject;
    private float radius = 1f;
    public float triangleOffset = 0.5f;

    void Start()
    {
        CircleCollider2D circleCollider = circleObject.GetComponent<CircleCollider2D>();

        if (circleCollider != null) radius = circleCollider.radius * circleObject.transform.localScale.x;
        else Debug.LogError("NO CIRCLE OBJECT ASSIGNED TO THIS SPIKE! Obj: " + this.name);
    }
    void Update()
    {
        transform.position = circleObject.transform.position + (transform.up * (radius + triangleOffset));

        Vector3 directionToCenter = circleObject.transform.position - transform.position;
        float angle = Mathf.Atan2(directionToCenter.y, directionToCenter.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 90f); 
    }
}
