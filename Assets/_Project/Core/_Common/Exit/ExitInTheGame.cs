using UnityEngine;
using Core.Exit;
using Data.Player;

namespace Core.Exit
{
    public class ExitInTheGame : MonoBehaviour
    {
        [SerializeField] private NickNameScriptableObject _nickNameScriptableObject;

        private void OnApplicationQuit()
        {
            SaveData();
        }

        private void OnDestroy()
        {
            SaveData();
        }

        private void SaveData()
        {
            string query = $@"
            UPDATE Players 
            SET level = {"newLevel"}, experience = {"newExp"}
            WHERE username = '{_nickNameScriptableObject.NickNamePlayer}'
            ";
            // ExecuteNonQuery(query);
        }
    }
}
