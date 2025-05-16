using UnityEngine;
using Mirror;

namespace Core.Entitys
{
    public class Entity : NetworkBehaviour
    {
        public float MaxHealth { get; private set; } = 100f;
        public float CurrentHealth { get; private set; } = 100f;
        public float Damage { get; private set; } = 10f;

        public delegate void ChangedHealthHandler();
        public event ChangedHealthHandler ChangedHealth;
        public delegate void DiedEntityHandler();
        public event DiedEntityHandler DiedEntity;

        public void UpdateData(float? maxHealth = null, float? currentHealth = null, float? damage = null)
        {
            if (maxHealth.HasValue) MaxHealth = maxHealth.Value;
            if (currentHealth != null) CurrentHealth = currentHealth.Value;
            if (damage != null) Damage = damage.Value;

            ChangedHealth?.Invoke();
        }

        public void TakeDamage(float damage)
        {
            if ((CurrentHealth -= damage) <= 0)
            {
                CurrentHealth = 0;
                Die(); 
            }
            else
            {
                CurrentHealth -= damage;
            }

            ChangedHealth?.Invoke();
        }
        
        protected virtual void Die()
        {
            // Логика смерти
            DiedEntity?.Invoke();
        }
    }
}
