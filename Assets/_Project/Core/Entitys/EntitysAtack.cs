using UnityEngine;

namespace Core.Entitys
{
    public class EntitysAtack : MonoBehaviour
    {
        [SerializeField] private Transform _attackPos;
        [SerializeField] private LayerMask _maskEnemy;
        [SerializeField] private float _attackRange;
        [SerializeField] private int _damage;
        [SerializeField] private int _damag;
    }
}
