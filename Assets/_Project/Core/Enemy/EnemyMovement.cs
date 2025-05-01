using UnityEngine;
using UnityEngine.AI;
using Core.Entitys;

public class EnemyMovement : EntityMovement
{
    [SerializeField] private NavMeshAgent _enemyAgent;
    private Transform target;

    private void Start()
    {
        _enemyAgent.updateRotation = false;
		_enemyAgent.updateUpAxis = false;
        // Поиск игрока при старте
        target = FindNearestPlayer();
    }

    protected override void Move()
    {
        if (target != null)
        {
            _enemyAgent.SetDestination(target.position);
        }
        else
        {
            // Если игрок исчез (например, умер), ищем нового
            target = FindNearestPlayer();
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
