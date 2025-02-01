using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fireball : Projectile
{
    protected override void Parry()
    {
        if (!parryEnabled) return;

        DamageArea.tag = "Fireball_parried";

        if (GameLevelManager.instance.GetCurrentLevel() == "1-4H" || GameLevelManager.instance.GetCurrentLevel() == "1-4HT")
        {
            Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            movePos = temp.normalized;
        }
        else
        {
            movePos = -(movePos * parryingSpeedMultiplier);
        }

        Debug.Log("MovePos : " + movePos);
        Debug.Log("TransformPos : " + transform.position);
        Debug.Log("MousePos : " + Camera.main.ScreenToWorldPoint(Input.mousePosition));

        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;

        fireballSFXController.CallFunctionsAfterParried();
        parryEnabled = false;
    }
}
