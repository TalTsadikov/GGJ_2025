using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack Module", menuName = "ScriptableObjects/Attack Module", order = 1)]
public class AttackModule : ModuleSO
{
    public int damage;
    public float CooldownRate;
    public int radius;
    public float levelupRate;
}
