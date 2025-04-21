using UnityEngine;

namespace Core.Enemys
{
    public class EnemyAnimation : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Animator _animator;

        private void FixedUpdate()
        {
            Run();
            Flip();
        }

        private void Run()
        {
            float Move = _rb.linearVelocity.magnitude;
            _animator.SetFloat("Move", Move);
        }

        private void Flip()
        {
            if (_rb.linearVelocity.x > 0.01f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (_rb.linearVelocity.x < 0.01f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}
