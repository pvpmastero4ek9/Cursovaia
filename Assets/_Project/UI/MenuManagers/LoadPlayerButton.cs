using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MySQLM;

namespace UI.MenuManagers
{
    public class LoadPlayerButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_InputField _nickName;
        [SerializeField] private TMP_InputField _password;
        [SerializeField] private RegistrationPlayer _registrationPlayer;

        private void OnEnable()
        {
            _button.onClick.AddListener(LoadPlayer);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(LoadPlayer);
        }

        private void LoadPlayer()
        {
            _registrationPlayer.LoadPlayer(_nickName.text, _password.text);
        }
    }
}
