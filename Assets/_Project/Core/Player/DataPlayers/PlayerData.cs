using UnityEngine;

namespace Core.Players
{
    public class PlayerData
    {
        public string PlayerName { get; private set; }
        public int PlayerExpirience { get; private set; }
        public int PlayerLvl { get; private set; }

        public void UpdateData(string NewPlayerName = null, int? playerExpirience = null, int? playerLvl = null)
        {
            if (NewPlayerName != null) PlayerName = NewPlayerName;
            if (playerExpirience != null) PlayerExpirience = playerExpirience.Value;
            if (playerLvl != null) PlayerLvl = playerLvl.Value;
        }
    }
}
