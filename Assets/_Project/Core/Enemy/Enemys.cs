using UnityEngine;
using Core.Entitys;
using Mirror;

public class Enemys : Entity
{
    protected override void Die()
    {
        Destroy(gameObject);
    }
}
