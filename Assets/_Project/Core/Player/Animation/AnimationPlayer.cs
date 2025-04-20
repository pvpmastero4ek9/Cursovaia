using UnityEngine;

namespace Core.Players
{
    public class AnimationPlayer : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private void FixedUpdate()
        {
            Run();
            Flip();
        }

        private void Run()
        {
            float MoveX = Input.GetAxisRaw("Horizontal");
            float MoveY = Input.GetAxisRaw("Vertical");
            
            if (Mathf.Abs(MoveX) > 0)
            {
                _animator.SetFloat("Move", Mathf.Abs(MoveX));
            }
            else if (Mathf.Abs(MoveY) > 0)
            {
                _animator.SetFloat("Move", Mathf.Abs(MoveY));
            }
            else
            {
                _animator.SetFloat("Move", 0);
            }
        }

        private void Flip()
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}
