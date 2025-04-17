using UnityEngine;
using MySql.Data.MySqlClient; 
using System;
using System.Data;

namespace MySQLM
{
    public class MySQLConnector : MonoBehaviour
    {
        private MySqlConnection connection;

    // Метод для подключения к базе данных
    public void ConnectToDatabase()
    {
        string server = "localhost"; // Адрес сервера (локально - localhost)
        string database = "unitydb"; // Имя базы данных
        string user = "root";        // Пользователь MySQL
        string password = "1234"; // Пароль пользователя
        string port = "3306";         // Порт MySQL

        string connectionString = $"Server={server};Database={database};User ID={user};Password={password};Port={port};";

        try
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
            Debug.Log("Подключение успешно!");
        }
        catch (Exception ex)
        {
            Debug.LogError("Ошибка подключения: " + ex.Message);
        }
    }

    // Метод для выполнения запроса INSERT/UPDATE/DELETE
    public void ExecuteNonQuery(string query)
    {
        if (connection == null || connection.State != System.Data.ConnectionState.Open)
        {
            Debug.LogError("Подключение не установлено.");
            return;
        }

        try
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
            Debug.Log("Запрос выполнен успешно!");
        }
        catch (Exception ex)
        {
            Debug.LogError("Ошибка выполнения запроса: " + ex.Message);
        }
    }

    // Метод для выполнения SELECT-запросов
    public DataTable ExecuteQuery(string query)
    {
            DataTable dataTable = new DataTable();

            if (connection == null || connection.State != ConnectionState.Open)
            {
                Debug.LogError("Подключение не установлено.");
                return dataTable;
            }

            try
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("Ошибка выполнения запроса: " + ex.Message);
            }

            return dataTable;
    }

    // Метод для закрытия подключения
    public void CloseConnection()
    {
        if (connection != null)
        {
            connection.Close();
            Debug.Log("Подключение закрыто.");
        }
    }
    }
}
