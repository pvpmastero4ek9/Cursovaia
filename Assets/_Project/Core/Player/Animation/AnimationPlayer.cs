using UnityEngine;

namespace Core.Players
{
    public class AnimationPlayer : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private void FixedUpdate()
        {
            Run();
        }

        private void Run()
        {
            float MoveX = Input.GetAxis("Horizontal");
            float MoveY = Input.GetAxis("Vertical");
            
            _animator.SetFloat("MoveX", MoveX);
            _animator.SetFloat("MoveY", MoveY);

            Flip(MoveX);
        }

        private void Flip(float moveX)
        {
            if (moveX >= 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else if (moveX < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}
