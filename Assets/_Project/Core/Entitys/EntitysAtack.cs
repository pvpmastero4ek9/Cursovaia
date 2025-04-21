using UnityEngine;

namespace Core.Entitys
{
    public class EntitysAtack : MonoBehaviour
    {
        [SerializeField] private Transform _attackPos;
        [SerializeField] private LayerMask _maskEnemy;
        [SerializeField] private Entity _entityForDamage;
        [SerializeField] float _timeBtwAttack;

        [field:SerializeField] public float AttackRange { get; private set; }
        [field:SerializeField] public float StartTimeBtwAttack { get; private set; }
        [field:SerializeField] public EntityMovement EntityMovement { get; private set; }
        [field:SerializeField] public Animator Anim { get; private set; }
        public float TimeBtwAttack 
        {
            get 
            {
                return _timeBtwAttack;
            }
            set
            {
                if (value < 0) return;
                _timeBtwAttack = value;
            }
        }

        public void OnAttack()
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(_attackPos.position, AttackRange, _maskEnemy);
            foreach(Collider2D elem in enemies)
            {
                elem.GetComponent<Entity>().TakeDamage(_entityForDamage.Damage);
            }
            EntityMovement.IsMove = true;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_attackPos.position, AttackRange);
        }
    }
}
