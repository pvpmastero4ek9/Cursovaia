using UnityEngine;
using Core.Entitys;
using Core.Players;
using System.Linq;

namespace Core.Enemys
{
    public class EnemySpawner : MonoBehaviour
    {
        private const float LevelMultiplier = 0.3f;
        private const int MaxHealthMultiplier = 10;
        private const int DamageMultiplier = 2;

        [SerializeField] private Entity[] _enemyPrefabs;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private float _baseSpawnRate = 5f;

        private int _playerLevel; // получай это значение от игрока
        private float _spawnTimer;

        private void Start()
        {
            _spawnTimer = _baseSpawnRate;
        }

        private void Update()
        {
            int countMoobs = 0;
            _spawnTimer -= Time.deltaTime;

            if (_spawnTimer <= 0f && countMoobs < 2)
            {
                GetPlayerLvl();
                SpawnEnemy();
                float scaledSpawnRate = Mathf.Clamp(_baseSpawnRate - _playerLevel * LevelMultiplier, 1f, _baseSpawnRate);
                _spawnTimer = scaledSpawnRate;
                countMoobs++;
            }
        }

        private void SpawnEnemy()
        {
            int enemyIndex = Mathf.Min(_playerLevel / 3, _enemyPrefabs.Length - 1); // сложнее враги с ростом уровня
            Entity enemyToSpawn = _enemyPrefabs[enemyIndex];

            Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            Entity spawnedEnemy = Instantiate(enemyToSpawn, spawnPoint.position, Quaternion.identity);

            ScaleEnemyStats(spawnedEnemy);
        }

        private void ScaleEnemyStats(Entity enemy)
        {
            int maxHealth = _playerLevel * MaxHealthMultiplier;
            int damage = _playerLevel * DamageMultiplier;
            enemy.UpdateData(maxHealth, maxHealth, damage);
        }

        private void GetPlayerLvl()
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (Player player in players.Select(x => x.GetComponent<Player>()).ToList())
            {
                if (player.PlayerData.PlayerLvl > _playerLevel)
                {
                    _playerLevel = player.PlayerData.PlayerLvl;
                }
            }
        }
    }
}
