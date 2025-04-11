using UnityEngine;
using Mirror;
using UnityEngine.UI;

namespace UI.MenuManagers
{
    public class ExitButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void OnEnable()
        {
            _button.onClick.AddListener(StopGame);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(StopGame);
        }

        public void StopGame()
        {
            if (NetworkServer.active && NetworkClient.isConnected)
            {
                NetworkManager.singleton.StopHost();
            }
            else if (NetworkClient.isConnected)
            {
                NetworkManager.singleton.StopClient();
            }
            else if (NetworkServer.active)
            {
                NetworkManager.singleton.StopServer();
            }
        }
    }
}
