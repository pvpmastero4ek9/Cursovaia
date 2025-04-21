using UnityEngine;
using Core.Entitys;

namespace Core.Players
{
    public class PlayerAtack : EntitysAtack
    {
        private bool _isAttackQueued = false;
        private void Update()
        {
            if (TimeBtwAttack <= 0 && _isAttackQueued)
            {
                if (Input.GetMouseButton(0))
                {
                    EntityMovement.IsMove = false;
                    Anim.SetTrigger("IsAtack");
                    _isAttackQueued = false; // сброс очереди
                    TimeBtwAttack = StartTimeBtwAttack;
                }
            }
            else
            {
                TimeBtwAttack -= Time.deltaTime;

                // Позволяет "запомнить" атаку, если кликнули в период восстановления
                if (Input.GetMouseButtonDown(0))
                {
                    _isAttackQueued = true;
                }
            }
        }
    }
}
