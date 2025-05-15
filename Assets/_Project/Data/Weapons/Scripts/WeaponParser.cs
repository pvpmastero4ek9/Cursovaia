using UnityEngine;
using MySQLM;
using System.Collections.Generic;
using System.Data;

public class WeaponParser : MonoBehaviour
{
    private const string WeaponNameRowSQL = "weapon_name";
    private const string WeaponDamageRowSQL = "damage";
    private MySQLConnector db = new();

    public void FillDamageWeapon(List<Weapon> weaponsList)
    {
        db.ConnectToDatabase();
        DataTable weaponsDataTable = db.ExecuteQuery("SELECT * FROM weapons");
        foreach (DataRow row in weaponsDataTable.Rows)
        {
            foreach(Weapon weapon in weaponsList)
            {
                if (row[$"{WeaponNameRowSQL}"].ToString() == weapon.WeaponName)
                {
                    weapon.Damage = (float)row[$"{WeaponDamageRowSQL}"];
                    break;
                }
            }
        }
    }
}
