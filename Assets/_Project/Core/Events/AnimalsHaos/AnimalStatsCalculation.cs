using UnityEngine;
using Core.Entitys;
using Core.Players;
using System.Linq;

namespace Core.AnimalsHaos
{
    public class AnimalStatsCalculation
    {
        private const int MaxHealthMultiplier = 30;
        private int _playerLevel;

        public void ScaleEnemyStats(Entity enemy)
        {
            int maxHealth = _playerLevel * MaxHealthMultiplier;
            enemy.UpdateData(maxHealth, maxHealth);
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
