using UnityEngine;
using System.Data;

namespace MySQLM
{
    public class RegistrationPlayer : MonoBehaviour
    {
        private MySQLConnector db;

        public delegate void PlayerLoaderDelegate(string Nickname);
        public event PlayerLoaderDelegate PlayerLoader;
        public delegate void UnsuitablPasswordDelegate();
        public event UnsuitablPasswordDelegate UnsuitablPassword;
        public delegate void UnsuitablUserDelegate();
        public event UnsuitablUserDelegate UnsuitablUser;

        void Start()
        {
            db = new MySQLConnector();
        }

        public void LoadPlayer(string Nickname, string password)
        {
            db.ConnectToDatabase();

            DataTable players = db.ExecuteQuery("SELECT * FROM players");
            foreach (DataRow row in players.Rows)
            {
                if (row["username"].ToString() == Nickname)
                {
                    if (row["password"].ToString() == password)
                    {
                        PlayerLoader?.Invoke(Nickname);
                    }
                    else
                    {
                        Debug.Log("Пароль не правильный!");
                        UnsuitablPassword?.Invoke();
                    }
                    break;
                }
                else
                {
                    Debug.Log("Такого пользователя нету!");
                    UnsuitablUser?.Invoke();
                    break;
                }
            }

            db.CloseConnection();
        } 

        public void CreatePlayerAccaunt(string Nickname, string password)
        {
            db.ConnectToDatabase();

            db.ExecuteNonQuery($"INSERT INTO players (username, level, experience, password) VALUES ('{Nickname}', 1, 0, {password});");
            PlayerLoader?.Invoke(Nickname);

            db.CloseConnection();
        }
    }
}
