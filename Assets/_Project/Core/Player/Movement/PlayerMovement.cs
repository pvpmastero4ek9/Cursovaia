using UnityEngine;
using Mirror;

namespace Core.Players
{
    public class PlayerMovement : NetworkBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed;
        private void FixedUpdate() 
        {
            if (!isLocalPlayer) return;
            
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            _rb.MovePosition(_rb.position + input * _speed / 100);
        }
    }
}
