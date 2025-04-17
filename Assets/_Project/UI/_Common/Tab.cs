using UnityEngine;
using UnityEngine.Events;

namespace UI.CommonScripts
{
    public class Tab : MonoBehaviour
    {
        public delegate void DisabledListener();
        
        private UnityEvent _enabled;

        public event UnityAction Enabled
        {
            add => _enabled.AddListener(value);
            remove => _enabled.RemoveListener(value);
        }
        
        public event DisabledListener Disabled;

        public void Enable()
        {
            if (gameObject.activeSelf)
            {
                return;
            }
            
            DisableAllOtherTabs();
            gameObject.SetActive(true);
        }

        private void DisableAllOtherTabs()
        {
            foreach (Transform child in transform.parent)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
