using UnityEngine;
using Core.Entitys;
using System.Linq;

namespace Core.Enemys
{
    public class EnemyAtack : EntitysAtack
    {
        private Transform _currentPlayerTransform;
        private Transform[] _playersTransform;
        private bool _isAttackQueued = false;

        private void Start()
        {
            _playersTransform = GameObject.FindGameObjectsWithTag("Player").Select(x => x.transform).ToArray();
        }

        private void Update()
        {
            if (TimeBtwAttack <= 0 && _isAttackQueued)
            {
                Atack();
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

        private void Atack()
        {
            EntityMovement.IsMove = false;
            Anim.SetTrigger("IsAtack");
            _isAttackQueued = false; // сброс очереди
            TimeBtwAttack = StartTimeBtwAttack;
        }
    }
}
