using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string WeaponName;
    public Sprite SpriteWeapon;
    public int ChanceFalling;
    [HideInInspector] public float Damage;
}
