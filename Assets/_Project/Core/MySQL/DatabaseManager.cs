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
            db.ExecuteNonQuery("INSERT INTO Players (Name, Score) VALUES ('Player1', 100);");

            // Пример: Получение данных
            db.ExecuteQuery("SELECT * FROM Players;");

            db.CloseConnection();
        }
    }
}
