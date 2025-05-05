using UnityEngine;
using UnityEngine.AI;
using Core.Entitys;
using System.Collections;

public class EnemyMovement : EntityMovement
{
    private const float TimePauseJerk = 0.3f;
    private const float DashSpeed = 30f;
    [SerializeField] private NavMeshAgent _enemyAgent;
    private Transform _target;
    private DefaultSpeed _defaultSpeed = new();
    public bool _isJerk { get; private set; } = false;
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

    private void Start()
    {
        _enemyAgent.updateRotation = false;
		_enemyAgent.updateUpAxis = false;
        // Поиск игрока при старте
        _defaultSpeed.Speed = _enemyAgent.speed;
        _target = FindNearestPlayer();
    }

    protected override void Move()
    {
        if (_target != null)
        {
            if (!_isJerk) _enemyAgent.SetDestination(_target.position);
        }
        else
        {
            // Если игрок исчез (например, умер), ищем нового
            _target = FindNearestPlayer();
        }
    }

    private Transform FindNearestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Transform nearestPlayer = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject player in players)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestPlayer = player.transform;
            }
        }

        return nearestPlayer;
    }

    public IEnumerator Jerk()
    {
        Vector3 targetPos = _target.position; 
        _isJerk = true;
        _enemyAgent.isStopped = true;

        yield return new WaitForSeconds(TimePauseJerk);

        _enemyAgent.speed = DashSpeed;
        _enemyAgent.isStopped = false;
        _enemyAgent.SetDestination(targetPos);
        
        while (Vector3.Distance(transform.position, targetPos) > _enemyAgent.stoppingDistance + 0.6f)
        {
            yield return null;
        }

        _enemyAgent.speed = _defaultSpeed.Speed;
        _isJerk = false;
    }

    private struct DefaultSpeed
    {
        public float Speed;
    }
}
