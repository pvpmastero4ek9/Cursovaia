using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core.Entitys
{
    public class EntitysAtack : MonoBehaviour
    {
        [field: SerializeField] public List<LayerMask> MaskEnemy { get; private set; } 
        [field: SerializeField] private Transform _attackPos;
        [field: SerializeField] private Entity _entityForDamage;
        [field: SerializeField] float _timeBtwAttack;

        [field:SerializeField] public float AttackRange { get; private set; }
        [field:SerializeField] public float StartTimeBtwAttack { get; private set; }
        [field:SerializeField] public Animator Anim { get; private set; }
        public float TimeBtwAttack 
        {
            get 
            {
                return _timeBtwAttack;
            }
            set
            {
                _timeBtwAttack = value;
            }
        }

        public void OnAttack()
        {
            List<Collider2D> enemies = new();
            foreach(LayerMask layerMask in MaskEnemy)
            {
                enemies.AddRange(Physics2D.OverlapCircleAll(_attackPos.position, AttackRange, layerMask).ToList()); 
            }
            
            foreach(Collider2D elem in enemies)
            {
                elem.GetComponent<Entity>().TakeDamage(_entityForDamage.Damage);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_attackPos.position, AttackRange);
        }
    }
}
