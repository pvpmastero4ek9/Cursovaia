using UnityEngine;
using Mirror;

namespace Core.Entitys
{
    public class EntityMovement : NetworkBehaviour
    {
        private bool _isMove;
        private float _speed;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _currentSpeed;
        public Rigidbody2D Rb => _rb;
        public float Speed => _currentSpeed;
        public bool IsMove
        {
            get
            {
                return _isMove;
            }
            set
            {
                if (value == false)
                {
                    _speed = _currentSpeed;
                    _currentSpeed = 0;
                }
                else
                {
                    if (_speed == 0) return;
                    _currentSpeed = _speed;
                }
                _isMove = value;
            }
        }

        protected virtual void FixedUpdate() 
        {   
            Move();
        }

        protected virtual void Move() {}
    }
}
