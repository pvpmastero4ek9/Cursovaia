using UnityEngine;
using UnityEngine.AI;
using Core.Entitys;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    private const float TimePauseJerk = 0.3f;
    private const float DashSpeed = 30f;
    [SerializeField] private float _pushRange = 1f;
    [SerializeField] private float _startTimeBtwPush = 1f;
    [SerializeField] private NavMeshAgent _enemyAgent;
    [SerializeField] private List<LayerMask> _maskEnemy; 
    private float _timeBtwPush;
    private Transform _target;
    private DefaultSpeed _defaultSpeed = new();
    public bool _isPush { get; private set; } = false;

    public delegate void EnemyPushHandler();
    public event EnemyPushHandler EnemyPush;

    public Transform Target
    {
        get
        {
            return _target;
        }
        set
        {
            _target = value;
        }
    }

    public IEnumerator Push()
    {
        Vector3 targetPos = _target.position; 
        PreparingForPush();

        yield return new WaitForSeconds(TimePauseJerk);
        MakePush(targetPos);
        
        while (Vector3.Distance(transform.position, targetPos) > _enemyAgent.stoppingDistance + 0.6f)
        {
            yield return null;
        }

        EndPush();
    }

    private void Start()
    {
        _enemyAgent.updateRotation = false;
		_enemyAgent.updateUpAxis = false;
        _defaultSpeed.Speed = _enemyAgent.speed;
        _target = FindNearestEntity();
    }

    private void Update()
    {
        if (!_isPush)
        {
            Move();
            CheckOnPush();
        }

        _timeBtwPush -= Time.deltaTime;
    }

    private void Move()
    {
        _target = FindNearestEntity();
        _enemyAgent.SetDestination(_target.position);
    }

    private void CheckOnPush()
    {
        if (!_isPush && _timeBtwPush <= 0 && IsPushZone())
        {
            StartCoroutine(Push());
        }
    }

    private Transform FindNearestEntity()
    {
        LayerMask combinedMask = 0;
        foreach (LayerMask mask in _maskEnemy)
        {
            combinedMask |= mask;
        }

        Collider2D[] targets = Physics2D.OverlapCircleAll(
            transform.position,
            Mathf.Infinity,
            combinedMask
        );

        Transform nearestTarget = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider2D target in targets)
        {
            float distance = Vector2.Distance(transform.position, target.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestTarget = target.transform;
            }
        }

        return nearestTarget;
    }

    private void PreparingForPush()
    {
        _isPush = true;
        _enemyAgent.isStopped = true;
    }

    private void MakePush(Vector3 targetPos)
    {
        _enemyAgent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
        _enemyAgent.speed = DashSpeed;
        _enemyAgent.isStopped = false;
        _enemyAgent.SetDestination(targetPos);

        EnemyPush?.Invoke();
    }

    private void EndPush()
    {
        _enemyAgent.obstacleAvoidanceType = ObstacleAvoidanceType.MedQualityObstacleAvoidance;
        _enemyAgent.speed = _defaultSpeed.Speed;
        _isPush = false;

        _timeBtwPush = _startTimeBtwPush;
    }

    private bool IsPushZone()
    {
        return Vector3.Distance(transform.position, _target.position) <= _pushRange;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _pushRange);
    }

    private struct DefaultSpeed
    {
        public float Speed;
    }
}
