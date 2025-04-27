using UnityEngine;
using Core.Players;
using UnityEngine.UI;
using Core.Entitys;
using TMPro;

namespace UI.Players
{
    public class PlayerProgressBars : MonoBehaviour
    {
        [SerializeField] private PlayerState _playerState;
        [SerializeField] private LocalPlayer _localPlayer;
        [SerializeField] private Image _progressBar;
        [SerializeField] private TMP_Text _text_one;
        [SerializeField] private TMP_Text _text_two;
        private Player _player;
        private PlayerData _playerData => _player.PlayerData;
        
        private void OnEnable()
        {
            _localPlayer.FoundPlayer += GetPlayer;
        }

        private void OnDisable()
        {
            _localPlayer.FoundPlayer -= GetPlayer;
            if (_playerData == null) return;
            _playerData.ChangedPlayerData -= ChangeValueExpirience;
        }

        private void GetPlayer(Player localPlayer)
        {
            _player = localPlayer;

            _player.PlayerData.ChangedPlayerData += ChangeValueExpirience;
            ChangeValueExpirience();
        }

        private void ChangeValueExpirience()
        {
            _progressBar.fillAmount = (float)_playerData.PlayerExpirience / _playerData.GetExperienceForLevel;
            
            if (_playerState == PlayerState.Health)
            {
                HealthChange();
            }
            else if (_playerState == PlayerState.Expirience)
            {
                LvlChange();
            }
        }

        private void HealthChange()
        {
            _text_one.text = $"{_player.CurrentHealth}/{_player.MaxHealth}";
            _text_two.text = $"{_player.CurrentHealth}/{_player.MaxHealth}";
        }

        private void LvlChange()
        {
            _text_one.text = $"{_playerData.PlayerExpirience}/{_playerData.GetExperienceForLevel}";
            _text_two.text = $"{_playerData.PlayerExpirience}/{_playerData.GetExperienceForLevel}";
        }

        private enum PlayerState
        {
            Health,
            Expirience
        }
    }
}
