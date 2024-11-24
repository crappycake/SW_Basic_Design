using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [Header("Area")]
    [SerializeField] private GameObject squareAreatemp;
    public GameObject squareArea;
    private float bpm;
    // Start is called before the first frame update
    void Start()
    {
        squareArea = squareAreatemp;
        bpm = GameObject.Find("Beat Manager").GetComponent<LevelBeatManager>().Bpm();
    }

    #region SquareArea
    public void TriggerSquareAreaAttack(GameObject position, float k = 1)
    {
        GameObject temp = SummonSquareArea(position);
        EnableSquareArea(temp, k);
    }


    private GameObject SummonSquareArea(GameObject position)
    {
        GameObject newSquareArea = Instantiate(squareArea);
        newSquareArea.transform.position = position.transform.position;
        return newSquareArea;
    }
    
    private void EnableSquareArea(GameObject obj, float k)
    {
        StartCoroutine(SquareFadeInOut(obj, k));
    }

    IEnumerator SquareFadeInOut(GameObject obj, float k)
    {
        SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
        Color c = renderer.material.color;
        for (float alpha = 0f; alpha <= 1f; alpha += 0.1f)
        {
            c.a = alpha;
            renderer.color = c;
            yield return new WaitForSeconds(GetBeat(bpm) / 10 * k);
        }
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            renderer.color = c;
            yield return new WaitForSeconds(GetBeat(bpm) / 10 * k);
        }
        c.r = 255;
        c.g = 255;
        c.b = 0;
        for (float alpha = 0f; alpha <= 1f; alpha += 0.1f)
        {
            c.a = alpha;
            renderer.color = c;
            yield return new WaitForSeconds(GetBeat(bpm) / 10 * k);
        }
        yield return StartCoroutine(DamageSquare(obj, k));
    }

    IEnumerator DamageSquare(GameObject obj, float k)
    {
        SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
        yield return null;
        renderer.material.color = new Color(255, 0, 0);
        obj.tag = "Damage";

        yield return new WaitForSeconds(GetBeat(bpm) * (float)0.7 * k);

        renderer.material.color = new Color(100, 100, 100);
        obj.tag = "Untagged";
        Destroy(obj);
    }
    #endregion


    #region CircleArea
    public void TriggerCircleAreaAttack(GameObject Circle, float k = 1)
    {
        StartCoroutine(CircleFadeInOut(Circle, k));
    }

    IEnumerator CircleFadeInOut(GameObject obj, float k)
    {
        SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
        Color c = renderer.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            renderer.color = c;
            yield return new WaitForSeconds(GetBeat(bpm) / 10 * k);
        }
        for (float alpha = 0f; alpha <= 1; alpha += 0.1f)
        {
            c.a = alpha;
            renderer.color = c;
            yield return new WaitForSeconds(GetBeat(bpm) / 10 * k);
        }
        c.r = 255;
        c.g = 255;
        c.b = 0;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            renderer.color = c;
            yield return new WaitForSeconds(GetBeat(bpm) / 10 * k);
        }
        yield return StartCoroutine(DamageCircle(obj, k));
    }

    IEnumerator DamageCircle(GameObject obj, float k)
    {
        obj.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        obj.tag = "Damage";

        yield return new WaitForSeconds(GetBeat(bpm) * (float)0.7 * k);

        obj.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
        obj.tag = "Untagged";
    }
    #endregion


    private float GetBeat(float bpm)
    {
        return 60f / (bpm); //how many seconds in a beat
    }
}
