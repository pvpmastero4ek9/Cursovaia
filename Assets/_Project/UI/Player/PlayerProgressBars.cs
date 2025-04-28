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
            if (_playerState == PlayerState.Health)
            {
                HealthChange();
            }
            else if (_playerState == PlayerState.Expirience)
            {
                ExpirienceChange();
            }
        }

        private void HealthChange()
        {
            VisualChange(_player.CurrentHealth, _player.MaxHealth);
        }

        private void ExpirienceChange()
        {
            VisualChange((float)_playerData.PlayerExpirience, _playerData.GetExperienceForLevel);
        }

        private void VisualChange(float currentValue, float maxValue)
        {
            _progressBar.fillAmount = currentValue / maxValue;
            _text_one.text = $"{currentValue}/{maxValue}";
            _text_two.text = $"{currentValue}/{maxValue}";
        }

        private enum PlayerState
        {
            Health,
            Expirience
        }
    }
}
