using UnityEngine;
using UnityEngine.UI;
using Core.MenuManagers;

namespace UI.MenuManagers
{
    public class PlayButton : MonoBehaviour
    {
        [SerializeField] private MenuManager _menuManager;
        [SerializeField] private Button _button;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClickButton);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClickButton);
        }

        private void OnClickButton()
        {
            _menuManager.CreateGame();
        }
    }
}
