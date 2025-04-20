using UnityEngine;

namespace Core.Entitys
{
    public class EntitysAtack : MonoBehaviour
    {
        [SerializeField] private float _startTimeBtwAttack;
        [SerializeField] private Transform _attackPos;
        [SerializeField] private LayerMask _maskEnemy;
        [SerializeField] private float _attackRange;
        [SerializeField] private Entity _entityForDamage;
        [SerializeField] private EntityMovement _entityMovement;
        [SerializeField] private Animator _anim;

        private float _timeBtwAttack;
        private bool _isAttackQueued = false;
        
        private void Update()
        {
            if (_timeBtwAttack <= 0 && _isAttackQueued)
            {
                if (Input.GetMouseButton(0))
                {
                    _entityMovement.IsMove = false;
                    _anim.SetTrigger("IsAtack");
                    _isAttackQueued = false; // сброс очереди
                    _timeBtwAttack = _startTimeBtwAttack;
                }
            }
            else
            {
                _timeBtwAttack -= Time.deltaTime;

                // Позволяет "запомнить" атаку, если кликнули в период восстановления
                if (Input.GetMouseButtonDown(0))
                {
                    _isAttackQueued = true;
                }
            }
        }

        public void OnAttack()
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(_attackPos.position, _attackRange, _maskEnemy);
            foreach(Collider2D elem in enemies)
            {
                elem.GetComponent<Entity>().TakeDamage(_entityForDamage.Damage);
            }
            _entityMovement.IsMove = true;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_attackPos.position, _attackRange);
        }
    }
}
