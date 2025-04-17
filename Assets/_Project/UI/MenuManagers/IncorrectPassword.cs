using UnityEngine;
using MySQLM;

namespace UI.MenuManagers
{
    public class IncorrectPassword : MonoBehaviour
    {
        [SerializeField] private RegistrationPlayer _registrationPlayer;
        [SerializeField] private GameObject _incorrectPasswordText;

        private void OnEnable()
        {
            _registrationPlayer.UnsuitablPassword += EnableText;
        }

        private void OnDisable()
        {
            _registrationPlayer.UnsuitablPassword -= EnableText;
        }

        private void EnableText()
        {
            _incorrectPasswordText.SetActive(true);
        }
    }
}
