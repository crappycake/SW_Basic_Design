using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInfo
{
    static int health;
    static int attack;

    public static int Health => health;
    public static int Attack => attack;

    public static void HealthUp() { health++; }
    public static void AttackUp(int value) { attack += value; }
}
