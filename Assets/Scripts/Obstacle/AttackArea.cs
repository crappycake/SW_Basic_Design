using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [Header("Area")]
    [SerializeField] private GameObject squareAreatemp;
    public GameObject squareArea;

    [Header("Area Attack SFX")]
    [SerializeField] GameObject bloodVFX1;
    [SerializeField] GameObject bloodVFX2;

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
        renderer.material.color = new Color(1f, 0.2f, 0.2f, 0.3f);
        obj.tag = "Damage";

        SpriteRenderer objRenderer = obj.GetComponent<SpriteRenderer>();
        Bounds bounds = objRenderer.bounds;

        for (int i = 0; i < 10; i++)
        {
            Vector3 randomPosition1 = new Vector3(
                UnityEngine.Random.Range(bounds.min.x, bounds.max.x),
                UnityEngine.Random.Range(bounds.min.y, bounds.max.y),
                obj.transform.position.z
            );

            Vector3 randomPosition2 = new Vector3(
                UnityEngine.Random.Range(bounds.min.x, bounds.max.x),
                UnityEngine.Random.Range(bounds.min.y, bounds.max.y),
                obj.transform.position.z
            );

            Instantiate(bloodVFX1, randomPosition1, Quaternion.identity);
            Instantiate(bloodVFX2, randomPosition2, Quaternion.identity);
        }

        float targetTransparency = 0.1f;

        for (float alpha = 0.3f; alpha >= targetTransparency; alpha -= 0.1f)
        {
            Color c = renderer.material.color;
            c.a = alpha;
            renderer.material.color = c;
            yield return new WaitForSeconds(GetBeat(bpm) * 0.1f * k);
        }

        yield return new WaitForSeconds(GetBeat(bpm) * 0.5f * k);

        renderer.material.color = new Color(0.4f, 0.4f, 0.4f);
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
        for (float alpha = 0f; alpha <= 1; alpha += 0.1f)
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
        for (float alpha = 0f; alpha <= 1; alpha += 0.1f)
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

        yield return new WaitForSeconds(GetBeat(bpm) * 0.5f * k);

        obj.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
        obj.tag = "Untagged";
    }
    #endregion


    private float GetBeat(float bpm)
    {
        return 60f / (bpm); //how many seconds in a beat
    }
}