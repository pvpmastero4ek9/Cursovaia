using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using AYellowpaper.SerializedCollections;
using System;
using ListExtentions;

[CreateAssetMenu(fileName = "WeaponsData", menuName = "Weapons/Data")]
public class Weapons : ScriptableObject
{
    [SerializedDictionary("WeaponName", "IconWeapon")]
    [SerializeField] private SerializedDictionary<string, Sprite> _weaponsIconDictionary;
    private List<Weapon> _weaponsList = new();
    private WeaponParser _weaponParser = new();
    public List<Weapon> WeaponsList => CheckWeaponList();
    private RandomChanceDrop _randomChanceDrop = new();

    private List<Weapon> CheckWeaponList()
    {
        if (_weaponsList.Count == 0)
        {
            _weaponParser.GetDataWeapon(_weaponsList);
            foreach (Weapon weapon in _weaponsList)
            {
                weapon.SpriteWeapon = _weaponsIconDictionary[weapon.WeaponName];
            }
        }

        return _weaponsList.ToList();
    }

    public Weapon GetRandomWeapon()
    {
        List<Weapon> weaponsReverce = WeaponsList;
        weaponsReverce.Reverse();

        foreach (Weapon weapon in weaponsReverce)
        {
            if (_randomChanceDrop.ChanceBoolean(weapon.ChanceFalling))
            {
                return weapon;
            }
        }

        return WeaponsList[0];
    }
}
