using UnityEngine;
using UnityEngine.AI;
using Core.Entitys;

public class EnemyMovement : EntityMovement
{
    [field: SerializeField] public NavMeshAgent EnemyAgent { get; private set; }
    private Transform _target;
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
        EnemyAgent.updateRotation = false;
		EnemyAgent.updateUpAxis = false;
        // Поиск игрока при старте
        _target = FindNearestPlayer();
    }

    protected override void Move()
    {
        if (_target != null)
        {
            EnemyAgent.SetDestination(_target.position);
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
}
