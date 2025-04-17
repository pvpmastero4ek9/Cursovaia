using UnityEngine;
using UnityEngine.UI;
using MySQLM;
using TMPro;

namespace UI.MenuManagers
{
    public class CreateAccaunt : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private RegistrationPlayer _registrationPlayer;
        [SerializeField] private TMP_InputField _nickName;
        [SerializeField] private TMP_InputField _password; 

        private void OnEnable()
        {
            _button.onClick.AddListener(CreateAccauntUser);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(CreateAccauntUser);
        }
        
        private void CreateAccauntUser()
        {
            _registrationPlayer.CreatePlayerAccaunt(_nickName.text, _password.text);
        }
    }
}
