using UnityEngine;
using Core.Entitys;
using UnityEngine.UI;

namespace UI.Entitys
{
    public class HealthBarEntity : MonoBehaviour
    {
        [SerializeField] private Entity _entity;
        [SerializeField] private Image _healthBar;

        private void OnEnable()
        {
            _entity.ChangedHealth += ChangeHealth;
            ChangeHealth();
        }

        private void OnDisable()
        {
            _entity.ChangedHealth -= ChangeHealth;
        }

        private void ChangeHealth()
        {
            _healthBar.fillAmount =  _entity.CurrentHealth / _entity.MaxHealth;
        }
    }
}
