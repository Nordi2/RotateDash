using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textScore;

    public void UpdateText(string score) =>
        _textScore.text = score;

    public void DisableText() =>
        _textScore.enabled = false;
}
