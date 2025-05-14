using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core.AnimalsHaos
{
    public class SpawnAnimals : MonoBehaviour
    {
        [SerializeField] private List<Transform> _spawnsAnimals;
        [SerializeField] private List<GameObject> _animalsPrefab;
        [SerializeField] private float _timeBtwSpawnInSeconds;
        private float _timeSpawn;
        private float _nextSpawnTime;

        public delegate void EndingEventHandler();
        public event EndingEventHandler EndingEvent;

        public IEnumerator StartAnimalSpawnRoutine(float timeEventInMinutes)
        {
            Debug.Log(_timeSpawn);
            while (_timeSpawn < timeEventInMinutes * 60)
            {
                _timeSpawn += Time.deltaTime;
                
                if (_timeSpawn >= _nextSpawnTime)
                {
                    SpawnAnimal(); 
                    _nextSpawnTime += _timeBtwSpawnInSeconds;
                }
                yield return null;
            }

            _timeSpawn = 0;
            EndingEvent?.Invoke();
        }

        private void SpawnAnimal()
        {
            GameObject randomAnimal = _animalsPrefab[Random.Range(0, _animalsPrefab.Count)];
            Transform randomSpawnPoint = _spawnsAnimals[Random.Range(0, _spawnsAnimals.Count)];

            List<Transform> targetsPoint = new(_spawnsAnimals);
            targetsPoint.Remove(randomSpawnPoint);
            Transform randomTargetPoint = targetsPoint[Random.Range(0, targetsPoint.Count)];

            GameObject animal = Instantiate(randomAnimal, randomSpawnPoint.position, randomSpawnPoint.rotation);
            animal.GetComponent<MovementAnimals>().Target = randomTargetPoint;
        }
    }
}
