using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.GamePlay.UI
{
    public class ButtonUp : MonoBehaviour
    {
        [SerializeField] private Button _button;

        public void AddListener(UnityAction calback) =>
            _button.onClick.AddListener(calback);

        public void RemoveListener(UnityAction calback) =>
            _button.onClick.RemoveListener(calback);
    }
}