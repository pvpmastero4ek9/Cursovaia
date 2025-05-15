using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponsData", menuName = "Weapons/Data")]
public class Weapons : ScriptableObject
{
    public List<Weapon> WeaponsList => _weaponsList.ToList();
    [SerializeField] private List<Weapon> _weaponsList;
    private WeaponParser _weaponParser = new();

    private void CheckWeaponList()
    {
        foreach(Weapon weapon in _weaponsList)
        {
            if (weapon.Damage == 0)
            {
                _weaponParser.FillDamageWeapon(_weaponsList);
                break;
            }
        }
    }
}
