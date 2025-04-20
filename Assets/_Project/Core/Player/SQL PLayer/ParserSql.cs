using UnityEngine;
using MySQLM;
using System.Data;

namespace Core.Players
{
    public class ParserSql 
    {
        private MySQLConnector db;

        public PlayerData ParsingTable(string Nickname)
        {
            PlayerData parserData = new();
            db = new MySQLConnector();
            db.ConnectToDatabase();

            DataTable players = db.ExecuteQuery("SELECT * FROM players");
            foreach (DataRow row in players.Rows)
            {
                if (row["username"].ToString() == Nickname)
                {
                    parserData.UpdateData(Nickname, (int)row["experience"], (int)row["level"]);
                    break;
                }
            }

            db.CloseConnection();
            return parserData;
        }

        public void LoadingDataTable(PlayerData playerData)
        {
            db = new MySQLConnector();
            db.ConnectToDatabase();

            db.ExecuteNonQuery($"UPDATE players SET level = {playerData.PlayerLvl}, experience = {playerData.PlayerExpirience} WHERE username = '{playerData.PlayerName}';");

            db.CloseConnection();
        }
    }}
