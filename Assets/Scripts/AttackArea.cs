using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [Header("Area")]
    [SerializeField] private GameObject squareAreatemp;
    public GameObject squareArea;
    // Start is called before the first frame update
    void Start()
    {
        squareArea = squareAreatemp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region SquareArea
    public void SquareArea(GameObject position)
    {
        GameObject temp = SummonSquareArea(position);
        EnableSquareArea(temp);
    }


    public GameObject SummonSquareArea(GameObject position)
    {
        GameObject newSquareArea = Instantiate(squareArea);
        squareArea.transform.position = position.transform.position;
        return newSquareArea;
    }
    private void EnableSquareArea(GameObject obj)
    {
        StartCoroutine(SquareFadeInOut(obj));
    }
    IEnumerator SquareFadeInOut(GameObject obj)
    {
        SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
        Color c = renderer.material.color;
        for (float alpha = 0f; alpha <= 1f; alpha += 0.1f)
        {
            c.a = alpha;
            renderer.material.color = c;
            yield return new WaitForSeconds(.05f);
        }
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            renderer.material.color = c;
            yield return new WaitForSeconds(.05f);
        }
        for (float alpha = 0f; alpha <= 1f; alpha += 0.1f)
        {
            c.a = alpha;
            renderer.material.color = c;
            yield return new WaitForSeconds(.05f);
        }
        yield return StartCoroutine(DamageSquare(obj));
    }

    IEnumerator DamageSquare(GameObject obj)
    {
        SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
        yield return null;
        renderer.material.color = new Color(255, 0, 0);
        obj.tag = "Damage";

        yield return new WaitForSeconds(1f);

        renderer.material.color = new Color(100, 100, 100);
        obj.tag = "Untagged";
        Destroy(obj);
    }
    #endregion


    public void CircleArea(GameObject Circle)
    {
        StartCoroutine(CircleFadeInOut(Circle));
    }

    IEnumerator CircleFadeInOut(GameObject obj)
    {
        SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
        Color c = renderer.material.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            renderer.material.color = c;
            yield return new WaitForSeconds(.05f);
        }
        for (float alpha = 0f; alpha <= 1; alpha += 0.1f)
        {
            c.a = alpha;
            renderer.material.color = c;
            yield return new WaitForSeconds(.05f);
        }
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            renderer.material.color = c;
            yield return new WaitForSeconds(.05f);
        }
        yield return StartCoroutine(DamageCircle(obj));
    }

    IEnumerator DamageCircle(GameObject obj)
    {
        obj.GetComponent<SpriteRenderer>().material.color = new Color(255, 0, 0);
        obj.tag = "Damage";

        yield return new WaitForSeconds(1f);

        obj.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255);
        obj.tag = "Untagged";
    }
}
