using UnityEngine;
using Mirror;
using Core.Entitys;

namespace Core.Players
{
    public class PlayerMovement : NetworkBehaviour
    {
        private const float SpeedReduction = 100f;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 5f;

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            if (!isLocalPlayer) return;
            
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            _rb.MovePosition(_rb.position + input * _speed / SpeedReduction);
        }
        
    }
}
