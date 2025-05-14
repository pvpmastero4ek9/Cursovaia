using UnityEngine;
using Core.Entitys;
using System.Linq;
using System.Collections;
using UnityEngine.AI;

namespace Core.Enemys
{
    public class EnemyAtack : EntitysAtack
    {
        private Transform _currentPlayerTransform;
        private Transform[] _playersTransform;

        private void Start()
        {
            _playersTransform = GameObject.FindGameObjectsWithTag("Player").Select(x => x.transform).ToArray();
            _currentPlayerTransform = _playersTransform.OrderBy(x => Vector3.Distance(transform.position, x.position)).FirstOrDefault();
        }

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
