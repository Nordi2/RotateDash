using Assets.Scripts.GamePlay.Character;
using System;
using Zenject;

namespace Assets.Scripts.GamePlay.UI
{
    public class ScoreBank : IInitializable, IDisposable
    {
        public event Action OnChangedScore;

        private int _currentScore;

        private readonly ICharacterFacade _characterFacade;

        public ScoreBank(ICharacterFacade characterFacade)
        {
            _characterFacade = characterFacade;
        }

        public int CurrentScore => _currentScore;

        public void Initialize()
        {
            _characterFacade.OnColliderWithWall += AddScore;
            _currentScore = 0;
        }

        public void Dispose() =>
            _characterFacade.OnColliderWithWall -= AddScore;

        private void AddScore(TypeObstacle obstacle)
        {
            _currentScore++;
            OnChangedScore?.Invoke();
        }

    }
}