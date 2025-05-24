using UnityEngine;
using Core.AnimalsHaos;
using ListExtentions;
using System;
using MySQLM;
using System.Data;

namespace Core.Events
{
    public class RandomEventParser : MonoBehaviour
    {
        private const string AnimalsHaosname = "AnimalsHaos";
        [SerializeField] private float _eventRechargeTimeMinutes;
        [SerializeField] private float _timeEventInMinutes;
        [SerializeField] private SpawnAnimals _spawnAnimals;
        private CountdownTimer _countdownTimer = new();
        private MySQLConnector db = new();

        private void Start()
        {
            ActivateTimer();
        }

        private void OnEnable()
        {
            _spawnAnimals.EndingEvent += ActivateTimer;
        }

        private void OnDisable()
        {
            _spawnAnimals.EndingEvent -= ActivateTimer;
        }

        private void StartEvent()
        {
            StartCoroutine(_spawnAnimals.StartAnimalSpawnRoutine(_timeEventInMinutes));
        }

        private async void ActivateTimer()
        {
            DateTime dateRechargeTime = DateTime.Now + TimeSpan.FromMinutes(_eventRechargeTimeMinutes);
            await _countdownTimer.WaitUntil(dateRechargeTime, ParsingRandomEvent);
        }

        private void ParsingRandomEvent()
        {
            db.ConnectToDatabase();

            DataRow row = GetRandomEventRow();
            string eventName = row["event_name"].ToString();
            if (eventName == AnimalsHaosname)
            {
                StartEvent();
            }

            db.CloseConnection();
        }

        public DataRow GetRandomEventRow()
        {
            string query = "SELECT * FROM events ORDER BY RAND() LIMIT 1;";
            DataTable result = db.ExecuteQuery(query);

            if (result.Rows.Count > 0)
                return result.Rows[0];
            else
                return null;
        }
    }
}
