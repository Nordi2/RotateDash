using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance;

        public int Score;

        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Button _restartButton;

        private void Awake()
        {
            Instance = this;
        }

        public void ActivateRestartButton()
        {
            _restartButton.onClick.AddListener(() => { GameManager.Instance.RestartGame(); });
            _restartButton.gameObject.SetActive(true);
        }

        public void UpdateScoreText()
        {
            _scoreText.text = Score.ToString();
        }
    }
}