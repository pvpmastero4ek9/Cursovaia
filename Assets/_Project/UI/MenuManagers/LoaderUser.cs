using UI.CommonScripts;
using UnityEngine;
using MySQLM;
using System;

namespace UI.MenuManagers
{
    public class LoaderUser : MonoBehaviour
    {
        [SerializeField] private Tab _connectServerMenu;
        [SerializeField] private Tab _notLoadPlayer;
        [SerializeField] private RegistrationPlayer _registrationPlayer;

        private void OnEnable()
        {
            _registrationPlayer.PlayerLoader += EnableTabConnectServerMenu;
            _registrationPlayer.UnsuitablUser += EnableTabNotLoadPlayer;
        }

        private void OnDisable()
        {
            _registrationPlayer.PlayerLoader -= EnableTabConnectServerMenu;
            _registrationPlayer.UnsuitablUser -= EnableTabNotLoadPlayer;
        }

        private void EnableTabConnectServerMenu(string Nickname)
        {
            _connectServerMenu.Enable();
        }

        private void EnableTabNotLoadPlayer()
        {
            _notLoadPlayer.Enable();
        }
    }
}
