using Core.Entitys;
using UnityEngine;

namespace Core.Players
{
    public class SelectionWeapons : MonoBehaviour
    {
        [SerializeField] private Entity _entity;

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Weapon")
            {
                Weapon weapon = collision.gameObject.GetComponent<Weapon>();
                _entity.UpdateData(_entity.MaxHealth, _entity.CurrentHealth, weapon.Damage);
                
                Destroy(collision.gameObject);
            }
        }
    }
}
