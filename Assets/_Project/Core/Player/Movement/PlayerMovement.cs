using UnityEngine;
using Mirror;
using Core.Entitys;

namespace Core.Players
{
    public class PlayerMovement : EntityMovement
    {
        protected override void Move()
        {
            if (!isLocalPlayer) return;
            
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Rb.MovePosition(Rb.position + input * Speed / 100);
        }
    }
}
