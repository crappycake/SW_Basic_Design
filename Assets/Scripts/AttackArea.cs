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
        bpm = GameObject.Find("Beat Manager(TEST)").GetComponent<LevelBeatManager>().Bpm();
    }

    #region SquareArea
    public void TriggerSquareAreaAttack(GameObject position)
    {
        GameObject temp = SummonSquareArea(position);
        EnableSquareArea(temp);
    }


    private GameObject SummonSquareArea(GameObject position)
    {
        GameObject newSquareArea = Instantiate(squareArea);
        newSquareArea.transform.position = position.transform.position;
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
            yield return new WaitForSeconds(GetBeat(bpm) / 10);
        }
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            renderer.material.color = c;
            yield return new WaitForSeconds(GetBeat(bpm) / 10);
        }
        for (float alpha = 0f; alpha <= 1f; alpha += 0.1f)
        {
            c.a = alpha;
            renderer.material.color = c;
            yield return new WaitForSeconds(GetBeat(bpm) / 10);
        }
        yield return StartCoroutine(DamageSquare(obj));
    }

    IEnumerator DamageSquare(GameObject obj)
    {
        SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
        yield return null;
        renderer.material.color = new Color(255, 0, 0);
        obj.tag = "Damage";

        yield return new WaitForSeconds(GetBeat(bpm) * (float)0.7);

        renderer.material.color = new Color(100, 100, 100);
        obj.tag = "Untagged";
        Destroy(obj);
    }
    #endregion


    #region CircleArea
    public void TriggerCircleAreaAttack(GameObject Circle)
    {
        StartCoroutine(CircleFadeInOut(Circle));
    }

    IEnumerator CircleFadeInOut(GameObject obj)
    {
        SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
        Color c = renderer.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            renderer.color = c;
            yield return new WaitForSeconds(GetBeat(bpm) / 10);
        }
        for (float alpha = 0f; alpha <= 1; alpha += 0.1f)
        {
            c.a = alpha;
            renderer.color = c;
            yield return new WaitForSeconds(GetBeat(bpm) / 10);
        }
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            renderer.color = c;
            yield return new WaitForSeconds(GetBeat(bpm) / 10);
        }
        yield return StartCoroutine(DamageCircle(obj));
    }

    IEnumerator DamageCircle(GameObject obj)
    {
        obj.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        obj.tag = "Damage";

        yield return new WaitForSeconds(GetBeat(bpm) * (float)0.7);

        obj.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
        obj.tag = "Untagged";
    }
    #endregion


    private float GetBeat(float bpm)
    {
        return 60f / (bpm); //how many seconds in a beat
    }
}
