using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guided_Fireball : Fireball
{
    public GameObject target;
    protected override void Start()
    {
        base.Start();
        StartCoroutine(Guide());
        Debug.Log("qqqqqq");
    }

    IEnumerator Guide()
    {
        yield return new WaitForSeconds(60f / bpm * 2);
        Vector3 tempmovePos = movePos;
        for(int i = 0; i < 10; i++)
        {
            movePos -= tempmovePos / 10;
            yield return new WaitForSeconds(60 / bpm / 5);
        }

        yield return new WaitForSeconds(60f / bpm * 2);
        SetmovePos(target.transform.position, speed);
    }
}
