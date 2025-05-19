using UnityEngine;

namespace Core.Players
{
    public class PlayerData
    {
        private const float BaseExp = 100f;
        private const float growthRate = 1.5f;

        public string WeaponName { get; private set; }
        public string PlayerName { get; private set; }
        public int PlayerLvl { get; private set; }
        
        public int GetExperienceForLevel => (int)(BaseExp * Mathf.Pow(growthRate, PlayerLvl - 1));
        private int _playerExpirience;
        public int PlayerExpirience 
        { 
            get 
            { 
                return _playerExpirience; 
            } 
            set 
            { 
                if (value < 0) return; 

                if (_playerExpirience >= GetExperienceForLevel)
                {
                    UpdateData(PlayerName, 0, PlayerLvl + 1);
                }
                else
                {
                    UpdateData(PlayerName, value, PlayerLvl);
                }
            } 
        }
        
        public delegate void ChangedPlayerDataHandler();
        public event ChangedPlayerDataHandler ChangedPlayerData;

        public void ChangeWeaponName(string newWeapon) { WeaponName = newWeapon; }
        public void UpdateData(string NewPlayerName = null, int? playerExpirience = null, int? playerLvl = null)
        {
            if (NewPlayerName != null) PlayerName = NewPlayerName;
            if (playerExpirience != null) _playerExpirience = playerExpirience.Value;
            if (playerLvl != null) PlayerLvl = playerLvl.Value;

            ChangedPlayerData?.Invoke();
        }
    }
}
