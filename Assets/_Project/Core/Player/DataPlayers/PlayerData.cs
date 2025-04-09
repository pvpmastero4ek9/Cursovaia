using UnityEngine;

namespace Core.DataPlayers
{
    public class PlayerData : MonoBehaviour
    {
        public string PlayerName { get; private set; }
        public int PlayerHealth { get; private set; }

        public void UpdateData(string NewPlayerName = null, int? NewPlayerHealth = null)
        {
            if (NewPlayerHealth.HasValue) PlayerHealth = NewPlayerHealth.Value;
            if (NewPlayerName != null) PlayerName = NewPlayerName;
        }
    }
}
