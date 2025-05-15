using System;
using UnityEngine;

[Serializable]
public class Weapon
{
    public string WeaponName;
    public Sprite SpriteWeapon;
    [HideInInspector] public float Damage;
}
