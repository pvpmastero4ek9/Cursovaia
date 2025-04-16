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
        
        private void Update()
        {
            if (_timeBtwAttack <= 0)
            {
                if (Input.GetMouseButton(0))
                {
                    _entityMovement.IsMove = false;
                    _anim.SetTrigger("IsAtack");  
                }
                _timeBtwAttack = _startTimeBtwAttack;
            }    
            else
            {
                _timeBtwAttack -= Time.deltaTime;
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

    //     [Header("Attack Settings")]
    // [SerializeField] private float _attackCooldown = 1f;
    // [SerializeField] private float _attackRange = 1.5f;
    // [SerializeField] private Transform _attackPos;
    // [SerializeField] private LayerMask _enemyLayer;
    
    // [Header("Dependencies")]
    // [SerializeField] private Entity _selfEntity;
    // [SerializeField] private EntityMovement _entityMovement;
    // [SerializeField] private Animator _animator;

    // private float _currentCooldown;
    // private bool _isAttacking;

    // private void Update()
    // {
    //     if (_currentCooldown > 0)
    //     {
    //         _currentCooldown -= Time.deltaTime;
    //         return;
    //     }

    //     if (ShouldAttack())
    //     {
    //         StartAttack();
    //     }
    // }

    // private bool ShouldAttack()
    // {
    //     // Здесь можно добавить дополнительные условия для атаки
    //     // Например, проверка дистанции до цели
    //     return !_isAttacking && HasEnemiesInRange();
    // }

    // private bool HasEnemiesInRange()
    // {
    //     return Physics2D.OverlapCircle(_attackPos.position, _attackRange, _enemyLayer);
    // }

    // private void StartAttack()
    // {
    //     _isAttacking = true;
    //     _entityMovement.SetMovementAllowed(false);
    //     _animator.SetTrigger("Attack");
    //     _currentCooldown = _attackCooldown;
    // }

    // // Вызывается из анимации (Animation Event)
    // public void ExecuteAttack()
    // {
    //     Collider2D[] enemies = Physics2D.OverlapCircleAll(_attackPos.position, _attackRange, _enemyLayer);
        
    //     foreach (Collider2D enemy in enemies)
    //     {
    //         Entity enemyEntity = enemy.GetComponent<Entity>();
    //         if (enemyEntity != null)
    //         {
    //             enemyEntity.TakeDamage(_selfEntity.Damage);
    //         }
    //     }
    // }

    // // Вызывается из анимации (Animation Event)
    // public void EndAttack()
    // {
    //     _isAttacking = false;
    //     _entityMovement.SetMovementAllowed(true);
    // }

    // private void OnDrawGizmosSelected()
    // {
    //     if (_attackPos != null)
    //     {
    //         Gizmos.color = Color.red;
    //         Gizmos.DrawWireSphere(_attackPos.position, _attackRange);
    //     }
    // }
    }
}
