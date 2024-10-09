using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.GamePlay.UI
{
    public class ScreenGameOverView : MonoBehaviour
    {
        private const float DURATION_POSITION = 0.25f;

        [SerializeField] private TextMeshProUGUI    _textScore;
        [SerializeField] private ButtonUp           _restartButton;
        [SerializeField] private ButtonUp           _mainMenuButton;
        [SerializeField] private RectTransform      _rectTransform;

        public ButtonUp RestartButton   => _restartButton;
        public ButtonUp MainMenuButton  => _mainMenuButton;

        public void SetTextScore(string newTextScore)
        {
            _textScore.text = newTextScore;
        }

        public void SetPositionAnimations()
        {
            _rectTransform.DOAnchorPos(Vector2.zero, DURATION_POSITION);
        }
    }
}