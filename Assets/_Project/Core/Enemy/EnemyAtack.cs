using UnityEngine;
using Core.Entitys;
using System.Linq;
using System.Collections;
using UnityEngine.AI;

namespace Core.Enemys
{
    public class EnemyAtack : EntitysAtack
    {
        private const float TimePauseAttack = 0.3f;
        private const float DashSpeed = 10f;
        [SerializeField] private float _distanceForAtack;
        [SerializeField] private EnemyMovement _enemyMovement;

        private Transform _currentPlayerTransform;
        private Transform[] _playersTransform;
        private NavMeshAgent _navMeshAgent => _enemyMovement.EnemyAgent;
        private float _defaultSpeed;
        private bool _isAttackQueued = false;
        private bool _isDash = false;

        private void Start()
        {
            _defaultSpeed = _navMeshAgent.speed;
            _playersTransform = GameObject.FindGameObjectsWithTag("Player").Select(x => x.transform).ToArray();
        }

        private void Update()
        {
            if (!_isDash)
            {
                if (TimeBtwAttack <= 0 && _isAttackQueued)
                {
                    StartCoroutine(Attack());
                }
                else
                {
                    TimeBtwAttack -= Time.deltaTime;
                    _currentPlayerTransform = _playersTransform.OrderBy(x => Vector3.Distance(transform.position, x.position)).FirstOrDefault();
                    if (Vector3.Distance(transform.position, _currentPlayerTransform.position) <= _distanceForAtack)
                    {
                        Debug.Log("Я ммогу врыватся");
                        _isAttackQueued = true;
                    }
                    else
                    {
                        Debug.Log("fgegfefg");
                        _isAttackQueued = false;
                    }
                }
            }
        }

        private IEnumerator Attack()
        {
            Debug.Log("Я бросаюсь");
            Transform positionForDash = _currentPlayerTransform;
            Transform positionPlayer = _enemyMovement.Target;

            _navMeshAgent.isStopped = true;
            _isDash = true;
            
            yield return new WaitForSeconds(TimePauseAttack);
            Debug.Log("Я кинулся!");
            
            _navMeshAgent.speed = DashSpeed;
            _navMeshAgent.isStopped = false;
            _enemyMovement.Target = positionForDash;

            while (Vector3.Distance(transform.position, positionForDash.position) > _navMeshAgent.stoppingDistance + 0.05f)
            {
                yield return null;
            }

            _enemyMovement.Target = positionPlayer;
            _navMeshAgent.speed = _defaultSpeed;
            _isDash = false;

            // Anim.SetTrigger("IsAtack");
            _isAttackQueued = false; // сброс очереди

            TimeBtwAttack = StartTimeBtwAttack;
        }
    }
}
