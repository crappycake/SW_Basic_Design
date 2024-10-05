using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToCircle : MonoBehaviour
{
    public GameObject attachedObject;
    private float radius = 1f;
    public float offset = 0.5f;

    public bool isInitialized = false;

    void Update()
    {
        if (!isInitialized) Initialize();

        Vector3 directionToCenter = attachedObject.transform.position - transform.position;
        float angle = Mathf.Atan2(directionToCenter.y, directionToCenter.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 90f);
    }

    void Initialize()
    {
        isInitialized = true;

        CircleCollider2D attachedCircleCollider = attachedObject.GetComponent<CircleCollider2D>();

        if (attachedCircleCollider != null) radius = attachedCircleCollider.radius * attachedObject.transform.localScale.x;
        CircleCollider2D circleCollider = GetComponent<CircleCollider2D>();
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        PolygonCollider2D polygonCollider = GetComponent<PolygonCollider2D>(); // Add PolygonCollider2D


        if (circleCollider != null)
        {
            offset = circleCollider.radius * gameObject.transform.localScale.x;
        }
        else if (boxCollider != null)
        {
            float height = boxCollider.size.y * gameObject.transform.localScale.y;
            offset = height / 2f;
        }
        else if (polygonCollider != null) //for triangles
        {
            Vector2[] vertices = polygonCollider.points;
            float minY = float.MaxValue;
            float maxY = float.MinValue;

            foreach (Vector2 vertex in vertices)
            {
                if (vertex.y < minY) minY = vertex.y;
                if (vertex.y > maxY) maxY = vertex.y;
            }

            float height = (maxY - minY) * gameObject.transform.localScale.y; 
            offset = height / 2f;
        }

        transform.parent = attachedObject.transform;
    }
}