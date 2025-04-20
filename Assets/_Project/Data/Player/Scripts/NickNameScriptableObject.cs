using UnityEngine;

namespace Data.Player
{
    [CreateAssetMenu(fileName = "NickNameScriptableObject", menuName = "Scriptable Objects/NickNameScriptableObject")]
    public class NickNameScriptableObject : ScriptableObject
    {
        public string NickNamePlayer { get; private set; }

        public void ChangeCurrentNickNamePlayer(string nick)
        {
            NickNamePlayer = nick;
        }
    }
}
