using UnityEngine;

namespace Core.Players
{
    public class AnimationPlayer : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private void FixedUpdate()
        {
            Flip();
            Run();
        }

        private void Run()
        {
            float MoveX = Input.GetAxisRaw("Horizontal");
            _animator.SetFloat("MoveX", Mathf.Abs(MoveX));
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
