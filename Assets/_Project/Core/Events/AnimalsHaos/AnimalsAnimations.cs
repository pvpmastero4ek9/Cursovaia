using UnityEngine;
using UnityEngine.AI;

namespace Core.AnimalsHaos
{
    public class AnimalsAnimations : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private Vector3 _localVelocity;
        private Vector3 _direction;

        private void FixedUpdate()
        {
            _localVelocity = transform.InverseTransformDirection(_navMeshAgent.velocity);
            _direction = _localVelocity.normalized;

            Run();
            Flip();
        }

        private void Run()
        {
            _animator.SetFloat("MoveX", _direction.x);
            _animator.SetFloat("MoveY", _direction.y);
        }

        private void Flip()
        {
            if (_direction.x < 0.01f)
            {
                _spriteRenderer.flipX = false;
            } 
            else if (_direction.x > 0.01f)
            {
                _spriteRenderer.flipX = true;
            }
        }
    }
}
