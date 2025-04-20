using UnityEngine;
using Core.Entitys;
using Core.Players;
using System.Linq;

namespace Core.Enemys
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Entity[] _enemyPrefabs;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private float _baseSpawnRate = 5f;

        private int playerLevel; // получай это значение от игрока
        private float spawnTimer;

        void Update()
        {
            spawnTimer -= Time.deltaTime;

            if (spawnTimer <= 0f)
            {
                GetPlayerLvl();
                SpawnEnemy();
                float scaledSpawnRate = Mathf.Clamp(_baseSpawnRate - playerLevel * 0.3f, 1f, _baseSpawnRate);
                spawnTimer = scaledSpawnRate;
            }
        }

        void SpawnEnemy()
        {
            int enemyIndex = Mathf.Min(playerLevel / 3, _enemyPrefabs.Length - 1); // сложнее враги с ростом уровня
            Entity enemyToSpawn = _enemyPrefabs[enemyIndex];

            Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            Entity spawnedEnemy = Instantiate(enemyToSpawn, spawnPoint.position, Quaternion.identity);

            ScaleEnemyStats(spawnedEnemy);
        }

        void ScaleEnemyStats(Entity enemy)
        {
            int maxHealth = playerLevel * 10;
            int damage = playerLevel * 2;
            enemy.UpdateData(maxHealth, maxHealth, damage);
        }

        private void GetPlayerLvl()
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (Player player in players.Select(x => x.GetComponent<Player>()).ToList())
            {
                if (player.PlayerData.PlayerLvl > playerLevel)
                {
                    playerLevel = player.PlayerData.PlayerLvl;
                }
            }
        }
    }
}
