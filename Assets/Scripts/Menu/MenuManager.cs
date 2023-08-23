using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class MenuManager : MonoBehaviour
    {
        private const string MENU = "Menu";

        private void Start()
        {
            Cursor.lockState = CursorLockMode.None;
            AudioManager.Instance.Play(MENU);
        }

        public void StartGame()
        {
            AudioManager.Instance.Stop(MENU);
            SceneManager.LoadScene(1);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}