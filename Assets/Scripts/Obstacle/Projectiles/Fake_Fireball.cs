using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Fake_Fireball : Projectile
{
    protected override void Parry()
    {
        if (!parryEnabled) return;

        DestroyBall();
    }
}