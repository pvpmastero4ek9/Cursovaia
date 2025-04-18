using UnityEngine;
using Mirror;

namespace Core.Entitys
{
    public class Entity : NetworkBehaviour
    {
        public float MaxHealth { get; private set; } = 100f;
        public float CurrentHealth { get; private set; }
        public float Damage { get; private set; } = 10f;

        public void UpdateData(float? maxHealth = null, float? currentHealth = null, float? damage = null)
        {
            if (maxHealth.HasValue) MaxHealth = maxHealth.Value;
            if (currentHealth != null) CurrentHealth = currentHealth.Value;
            if (damage != null) Damage = damage.Value;
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
        }
        
        public virtual void Die()
        {
            // Логика смерти
        }
    }
}
