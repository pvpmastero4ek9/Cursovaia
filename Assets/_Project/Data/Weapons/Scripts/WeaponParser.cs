using UnityEngine;
using MySQLM;
using System.Collections.Generic;
using System.Data;

public class WeaponParser : MonoBehaviour
{
    private const string WeaponNameRowSQL = "weapon_name";
    private const string WeaponDamageRowSQL = "damage";
    private const string WeaponChanceFallingRowSQL = "drop_chance";
    private MySQLConnector db = new();

    public void GetDataWeapon(List<Weapon> weaponsList)
    {
        db.ConnectToDatabase();
        DataTable weaponsDataTable = db.ExecuteQuery("SELECT * FROM weapons");
        foreach (DataRow row in weaponsDataTable.Rows)
        {
            Weapon weaponNew = new()
            {
                WeaponName = row[$"{WeaponNameRowSQL}"].ToString(),
                Damage = (int)row[$"{WeaponDamageRowSQL}"],
                ChanceFalling = (int)row[$"{WeaponChanceFallingRowSQL}"],
            };
            weaponsList.Add(weaponNew);
        }
        db.CloseConnection();
    }
}
