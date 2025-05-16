using UnityEngine;
using Core.Entitys;
using ListExtentions;

namespace Core.Enemys
{
    public class DropLootEnemy : MonoBehaviour
    {
        [SerializeField] private GameObject _weaponPrefab;
        [SerializeField] private Entity _enemy;
        [SerializeField] private Weapons _weapons;
        private RandomChanceDrop _randomChanceDrop = new();

        private void OnEnable()
        {
            _enemy.DiedEntity += CheckChanceDrop;
        }

        private void OnDisable()
        {
            _enemy.DiedEntity -= CheckChanceDrop;
        }

        private void CheckChanceDrop()
        {
            if (_randomChanceDrop.ChanceBoolean(7))
            {
                DropLoot();
            }
        }

        private void DropLoot()
        {
            
            Instantiate(_weaponPrefab, _enemy.gameObject.transform.position, Quaternion.identity);
            // _weapons.WeaponsList
        }
    }
}
