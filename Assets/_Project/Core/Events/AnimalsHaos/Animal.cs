using UnityEngine;
using Core.Entitys;

namespace Core.AnimalsHaos
{
    public class Animal : Entity
    {
        private AnimalStatsCalculation _animalStatsCalculation = new();

        private void Start()
        {
            _animalStatsCalculation.ScaleEnemyStats(this);
        }

        protected override void Die()
        {
            Destroy(gameObject);
        }
    }
}
