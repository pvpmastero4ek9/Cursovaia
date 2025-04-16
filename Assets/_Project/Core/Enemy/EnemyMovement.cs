using UnityEngine;
using Mirror;
using Core.Entitys;

public class EnemyMovement : EntityMovement
{
    private Transform target;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Поиск игрока при старте
        target = FindNearestPlayer();
    }

    protected override void Move()
    {
        if (target != null)
        {
            // Движение к игроку
            Vector2 direction = (target.position - transform.position).normalized;
            rb.linearVelocity = direction * Speed;
        }
        else
        {
            // Если игрок исчез (например, умер), ищем нового
            target = FindNearestPlayer();
        }
    }

    Transform FindNearestPlayer()
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
