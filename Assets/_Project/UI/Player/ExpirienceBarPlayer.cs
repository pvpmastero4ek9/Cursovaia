using UnityEngine;
using Core.Players;
using UnityEngine.UI;
using Mirror;
using System.Collections;
using TMPro;

namespace UI.Players
{
    public class ExpirienceBarPlayer : MonoBehaviour
    {
        [SerializeField] private Image _expirienceBar;
        [SerializeField] private TMP_Text _text_one;
        [SerializeField] private TMP_Text _text_two;
        private Player _player;
        private PlayerData _playerData => _player.PlayerData;
        
        private void OnEnable()
        {
            StartCoroutine(WaitForPlayer());
        }

        private void OnDisable()
        {
            _playerData.ChangedPlayerData -= ChangeValueExpirience;
        }

        private IEnumerator WaitForPlayer()
        {
            yield return new WaitUntil(() => NetworkClient.localPlayer != null);

            _player = NetworkClient.localPlayer.GetComponent<Player>();
            _player.PlayerData.ChangedPlayerData += ChangeValueExpirience;

            ChangeValueExpirience();
        }

        private void ChangeValueExpirience()
        {
            _expirienceBar.fillAmount = (float)_playerData.PlayerExpirience / _playerData.GetExperienceForLevel;
            _text_one.text = $"{_playerData.PlayerExpirience}/{_playerData.GetExperienceForLevel}";
            _text_two.text = $"{_playerData.PlayerExpirience}/{_playerData.GetExperienceForLevel}";
        }
    }
}
