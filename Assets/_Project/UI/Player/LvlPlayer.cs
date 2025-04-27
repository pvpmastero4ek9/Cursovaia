using UnityEngine;
using Core.Players;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization;

namespace UI.Players
{
    public class LvlPlayer : MonoBehaviour
    {
        [SerializeField] private LocalPlayer _localPlayer;
        [SerializeField] private TMP_Text _textLvl;
        [SerializeField] private LocalizedString _localizedString;
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
            _playerData.ChangedPlayerData -= ChangeLvl;
        }

        private void GetPlayer(Player localPlayer)
        {
            _player = localPlayer;

            _player.PlayerData.ChangedPlayerData += ChangeLvl;
            ChangeLvl();
        }

        private void ChangeLvl()
        {
            _textLvl.text = _localizedString.GetLocalizedString(_playerData.PlayerLvl);
        }
    }
}
