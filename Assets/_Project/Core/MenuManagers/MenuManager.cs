using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.MenuManagers
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private string _nameScene;
        
        public void CreateGame()
        {
            SceneManager.LoadScene(_nameScene);
        }
    }
}
