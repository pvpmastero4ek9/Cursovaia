using UnityEngine;
using Mirror;

namespace Core.Entitys
{
    public class EntityMovement : NetworkBehaviour
    {
        [HideInInspector] public bool IsMove = true;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed;
        public Rigidbody2D Rb => _rb;
        public float Speed => _speed;

        protected void FixedUpdate() 
        {
            if (!IsMove) return;
            
            Move();
        }

        protected virtual void Move() {}
    }
}
