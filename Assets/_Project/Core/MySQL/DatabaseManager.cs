using UnityEngine;

namespace MySQLM
{
    public class DatabaseManager : MonoBehaviour
    {
        private MySQLConnector db;

        void Start()
        {
            db = new MySQLConnector();
            db.ConnectToDatabase();

            // Пример: Добавление записи
            // db.ExecuteNonQuery("INSERT INTO players (username, level, experience) VALUES ('Player1', 2, 100);");

            // Пример: Получение данных
            db.ExecuteQuery("SELECT * FROM players;");

            db.CloseConnection();
        }
    }
}
