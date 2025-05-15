using UnityEngine;
using Core.Entitys;
using System.Linq;
using System.Collections;
using UnityEngine.AI;

namespace Core.Enemys
{
    public class EnemyAtack : EntitysAtack
    {
        private void Update()
        {
            TimeBtwAttack -= Time.deltaTime;
        }

        private void CheckOnAttack()
        {
            if (TimeBtwAttack <= 0)
            {
                MakeAttack();
            }
        }

        private void MakeAttack()
        {
            // Anim.SetTrigger("IsAtack");
            OnAttack();
            TimeBtwAttack = StartTimeBtwAttack;
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            foreach(LayerMask layerMask in MaskEnemy)
            {
                if (LayerMask.GetMask(LayerMask.LayerToName(collision.gameObject.layer)) == layerMask)
                {
                    CheckOnAttack();
                    break;
                }
            }
        }
    }
}
