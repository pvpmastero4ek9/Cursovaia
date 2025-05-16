using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponsData", menuName = "Weapons/Data")]
public class Weapons : ScriptableObject
{
    public List<Weapon> WeaponsList => CheckWeaponList();
    [SerializeField] private List<Weapon> _weaponsList;
    private WeaponParser _weaponParser = new();

    private List<Weapon> CheckWeaponList()
    {
        foreach (Weapon weapon in _weaponsList)
        {
            if (weapon.Damage == 0)
            {
                _weaponParser.FillDamageWeapon(_weaponsList);
                break;
            }
        }

        return _weaponsList.ToList();
    }
}
