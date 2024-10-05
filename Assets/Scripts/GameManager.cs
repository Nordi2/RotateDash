using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public bool _isGameRunning;

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }

        private void Awake()
        {
            Instance = this;
        }
    }
}