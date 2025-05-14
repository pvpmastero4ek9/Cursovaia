using UnityEngine;
using ListExtentions;
using System.Data;
using System;
using System.Threading.Tasks;

namespace Core.AnimalsHaos
{
    public class ActivationAnimalEvent : MonoBehaviour
    {
        [SerializeField] private float _eventRechargeTimeMinutes;
        [SerializeField] private float _timeEventInMinutes;
        [SerializeField] private SpawnAnimals _spawnAnimals;
        private CountdownTimer _countdownTimer = new();

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
            await _countdownTimer.WaitUntil(dateRechargeTime, StartEvent);
        }
    }
}
