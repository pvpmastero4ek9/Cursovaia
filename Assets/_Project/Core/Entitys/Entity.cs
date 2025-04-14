using UnityEngine;

namespace Core.Entitys
{
    public class Entity : MonoBehaviour
    {
        public float maxHealth { get; private set; } = 100f;
        public float currentHealth { get; private set; }
        public float damage { get; private set; } = 10f;

        public void UpdateData(string NewPlayerName = null, int? NewPlayerHealth = null)
        {
            
        }
    }
}
