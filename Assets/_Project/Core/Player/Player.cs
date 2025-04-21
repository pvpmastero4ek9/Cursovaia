using UnityEngine;
using Core.Entitys;
using Data.Player;

namespace Core.Players
{
    public class Player : Entity
    {
        [SerializeField] private NickNameScriptableObject _nickNameScriptableObject;
        public PlayerData PlayerData { get; private set; } = new(); 
        private ParserSql _parserSql = new();

        private void Start()
        {
            PlayerData = _parserSql.ParsingTable(_nickNameScriptableObject.NickNamePlayer);
        }

        protected override void Die()
        {
            Destroy(gameObject);
        }
    }
}
