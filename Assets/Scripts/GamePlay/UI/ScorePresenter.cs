using System;
using Zenject;

namespace Assets.Scripts.GamePlay.UI
{
    public class ScorePresenter : IInitializable, IDisposable
    {
        private readonly ScoreBank _scoreBank;
        private readonly ScoreView _scoreView;

        public ScorePresenter(ScoreBank scoreBank, ScoreView scoreView)
        {
            _scoreBank = scoreBank;
            _scoreView = scoreView;
        }

        public void Initialize()
        {
            _scoreView.UpdateText(_scoreBank.CurrentScore.ToString());
            _scoreBank.OnChangedScore += ChanedScore;
        }

        public void Dispose() =>
            _scoreBank.OnChangedScore -= ChanedScore;

        private void ChanedScore() =>
            _scoreView.UpdateText(_scoreBank.CurrentScore.ToString());
    }
}