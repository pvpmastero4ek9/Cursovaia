using Core.Entitys;
using UnityEngine;
using ListExtentions;
using System;
using System.Threading.Tasks;

namespace Core.Players
{
    public class SelectionWeapons : MonoBehaviour
    {
        [SerializeField] private int _timeSelection = 2;
        [SerializeField] private Entity _entity;
        private CountdownTimer _countdownTimer = new();
        private GameObject _targetWeapon;
        private bool _isPlayerWorth;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Weapon")
            {
                _isPlayerWorth = true;
                _targetWeapon = collision.gameObject;
                ActivateTimer();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Weapon")
            {
                _isPlayerWorth = false;
            }
        }

        private async void ActivateTimer()
        {
            DateTime timeSpan = DateTime.Now + TimeSpan.FromSeconds(_timeSelection);
            await _countdownTimer.WaitUntil(timeSpan, TakeWeapon);
        }

        private void TakeWeapon()
        {
            if (!_isPlayerWorth) return;
            Weapon weapon = _targetWeapon.GetComponent<Weapon>();
            _entity.UpdateData(_entity.MaxHealth, _entity.CurrentHealth, weapon.Damage);

            Destroy(_targetWeapon);
        }
    }
}
