using UnityEngine;
using Core.Entitys;
using System.Linq;
using System.Collections;
using UnityEngine.AI;

namespace Core.Enemys
{
    public class EnemyAtack : EntitysAtack
    {
        [SerializeField] private EnemyMovement _enemyMovement;

        private Transform _currentPlayerTransform;
        private Transform[] _playersTransform;
        private bool _isAttackQueued = false;

        private void Start()
        {
            _playersTransform = GameObject.FindGameObjectsWithTag("Player").Select(x => x.transform).ToArray();
        }

        private void Update()
        {
            if (!_enemyMovement._isJerk)
            {
                if (TimeBtwAttack <= 0 && _isAttackQueued)
                {
                    Attack();
                }
                else
                {
                    TimeBtwAttack -= Time.deltaTime;
                    _currentPlayerTransform = _playersTransform.OrderBy(x => Vector3.Distance(transform.position, x.position)).FirstOrDefault();
                    if (Vector3.Distance(transform.position, _currentPlayerTransform.position) <= AttackRange)
                    {
                        _isAttackQueued = true;
                    }
                    else
                    {
                        _isAttackQueued = false;
                    }
                }
            }
        }

        private void Attack()
        {
            // Anim.SetTrigger("IsAtack");
            StartCoroutine(_enemyMovement.Jerk());
            
            TimeBtwAttack = StartTimeBtwAttack;
        }
    }
}
